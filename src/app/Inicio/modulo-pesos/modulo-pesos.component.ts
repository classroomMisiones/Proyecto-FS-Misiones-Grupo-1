import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PesoService } from 'app/services/peso.service';


@Component({
  selector: 'app-modulo-pesos',
  templateUrl: './modulo-pesos.component.html',
  styleUrls: ['./modulo-pesos.component.css']
})
export class ModuloPesosComponent implements OnInit {
  listsaldo: any[] = [];

  form: FormGroup;
  constructor(private fb: FormBuilder, private _pesoService: PesoService) {
    this.form=this.fb.group({
      //Definimos los atributos que queremos traer
      cvv: ['']
    })
  }

  ngOnInit(): void {
    this.obtenerTarjetas();
  }

  obtenerTarjetas(){
    this._pesoService.getListpesos().subscribe(data => {
      console.log(data);
      this.listsaldo = data;
    }, error => {
      console.log(error);
    })
  }
  
}
