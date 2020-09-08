import { Component, OnInit } from '@angular/core';
import { SalesDataService } from '../../services/sales-data.service';
import * as moment from 'moment';

// const SAMPLE_BARCHART_DATA: any[] = [
//   { data: [65, 59, 80, 81, 56, 54, 30], label: 'Q3 Sales'},
//   { data: [25, 39, 60, 91, 36, 44, 10], label: 'Q4 Sales'}
// ];

// const SAMPLE_BARCHART_LABELS: string[] = ['Week 1', 'Week 2', 'Week 3', 'Week 4', 'Week 5', 'Week 6'];

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {

  constructor(private _salesDataService: SalesDataService) { }
  orders: any;
  orderLabels: string[];
  orderData: number[];

  public barChartData: any[]; // =SAMPLE_BARCHART_DATA;
  public barChartLabels: string[]; // =SAMPLE_BARCHART_LABELS;
  public barChartType = 'bar';
  public barChartLegend = false;
  public barChartOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  ngOnInit() {
    this._salesDataService.getOrders(1, 100)
    .subscribe( response => {
      // console.log(response['page']['data']);
      const localChartData = this.getChartData(response);
      this.barChartLabels = localChartData.map(x => x[0]).reverse();
      this.barChartData = [{ 'data': localChartData.map(x => x[1]), 'label': 'Sales'}];
    });
  }

  getChartData(response: Response) {
    this.orders = response['page']['data'];
    const data = this.orders.map(o => o.total);
    console.log('data', data);
    const labels = this.orders.map(o => moment(new Date(o.placed)).format('YY-MM-DD'));
    // format orders from API, then order them by id
    const formattedOrders = this.orders.reduce((r, e) => {
      r.push([moment(e.placed).format('YY-MM-DD'), e.total]);
      return r;
    }, []);
    console.log(labels);
    console.log(formattedOrders);
    const p = [];
    const chartData = formattedOrders.reduce((r, e) => {
      const key = e[0];
      if (!p[key]) {
        p[key] = e;
        r.push(p[key]);
      } else {
        p[key][1] += e[1];
      }
      return r;
    }, []);
    // console.log(chartData);
    return chartData;
    // reduce
    // const myData = [3, 4, 5].reduce((sum, value) => {
    //   console.log('sum', sum, 'value', value);
    //   return sum + value;
    // }, 0);
    // console.log('myData', myData);
  }

}
