import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OperacionDetalleRPage } from './operacion-detalle-r.page';

describe('OperacionDetalleRPage', () => {
  let component: OperacionDetalleRPage;
  let fixture: ComponentFixture<OperacionDetalleRPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperacionDetalleRPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OperacionDetalleRPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
