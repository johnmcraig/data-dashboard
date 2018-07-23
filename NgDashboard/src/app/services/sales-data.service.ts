import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class SalesDataService {

  constructor(private http: Http) { }

  getOrders(pageIndex: number, pageSize: number) {
     return this.http.get('http://localhost:5000/api/order/' + pageIndex + '/' + pageSize)
      .pipe(map(response => response.json()));
  }

  getOrdersByCustomer(n: number) {
    return this.http.get('http://locslhody:5000/api/order/bycustomer/' + n)
    .pipe(map(response => response.json()));
  }

  getOrdersByState() {
    return this.http.get('http://localhost:5000/api/order/bystate/')
      .pipe(map(response => response.json()));
  }
}
