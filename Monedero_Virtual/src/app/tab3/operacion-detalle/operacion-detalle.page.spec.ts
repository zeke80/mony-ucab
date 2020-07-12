import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OperacionDetallePage } from './operacion-detalle.page';

describe('OperacionDetallePage', () => {
  let component: OperacionDetallePage;
  let fixture: ComponentFixture<OperacionDetallePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperacionDetallePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OperacionDetallePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
