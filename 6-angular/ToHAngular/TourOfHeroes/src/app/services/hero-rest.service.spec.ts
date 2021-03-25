import { TestBed } from '@angular/core/testing';

import { HeroRESTService } from './hero-rest.service';

describe('HeroRESTService', () => {
  let service: HeroRESTService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HeroRESTService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
