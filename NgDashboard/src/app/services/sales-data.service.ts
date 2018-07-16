import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable({
  providedIn: 'root'
})
export class SalesDataService {

constructor(private _http: Http) { }

getOrders(pageIndex: number, pageSize: number) {
  return this._http.get('http://localhost:5000/api/order' + pageIndex + '/' + pageSize)
  .subscribe(res => res.json());
 }
}
