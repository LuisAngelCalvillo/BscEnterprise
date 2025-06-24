import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseDataDto } from '../interfaces/responseDto.models';
import { environment } from '../../../environments/environment.dev';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRoles() : Observable<ResponseDataDto> {
    const token = localStorage.getItem('jwt');
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.get<ResponseDataDto>(this.apiUrl+'/role/getall', {headers});
  }
}
