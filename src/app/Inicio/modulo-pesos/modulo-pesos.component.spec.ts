import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModuloPesosComponent } from './modulo-pesos.component';

describe('ModuloPesosComponent', () => {
  let component: ModuloPesosComponent;
  let fixture: ComponentFixture<ModuloPesosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModuloPesosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModuloPesosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
