import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from './home/home.module';
import { UserModule } from './user/user.module';
import { MessageModule } from './message/message.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HomeModule,
    UserModule,
    MessageModule
  ]
})
export class ModulesModule { }
