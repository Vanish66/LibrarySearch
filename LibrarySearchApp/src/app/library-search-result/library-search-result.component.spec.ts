import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrarySearchResultComponent } from './library-search-result.component';

describe('LibrarySearchResultComponent', () => {
  let component: LibrarySearchResultComponent;
  let fixture: ComponentFixture<LibrarySearchResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LibrarySearchResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibrarySearchResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
