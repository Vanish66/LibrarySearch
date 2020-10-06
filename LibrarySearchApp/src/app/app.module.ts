import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { LibrarySearchComponent } from './library-search/library-search.component';
import { FormsModule } from '@angular/forms';
import { LibrarySearchService } from './services/library-search.service';
import { HttpClientModule } from '@angular/common/http';
import { LibrarySearchFilterComponent } from './library-search-filter/library-search-filter.component';
import { LibrarySearchResultComponent } from './library-search-result/library-search-result.component';

@NgModule({
  declarations: [
    AppComponent,
    LibrarySearchComponent,
    LibrarySearchFilterComponent,
    LibrarySearchResultComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ LibrarySearchService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
