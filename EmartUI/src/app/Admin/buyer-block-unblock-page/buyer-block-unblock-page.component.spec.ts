import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyerBlockUnblockPageComponent } from './buyer-block-unblock-page.component';

describe('BuyerBlockUnblockPageComponent', () => {
  let component: BuyerBlockUnblockPageComponent;
  let fixture: ComponentFixture<BuyerBlockUnblockPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuyerBlockUnblockPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuyerBlockUnblockPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
