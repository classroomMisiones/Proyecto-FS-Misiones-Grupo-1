import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-modulo-pesos',
  templateUrl: './modulo-pesos.component.html',
  styleUrls: ['./modulo-pesos.component.css']
})
export class ModuloPesosComponent implements OnInit {
  listsaldo: any[] = [
    {moneda: 'Pesos', operacion: 'Tranferencia', monto:'50', fecha: "10/12"},
    {moneda: 'Pesos', operacion: 'Recibiste', monto:'50', fecha: "7/12"},
    {moneda: 'Pesos', operacion: 'Ingresaste', monto:'50', fecha: "8/12"},
  ];

  form: FormGroup;
  constructor(private fb: FormBuilder) {
    this.form=this.fb.group({
      //Definimos los atributos que queremos traer
      cvv: ['']
    })
  }

  ngOnInit(): void {
  }

  
}
