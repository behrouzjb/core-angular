import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from './home/home.module';
import { UserModule } from './user/user.module';
import { MessageModule } from './message/message.module';

@NgModule({
  declarations: [
    HomeModule,
    UserModule,
    MessageModule
  ],
  imports: [
    CommonModule
  ]
})
export class ModulesModule { }
