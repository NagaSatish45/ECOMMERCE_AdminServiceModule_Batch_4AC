import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSubCategoryPageComponent } from './add-sub-category-page.component';

describe('AddSubCategoryPageComponent', () => {
  let component: AddSubCategoryPageComponent;
  let fixture: ComponentFixture<AddSubCategoryPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddSubCategoryPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSubCategoryPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
