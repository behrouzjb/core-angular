using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreAngular.API.BLL.Services;
using CoreAngular.API.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAngular.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("getMessage/{id}")]
        public async Task<ActionResult<Message>> GetMessage(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            else
            {
                var message = await _messageService.GetMessage(id);

                if (message == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(message);
                }
            }
        }

        [HttpGet(Name = "getMessagesForUser")]
        public async Task<ActionResult<List<Message>>> GetMessagesForUser(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            else
            {
                var messages = await _messageService.GetMessagesForUser(userId);
                return Ok(messages);
            }
        }

        [HttpGet("getMessageThread/{recipientId}")]
        public async Task<ActionResult<List<Message>>> GetMessageThread(int userId, int recipientId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            else
            {
                var message = await _messageService.GetMessageThread(userId, recipientId);
                return Ok(message);
            }
        }

        [HttpPost("createMessage")]
        public async Task<ActionResult<Message>> CreateMessage(int userId, Message messageCreation)
        {
            var message = messageCreation;
            var sender = _userService.GetById(userId);

            if (sender.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            else
            {
                var recipient = _userService.GetById(userId);

                if (recipient == null)
                {
                    return BadRequest("Could not find user");
                }
                else
                {
                    message.SendingUserId = userId;
                    _messageService.Add(message);
                    return CreatedAtRoute("getMessage", new { id = message.Id }, message);
                }
            }

            // throw new Exception("Creating the message failed on save");
        }

        [HttpPost("deleteMessage")]
        public async Task<IActionResult> DeleteMessage(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            else
            {
                var message = await _messageService.GetMessage(id);

                if (message.SendingUserId == userId)
                    message.IsSenderDeleted = true;

                if (message.ReceivingUserId == userId)
                    message.IsReceiverDeleted = true;

                if (message.IsSenderDeleted && message.IsReceiverDeleted)
                    _messageService.Delete(message);

                return NoContent();
            }

            // throw new Exception("Error deleting the message");
        }

        [HttpPost("markMessageAsRead")]
        public async Task<IActionResult> MarkMessageAsRead(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            else
            {
                var message = await _messageService.GetMessage(id);

                if (message.ReceivingUserId != userId)
                {
                    return Unauthorized();
                }
                else
                {
                    message.IsRead = true;
                    message.DateRead = DateTime.Now;
                    _messageService.Update(message);
                    return NoContent();
                }
            }
        }
    }
}
