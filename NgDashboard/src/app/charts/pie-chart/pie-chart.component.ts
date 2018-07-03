import { Component, OnInit } from '@angular/core';

const PIE_CHART_DATA: any[] = [];
@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {
  constructor() {}

  pieChartData: number[] = [350, 450, 120];
  pieChartLabels: string[] = [
    'XYZ Logistics',
    'Main St Backery',
    'Acme Sales'
  ];
  colors = [
    {
      backgroundColor: ['#26547c', '#ff6b6b', '#ffd166'],
      borderColor: '#111'
    }
  ];
  pieChartType = 'pie';

  ngOnInit() {}
}
