import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-validate',
  template: ''
})
export class ValidateComponent implements OnInit {

  constructor(private router: Router) {}

  ngOnInit(): void {
    const token = localStorage.getItem('jwt');

    if (!token) {
      this.router.navigate(['/login']);
      return;
    }

    try {
      const payload = jwtDecode<any>(token);
      const role = payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

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
          this.router.navigate(['/unauthorized']);
      }
    } catch {
      localStorage.removeItem('jwt');
      this.router.navigate(['/login']);
    }
  }
}
