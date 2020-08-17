import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ReintegroDetallePage } from './reintegro-detalle.page';

describe('ReintegroDetallePage', () => {
  let component: ReintegroDetallePage;
  let fixture: ComponentFixture<ReintegroDetallePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReintegroDetallePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ReintegroDetallePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
