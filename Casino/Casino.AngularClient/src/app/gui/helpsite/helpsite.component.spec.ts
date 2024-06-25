import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HelpsiteComponent } from './helpsite.component';

describe('HelpsiteComponent', () => {
  let component: HelpsiteComponent;
  let fixture: ComponentFixture<HelpsiteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HelpsiteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HelpsiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
