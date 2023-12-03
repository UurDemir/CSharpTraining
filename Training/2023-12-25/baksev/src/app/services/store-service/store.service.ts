import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../../models/product';
import { Observable } from 'rxjs';
import { User } from '../../models/user';

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  private baseUrl: string = 'https://fakestoreapi.com';

  constructor(private httpClient: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.baseUrl + '/products');
  }

  getCategoryProducts(category: string): Observable<Product[]> {
    return this.httpClient.get<Product[]>(
      this.baseUrl + '/products/category/' + category
    );
  }

  getCategories(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.baseUrl + '/products/categories');
  }

  getAllUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.baseUrl + '/users');
  }
}
