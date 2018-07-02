import { Component, OnInit } from '@angular/core';


const SAMPLE_BARCHART_DATA: any[] = [
  { data: [65, 59, 80, 81, 56, 54, 30], label: 'Q3 Sales'},
  { data: [25, 39, 60, 91, 36, 44, 10], label: 'Q4 Sales'}
];

const SAMPLE_BARCHART_LABELS: string[] = ['Week 1', 'Week 2', 'Week 3', 'Week 4', 'Week 5', 'Week 6'];

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {

  constructor() { }

  public barChartData: any[] = SAMPLE_BARCHART_DATA;
  public barChartLabels: string[] = SAMPLE_BARCHART_LABELS;
  public barChartType = 'bar';
  public barChartLegend = false;
  public barChartOptions: any = {
    scaleShowVerticleLines: false,
    responsive: true
  };

  ngOnInit() {
  }

}
