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

  @Output() cancelLogin = new EventEmitter();
  user: User;
  loginForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private userService: UserService,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit() {
  }

  login() {
    this.userService.login(this.user).subscribe(() => {
      this.router.navigate(['/users']);
    });
  }

}
