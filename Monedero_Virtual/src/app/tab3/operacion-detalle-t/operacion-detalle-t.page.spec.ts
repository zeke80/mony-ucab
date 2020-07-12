import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OperacionDetalleTPage } from './operacion-detalle-t.page';

describe('OperacionDetalleTPage', () => {
  let component: OperacionDetalleTPage;
  let fixture: ComponentFixture<OperacionDetalleTPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperacionDetalleTPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OperacionDetalleTPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
