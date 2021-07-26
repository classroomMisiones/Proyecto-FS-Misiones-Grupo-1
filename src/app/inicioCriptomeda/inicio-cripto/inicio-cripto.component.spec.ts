import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InicioCriptoComponent } from './inicio-cripto.component';

describe('InicioCriptoComponent', () => {
  let component: InicioCriptoComponent;
  let fixture: ComponentFixture<InicioCriptoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InicioCriptoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InicioCriptoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
