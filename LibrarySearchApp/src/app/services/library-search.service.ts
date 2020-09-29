import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class LibrarySearchService {

  constructor(protected http: HttpClient) { }

  getBooks(filter: string): Observable<Book[]> {
    return this.http.get<Book[]>('api/LibrarySearch/', {
      params: {
        filter
      }
    });
  }
}
