import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../models/book.model';

@Component({
  selector: 'app-library-search-result',
  templateUrl: './library-search-result.component.html',
  styleUrls: ['./library-search-result.component.css']
})
export class LibrarySearchResultComponent implements OnInit {
  @Input() books: Book[];

  constructor() { }

  ngOnInit(): void {
  }

}
