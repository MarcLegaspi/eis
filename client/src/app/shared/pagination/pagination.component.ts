import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {
  @Input() pageIndex: number = 0;
  @Input() pageSize: number = 0;
  @Input() totalCount: number = 0;
  @Output() pageChanged = new EventEmitter<number>();
  
  constructor() { }

  ngOnInit(): void {
  }

  onPageChanged(event: number) {
    this.pageChanged.emit(event);
  }
}
