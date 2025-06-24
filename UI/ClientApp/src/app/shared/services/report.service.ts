import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment.dev';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProductsReport(){
    const token = localStorage.getItem('jwt');
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.get(this.apiUrl + '/report/product', {
        responseType: 'arraybuffer',
        headers: headers
    });
  }
}
