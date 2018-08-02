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

  lineChartData: any; // LINE_CHART_SAMPLE_DATA;
  lineChartLabels: any; // LINE_CHART_LABELS;
  lineChartType = 'line';
  lineChartOptions: any = {
    responsive: true
  };
  lineChartLegend = true;
  lineChartColors = LINE_CHART_COLORS;

  ngOnInit() {
    this._salesDataService.getOrders(1, 100).subscribe(response => {
      console.log('getOrders', response);
    });
  }
}
