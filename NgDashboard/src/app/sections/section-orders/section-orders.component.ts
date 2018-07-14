import { Component, OnInit } from '@angular/core';
import { Order } from '../../shared/order';

@Component({
  selector: 'app-section-orders',
  templateUrl: './section-orders.component.html',
  styleUrls: ['./section-orders.component.css']
})
export class SectionOrdersComponent implements OnInit {
  constructor() {}

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

  ngOnInit() {}

  goToPrevious(): void {
    console.log('Previous button clicked!');
  }
}
