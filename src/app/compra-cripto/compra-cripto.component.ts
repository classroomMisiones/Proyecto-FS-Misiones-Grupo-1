import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-compra-cripto',
  templateUrl: './compra-cripto.component.html',
  styleUrls: ['./compra-cripto.component.css']
})
export class CompraCriptoComponent implements OnInit {

  comprarCripto= new FormGroup({
    //cuentaATransferir: new FormControl('', [Validators.required, Validators.minLength(11)]),
    montoCripto: new FormControl('', [Validators.required, Validators.min(0)])
  })


  constructor() { }

  ngOnInit(): void {
  }

  get montoCripto() {
    return this.comprarCripto.get('montoCripto');
  }

}
