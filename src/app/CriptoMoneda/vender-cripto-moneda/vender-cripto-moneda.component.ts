import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-vender-cripto-moneda',
  templateUrl: './vender-cripto-moneda.component.html',
  styleUrls: ['./vender-cripto-moneda.component.css']
})
export class VenderCriptoMonedaComponent implements OnInit {

  comprarCripto= new FormGroup({
    //cuentaATransferir: new FormControl('', [Validators.required, Validators.minLength(11)]),
    montoCripto: new FormControl('', [Validators.required, Validators.min(1)])
  })

  constructor() { }

  ngOnInit(): void {
  }

  get montoCripto() {
    return this.comprarCripto.get('montoCripto');
  }

}
