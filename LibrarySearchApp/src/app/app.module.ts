import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LibrarySearchComponent } from './library-search/library-search.component';
import { FormsModule } from '@angular/forms';
import { LibrarySearchService } from './services/library-search.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LibrarySearchComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [LibrarySearchService],
  bootstrap: [AppComponent]
})
export class AppModule { }
