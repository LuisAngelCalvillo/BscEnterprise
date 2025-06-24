import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from '../../interfaces/auth.models';
import { Observable } from 'rxjs';
import { ResponseDataDto } from '../../interfaces/responseDto.models';
import { environment } from '../../../../environments/environment.dev';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) { }

  login(user: LoginRequest) : Observable<ResponseDataDto> {
    return this.http.post<ResponseDataDto>(this.apiUrl+'/auth/login', user);
  }

  logout(): void {
    localStorage.removeItem('jwt');
    this.router.navigate(['/validate']);
  }
}
