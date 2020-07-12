import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { SolicitudPagoPage } from './solicitud-pago.page';

describe('SolicitudPagoPage', () => {
  let component: SolicitudPagoPage;
  let fixture: ComponentFixture<SolicitudPagoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SolicitudPagoPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(SolicitudPagoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
