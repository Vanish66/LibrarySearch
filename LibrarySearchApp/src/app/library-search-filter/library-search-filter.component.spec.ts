import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrarySearchFilterComponent } from './library-search-filter.component';

describe('LibrarySearchFilterComponent', () => {
  let component: LibrarySearchFilterComponent;
  let fixture: ComponentFixture<LibrarySearchFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LibrarySearchFilterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibrarySearchFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
