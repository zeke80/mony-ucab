import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { PagoPaypalPage } from './pago-paypal.page';

describe('PagoPaypalPage', () => {
  let component: PagoPaypalPage;
  let fixture: ComponentFixture<PagoPaypalPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PagoPaypalPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(PagoPaypalPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
