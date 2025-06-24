import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseDataDto, ResponseDto } from '../interfaces/responseDto.models';
import { environment } from '../../../environments/environment.dev';
import { Router } from '@angular/router';
import { User } from '../interfaces/user.models';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) { }

  createUser(user: User) : Observable<ResponseDto> {
    const token = localStorage.getItem('jwt');
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.post<ResponseDto>(this.apiUrl+'/user/create', user, {headers});
  }
}
