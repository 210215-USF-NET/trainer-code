import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetHeroesComponent } from './get-heroes.component';

describe('GetHeroesComponent', () => {
  let component: GetHeroesComponent;
  let fixture: ComponentFixture<GetHeroesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetHeroesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetHeroesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
