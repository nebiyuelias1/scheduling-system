import { Component } from '@angular/core';
import { UserService } from '../accounts/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private userService: UserService) {  }
}
