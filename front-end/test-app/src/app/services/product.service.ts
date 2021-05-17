import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../model/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private fullApiURL = `${environment.serverUrl}/products`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.fullApiURL);
  }

  getById(id: number): Observable<Product> {
    return this.http.get<Product>(this.fullApiURL + `/${id}`);
  }

  createProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.fullApiURL, product);
  }

  updateProduct(id: number, product: Product) {
    return this.http.put(this.fullApiURL + `/${id}`, product)
  }

  deleteProduct(id: number) {
    return this.http.delete(this.fullApiURL + `/${id}`);
  }

}
