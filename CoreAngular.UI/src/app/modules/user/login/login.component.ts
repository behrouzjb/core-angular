import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { User } from 'src/app/shared/models/user';
import { BsDatepickerConfig } from 'ngx-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  user: User;

  constructor(
    private userService: UserService,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit() { }

  login(): void {
    this.userService.login(this.user).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log(error);
    }, () => {
      this.router.navigate(['/users']);
    });
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.userService.decodedToken = null;
    this.userService.currentUser = null;
    this.router.navigate(['/home']);
  }

}
