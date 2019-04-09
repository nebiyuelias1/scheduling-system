import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisrationFormComponent } from './regisration-form/regisration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';

@NgModule({
  declarations: [RegisrationFormComponent, LoginFormComponent],
  imports: [
    CommonModule
  ]
})
export class AccountsModule { }
