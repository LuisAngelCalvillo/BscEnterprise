import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseDataDto, ResponseDto } from '../interfaces/responseDto.models';
import { environment } from '../../../environments/environment.dev';
import { Order } from '../interfaces/order.models';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  insertOrder(order: Order) : Observable<ResponseDto> {
    const token = localStorage.getItem('jwt');
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.post<ResponseDataDto>(this.apiUrl+'/order/create', order, {headers});
  }

  getOrders() : Observable<ResponseDataDto> {
    const token = localStorage.getItem('jwt');
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.get<ResponseDataDto>(this.apiUrl+'/order/getall', {headers});
  }

  getDetailOrder(idOrder: number) : Observable<ResponseDataDto> {
    const token = localStorage.getItem('jwt');
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.get<ResponseDataDto>(this.apiUrl+'/order/get/'+idOrder, {headers});
  }
}
