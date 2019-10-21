import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntityService } from './services/entity.service';
import { AuthGuard } from './guards/auth.guard';

@NgModule({
  declarations: [ AuthGuard ],
  imports: [
    CommonModule
  ],
  providers: [ EntityService ]
})
export class SharedModule { }
