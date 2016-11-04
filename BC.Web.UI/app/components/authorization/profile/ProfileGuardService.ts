import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Rx';

// Services
import AuthService from '../AuthService';

@Injectable()
export default class ProfileGuardService implements CanActivate {
    constructor(
      private _authService: AuthService,
      private _router: Router
    ) {}

    canActivate(
      route: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): Observable<boolean> | boolean {
        if (this._authService.checkAuthorization()) return true;

        this._router.navigate(['/sign-in']);

        return false;
      }
}
