import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book.model';
import { LibrarySearchService } from '../services/library-search.service';

@Component({
  selector: 'app-library-search',
  templateUrl: './library-search.component.html',
  styleUrls: ['./library-search.component.css']
})
export class LibrarySearchComponent implements OnInit {
  books: Book[];

  constructor(protected librarySearchService: LibrarySearchService) { }

  ngOnInit(): void {
  }

  search($event): void {
    this.librarySearchService.getBooks($event.filter, $event.sortOption).subscribe(result => {
      if (!!result && result.length > 0) {
        this.books = result;
      } else {
        this.books = [];
      }
    });
  }

  shouldShowSorting(): boolean {
    return !!this.books && this.books.length > 0;
  }
}
