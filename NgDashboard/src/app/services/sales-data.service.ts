import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
// import 'rxjs/add/operator/map';


@Injectable({
  providedIn: 'root'
})
export class SalesDataService {

  constructor(private http: Http) { }

  getOrders(pageIndex: number, pageSize: number) {
     this.http.get('http://localhost:5001/api/order' + pageIndex + '/' + pageSize)
      .subscribe(response => { response.json(); });
  }

  // getOrdersByCustomer(n: number) {
  //   return this.http.get('http://locslhody:5001/api/order/bycustomer/' + n)
  //   .subscribe(response => response.json());
  // }

  // getOrdersByState() {
  //   return this.http.get('http://localhost:5001/api/order/bystate')
  //     .subscribe(response => response.json());
  // }
}
