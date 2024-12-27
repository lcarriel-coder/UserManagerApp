import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreatePersonRoutingModule } from './create-person-routing.module';
import { CreatePersonComponent } from './create-person.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CreatePersonComponent,
  ],
  imports: [
    CommonModule,
    CreatePersonRoutingModule,
    ReactiveFormsModule
  ]
})
export class CreatePersonModule { }
