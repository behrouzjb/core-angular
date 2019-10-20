import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from './home/home.module';
import { UserModule } from './user/user.module';

@NgModule({
  declarations: [
    HomeModule,
    UserModule
  ],
  imports: [
    CommonModule
  ]
})
export class ModulesModule { }
