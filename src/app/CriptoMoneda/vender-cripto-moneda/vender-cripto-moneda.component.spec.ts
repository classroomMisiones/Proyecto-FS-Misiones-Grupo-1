import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VenderCriptoMonedaComponent } from './vender-cripto-moneda.component';

describe('VenderCriptoMonedaComponent', () => {
  let component: VenderCriptoMonedaComponent;
  let fixture: ComponentFixture<VenderCriptoMonedaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VenderCriptoMonedaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VenderCriptoMonedaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
