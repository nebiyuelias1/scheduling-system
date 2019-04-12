import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisrationFormComponent } from './regisration-form/regisration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserRoutingModule } from './user-routing.module';
import { UserService } from './user.service';
import { BaseService } from './base.service';

@NgModule({
  declarations: 
  [
    RegisrationFormComponent, 
    LoginFormComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    UserService
  ]
})
export class AccountsModule { }
