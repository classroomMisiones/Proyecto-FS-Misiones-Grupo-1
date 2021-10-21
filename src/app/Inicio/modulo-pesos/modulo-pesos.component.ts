import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PesoService } from 'app/services/peso.service';
import { LoginService } from 'app/services/login.service';


@Component({
  selector: 'app-modulo-pesos',
  templateUrl: './modulo-pesos.component.html',
  styleUrls: ['./modulo-pesos.component.css']
})
export class ModuloPesosComponent implements OnInit {
  listsaldo: any[] = [];
  idUsuario: number | undefined;
  idActual: number | undefined;
  form: FormGroup;
  constructor(private fb: FormBuilder, private _pesoService: PesoService,private _loginService: LoginService) {
    this.form=this.fb.group({
      //Definimos los atributos que queremos traer
      cvv: ['']

    })

    
  }

  ngOnInit(): void {
    

    this.idUsuario = this._loginService.idClienteLogin;
    this.obtener(this.idUsuario);
    
  }

  obtenerTarjetas(){
    this._pesoService.getListpesos().subscribe(data => {
      console.log(data);
      this.listsaldo = data;
      if (this.idUsuario != 0){
        this.idActual = this.idUsuario;
      }
    }, error => {
      console.log(error);
    })
  }
  obtener(id:number){
    this._pesoService.getList(id).subscribe(data =>{
      this.listsaldo = data;
    })
  }
}
