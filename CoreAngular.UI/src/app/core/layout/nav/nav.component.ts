import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { UserService } from 'src/app/modules/user/user.service';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  user: User;

  constructor(
    private userService: UserService,
    private router: Router) { }
    // , private fb: FormBuilder) { }

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
