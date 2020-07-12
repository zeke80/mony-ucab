import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OparecionDetalleRPage } from './oparecion-detalle-r.page';

describe('OparecionDetalleRPage', () => {
  let component: OparecionDetalleRPage;
  let fixture: ComponentFixture<OparecionDetalleRPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OparecionDetalleRPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OparecionDetalleRPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
