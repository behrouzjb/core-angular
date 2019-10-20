import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService } from './message.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [ MessageService ]
})
export class MessageModule { }
