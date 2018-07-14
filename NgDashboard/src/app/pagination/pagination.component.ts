import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

  @Input() page: number;
  @Input() count: number;
  @Input() perPage: number;
  @Input() pageToShow: number;
  @Input() loading: boolean;

  @Output() goPrev = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit() {
  }

  onPrev(): void {
    this.goPrev.emit(true);
  }
}
