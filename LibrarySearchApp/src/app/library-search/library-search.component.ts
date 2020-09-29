import { Component, OnInit } from '@angular/core';
import { SortOption } from '../models/enums/sort-option.enum';
import { Book } from '../models/book.model';
import { LibrarySearchService } from '../services/library-search.service';

@Component({
  selector: 'app-library-search',
  templateUrl: './library-search.component.html',
  styleUrls: ['./library-search.component.css']
})
export class LibrarySearchComponent implements OnInit {
  filter = '';
  sortOption: SortOption = SortOption.Relevant;
  books: Book[] = [];

  constructor(protected librarySearchService: LibrarySearchService) { }

  ngOnInit(): void {
  }

  search(): void {
    this.librarySearchService.getBooks(this.filter).subscribe(result => {
      if (!!result && result.length > 0) {
        this.books = result;
        this.sort();
      } else {
        this.books = [];
      }
    });
  }

  sort(): void {
    switch (this.sortOption) {
      case SortOption.Points:
        this.books = this.books.sort((a, b) => b.points - a.points);
        break;
      case SortOption.Relevant:
        this.books = this.books.sort((a, b) => b.relevance - a.relevance);
        break;
    }

  }
}
