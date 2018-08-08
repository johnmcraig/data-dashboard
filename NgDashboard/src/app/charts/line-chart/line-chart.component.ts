import { Component, OnInit } from '@angular/core';
import { LINE_CHART_COLORS } from '../../shared/chart.colors';
import { SalesDataService } from '../../services/sales-data.service';

// const LINE_CHART_SAMPLE_DATA: any[] = [
//   { data: [32, 14, 46, 23, 38, 56], label: 'Sentiment Analysis'},
//   { data: [12, 18, 26, 13, 28, 26], label: 'Image Recognition'},
//   { data: [52, 34, 49, 53, 68, 62], label: 'Forecasting'}
// ];

// const LINE_CHART_LABELS: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'];

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor(private _salesDataService: SalesDataService) { }

  topCustomers: string[];
  allOrders: any[];

  lineChartData: any; // = LINE_CHART_SAMPLE_DATA;
  lineChartLabels: any; // = LINE_CHART_LABELS;
  lineChartType = 'line';
  lineChartOptions: any = {
    responsive: true
  };
  lineChartLegend: true;
  lineChartColors = LINE_CHART_COLORS;

  ngOnInit() {
    this._salesDataService.getOrders(1, 100).subscribe(res => {
      this.allOrders = res['page']['data'];
      // console.log('getOrders', response);
      // console.log(this.allOrders);
      this._salesDataService.getOrdersByCustomer(3).subscribe(customer => {
        this.topCustomers = customer.map(x => x['name']);
        const allChartData = this.topCustomers.reduce((result, i) => {
          result.push(this.getChartData(this.allOrders, i));
          return result;
        }, []);
      });
    });
  }

  getChartData(allOrders: any, name: string) {
    const customerOrders = allOrders.filter(o => o.customer.name === name);
    console.log('name:', name, 'customerOrders', customerOrders);
    const formattedOrders = customerOrders.reduce((r, e) => {   // r = accumulator, e = iterator in callback function
      r.push([e.placed, e.total]);
      return r;
    }, []);

    console.log('formattedOrders', formattedOrders);
    const result = { customer: name, data: formattedOrders};
    console.log('result', result);
    return result;
  }
}
