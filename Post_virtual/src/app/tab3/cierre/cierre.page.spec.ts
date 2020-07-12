import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { CierrePage } from './cierre.page';

describe('CierrePage', () => {
  let component: CierrePage;
  let fixture: ComponentFixture<CierrePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CierrePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(CierrePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
