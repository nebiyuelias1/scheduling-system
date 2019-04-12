import { Routes, RouterModule, Router } from '@angular/router';
import { NgModule } from '@angular/core';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegisrationFormComponent } from './regisration-form/regisration-form.component';

const routes: Routes = [
    {
        path: 'login',
        component: LoginFormComponent,
        pathMatch: 'full',
    },
    {
        path: 'register',
        component: RegisrationFormComponent,
        pathMatch: 'full',
    },
];



@NgModule({
    declarations: [],
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: [],
})
export class UserRoutingModule { }
