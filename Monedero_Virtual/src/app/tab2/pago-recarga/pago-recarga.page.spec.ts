import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { PagoRecargaPage } from './pago-recarga.page';

describe('PagoRecargaPage', () => {
  let component: PagoRecargaPage;
  let fixture: ComponentFixture<PagoRecargaPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PagoRecargaPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(PagoRecargaPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
