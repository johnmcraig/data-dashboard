import { Component, OnInit } from '@angular/core';
import { Order } from '../../shared/order';
import { SalesDataService } from '../../services/sales-data.service';

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {

  constructor(private _salesData: SalesDataService) {}

  orders: Order[] = [
    {
      id: 1,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        state: 'CO',
        email: 'mainstbakery@eample.com'
      },
      total: 230,
      placed: new Date(2018, 1, 1),
      fulfilled: new Date(2018, 1, 5),
      status: 'Comleted'
    },
    {
      id: 2,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        state: 'CO',
        email: 'mainstbakery@eample.com'
      },
      total: 230,
      placed: new Date(2018, 1, 1),
      fulfilled: new Date(2018, 1, 5),
      status: 'Comleted'
    },
    {
      id: 3,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        state: 'CO',
        email: 'mainstbakery@eample.com'
      },
      total: 230,
      placed: new Date(2018, 1, 1),
      fulfilled: new Date(2018, 1, 5),
      status: 'Comleted'
    },
    {
      id: 4,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        state: 'CO',
        email: 'mainstbakery@eample.com'
      },
      total: 230,
      placed: new Date(2018, 1, 1),
      fulfilled: new Date(2018, 1, 5),
      status: 'Comleted'
    },
    {
      id: 5,
      customer: {
        id: 1,
        name: 'Main St Bakery',
        state: 'CO',
        email: 'mainstbakery@eample.com'
      },
      total: 230,
      placed: new Date(2018, 1, 1),
      fulfilled: new Date(2018, 1, 5),
      status: 'Comleted'
    }
  ];
  total = 0;
  page = 1;
  limit = 10;
  loading = false;

  ngOnInit() {
    this.getOrders();
  }

  getOrders(): void {
    this._salesData.getOrders(this.page, this.limit)
    .subscribe(res => {
       // console.log('Results from getOLrders: ', res);
      this.orders = res['page']['data'];
      this.total = res['page'].total;
      this.loading = false;
    });
  }

  goToPrevious(): void {
    // console.log('Previous button clicked!');
    this.page--;
    this.getOrders();
  }

  goToNext(): void {
    // console.log('Next button clicked!');
    this.page++;
    this.getOrders();
  }

  goToPage(n: number): void {
    this.page = n;
    this.getOrders();
  }
}
