import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseDataDto, ResponseDto } from '../interfaces/responseDto.models';
import { environment } from '../../../environments/environment.dev';
import { Product } from '../interfaces/product.models';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts() : Observable<ResponseDataDto> {
    const token = localStorage.getItem('jwt');
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.get<ResponseDataDto>(this.apiUrl+'/product/getall', {headers});
  }

  createProduct(product: Product){
    const token = localStorage.getItem('jwt');

    console.log(product)
    
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
    });

    return this.http.post<ResponseDto>(this.apiUrl+'/product/create', product, {headers});
  }
}
