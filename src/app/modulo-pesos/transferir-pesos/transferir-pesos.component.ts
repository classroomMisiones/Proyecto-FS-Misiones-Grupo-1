import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-transferir-pesos',
  templateUrl: './transferir-pesos.component.html',
  styleUrls: ['./transferir-pesos.component.css']
})
export class TransferirPesosComponent implements OnInit {

  transferirPesos = new FormGroup({
    cuentaATransferir: new FormControl('', [Validators.required, Validators.minLength(5)]),
    montoATransferir: new FormControl('', [Validators.required, Validators.min(1)]),
  })
    

  constructor() { }

  ngOnInit(): void {
  }

  get cuentaATransferir() {
  return this.transferirPesos.get('cuentaATransferir');
  }

  get montoATransferir() {
  return this.transferirPesos.get('montoATransferir');
  }

}
