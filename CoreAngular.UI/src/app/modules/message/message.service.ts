import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { EntityService } from 'src/app/shared/services/entity.service';
import { Message } from 'src/app/shared/models/message';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService extends EntityService<Message> {

  constructor() {
    super('message');
  }

  getMessages(id: number, page?, itemsPerPage?, messageContainer?): Observable<Message[]> {
    let messages: Message[] = new Array<Message>();

    let params = new HttpParams();

    params = params.append('MessageContainer', messageContainer);

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<Message[]>(`${this.url}/${this.endpoint}/getMessages`, {observe: 'response', params})
      .pipe(
        map(response => {
          messages = response.body;
          return messages;
        })
      );
  }

  getMessageThread(id: number, recipientId: number): Observable<Message[]> {
    return this.http.get<Message[]>(`${this.url}/${this.endpoint}/getMessageThread/${recipientId}`);
  }

  sendMessage(id: number, message: Message): Observable<any> {
    return this.http.post(`${this.url}/${this.endpoint}/createMessage`, {id, message});
  }

  deleteMessage(id: number, userId: number): Observable<any> {
    return this.http.post(`${this.url}/${this.endpoint}/createMessage`, {id, userId});
  }

  markAsRead(userId: number, messageId: number): Observable<any> {
    return this.http.post(`${this.url}/${this.endpoint}/markMessageAsRead`, {userId, messageId});
  }

}
