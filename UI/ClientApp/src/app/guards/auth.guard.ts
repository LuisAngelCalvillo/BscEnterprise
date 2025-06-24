import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree {
    const token = localStorage.getItem('jwt');

    if (!token) {
      return this.router.parseUrl('/login');
    }

    try {
      const payload = jwtDecode<any>(token);
      const currentTime = Math.floor(Date.now() / 1000);
      if (payload.exp && payload.exp < currentTime) {
        localStorage.removeItem('jwt');
        return this.router.parseUrl('/login');
      }

      const role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      const allowedRoles = route.data["roles"] as string[];

      if (allowedRoles.includes(role)) {
        return true;
      } else {
        return this.router.parseUrl('/validate');
      }

    } catch {
      localStorage.removeItem('jwt');
      return this.router.parseUrl('/login');
    }
  }
}
