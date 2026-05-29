import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Bmi } from './bmi';

describe('Bmi', () => {
  let component: Bmi;
  let fixture: ComponentFixture<Bmi>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Bmi],
    }).compileComponents();

    fixture = TestBed.createComponent(Bmi);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
