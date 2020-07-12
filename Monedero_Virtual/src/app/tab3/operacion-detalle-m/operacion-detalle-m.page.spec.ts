import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OperacionDetalleMPage } from './operacion-detalle-m.page';

describe('OperacionDetalleMPage', () => {
  let component: OperacionDetalleMPage;
  let fixture: ComponentFixture<OperacionDetalleMPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperacionDetalleMPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OperacionDetalleMPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
