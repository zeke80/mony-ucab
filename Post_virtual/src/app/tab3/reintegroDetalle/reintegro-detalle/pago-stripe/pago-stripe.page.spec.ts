import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { PagoStripePage } from './pago-stripe.page';

describe('PagoStripePage', () => {
  let component: PagoStripePage;
  let fixture: ComponentFixture<PagoStripePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PagoStripePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(PagoStripePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
