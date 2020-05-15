import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SellerBlockUnblockPageComponent } from './seller-block-unblock-page.component';

describe('SellerBlockUnblockPageComponent', () => {
  let component: SellerBlockUnblockPageComponent;
  let fixture: ComponentFixture<SellerBlockUnblockPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SellerBlockUnblockPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SellerBlockUnblockPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
