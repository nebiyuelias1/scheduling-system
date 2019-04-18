import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { UserService } from './user.service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    private userService: UserService,
    private router: Router) { }

  canActivate(route, state: RouterStateSnapshot) {
    if (this.userService.isLoggedIn()) {
      return true;
    }

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
    return false;
  }
}
