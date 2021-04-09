import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HeroRESTService } from 'src/app/services/hero-rest.service';

import { HeroDetailsComponent } from './hero-details.component';

describe('HeroDetailsComponent', () => {
  let component: HeroDetailsComponent;
  let fixture: ComponentFixture<HeroDetailsComponent>;

  beforeEach(async () => {
    const stubRoute = {
      queryParams: of('')
    };
    // every component in angular needs a module to exist/be compiled within
    // we'll put it in a special testing module, so that this can be a UNIT test
    await TestBed.configureTestingModule({
      declarations: [HeroDetailsComponent],
      providers: [
        { provide: HeroRESTService, useValue: {} },
        { provide: ActivatedRoute, useValue: stubRoute },
        { provide: Router, useValue: {} },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroDetailsComponent);
    component = fixture.componentInstance;
    // in the tests, the "change detection cycles" don't happen
    // automatically
    fixture.detectChanges();
    // calling that function applies the data binding
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
