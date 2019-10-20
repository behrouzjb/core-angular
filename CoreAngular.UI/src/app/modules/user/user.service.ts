import { Injectable } from '@angular/core';
import { EntityService } from 'src/app/shared/services/entity.service';
import { User } from 'src/app/shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService extends EntityService<User> {

  constructor() {
    super('');
  }
}
