import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntityService } from 'src/app/shared/services/entity.service';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [ EntityService ]
})
export class UserModule { }
