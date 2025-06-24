import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { jwtDecode, JwtPayload } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private http: HttpClient, private router: Router) {}

  canActivate(): boolean | UrlTree {
    const token = localStorage.getItem('jwt');

    if (!token) {
      console.warn('No se encontro el token, sera redirigido al login');
      return this.router.parseUrl('/login');
    }

    try {
      const payload = jwtDecode<any>(token);

      const currentTime = Math.floor(Date.now() / 1000);
      if (payload.exp && payload.exp < currentTime) {
        localStorage.removeItem('jwt');
        return this.router.parseUrl('/login');
      }
      const role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
      switch (role) {
        case 'Administrador':
          this.router.navigate(['/admin']);
          break;
        case 'Vendedor':
          this.router.navigate(['/seller']);
          break;
        case 'Personal':
          this.router.navigate(['/staff']);
          break;
        default:
          this.router.navigate(['/login']);
      }

      return false;
    } catch {
      localStorage.removeItem('jwt');
      return this.router.parseUrl('/login');
    }
  }
}
