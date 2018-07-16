import { Injectable } from '@angular/core';
import { Http } from '@angular/http';


@Injectable({
  providedIn: 'root'
})
export class SalesDataService {

constructor(private _http: Http) { }

getOrders(pageIndex: number, pageSize: number) {
  return this._http.get('http://localhost:5001/api/order' + pageIndex + '/' + pageSize)
  .subscribe(res => res.json());
 }
}
