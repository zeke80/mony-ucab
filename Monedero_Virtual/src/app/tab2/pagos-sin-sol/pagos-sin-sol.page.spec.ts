import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { PagosSinSolPage } from './pagos-sin-sol.page';

describe('PagosSinSolPage', () => {
  let component: PagosSinSolPage;
  let fixture: ComponentFixture<PagosSinSolPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PagosSinSolPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(PagosSinSolPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
