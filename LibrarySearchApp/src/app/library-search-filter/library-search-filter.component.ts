import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SortOption } from '../models/enums/sort-option.enum';

@Component({
  selector: 'app-library-search-filter',
  templateUrl: './library-search-filter.component.html',
  styleUrls: ['./library-search-filter.component.css']
})
export class LibrarySearchFilterComponent implements OnInit {
  @Input() showSorting = false;
  @Output() filterChanged: EventEmitter<object> = new EventEmitter<object>();

  filter = '';
  sortOption: SortOption = SortOption.Relevant;

  constructor() { }

  ngOnInit(): void {
  }

  filterApplied(): void {
    this.filterChanged.emit({filter: this.filter, sortOption: this.sortOption});
  }
}
