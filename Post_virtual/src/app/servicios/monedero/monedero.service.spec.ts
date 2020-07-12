import { TestBed } from '@angular/core/testing';

import { MonederoService } from './monedero.service';

describe('MonederoService', () => {
  let service: MonederoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MonederoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
