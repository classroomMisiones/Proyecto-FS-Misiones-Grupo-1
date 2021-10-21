import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'app/services/login.service';
import { TransferirService } from 'app/services/transferir.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-transferir-pesos',
  templateUrl: './transferir-pesos.component.html',
  styleUrls: ['./transferir-pesos.component.css']
})
export class TransferirPesosComponent implements OnInit {

  idUsuario: number | undefined;

  transferirPesos = new FormGroup({
    usuario: new FormControl('', [Validators.required, Validators.minLength(5)]),
    monto: new FormControl('', [Validators.required, Validators.min(1)]),
  })
    

  constructor(private toastr: ToastrService,
    private _transferirService: TransferirService,
    private _loginService: LoginService,
    private router: Router) { }

  ngOnInit(): void {
    this.idUsuario = this._loginService.idClienteLogin;
  }

  transferirSaldo() {
    const transferencia: any = {
      idCarteraOrigen: this.idUsuario,
      usuarioDestino: this.transferirPesos.get('usuario')?.value,
      monto: this.transferirPesos.get('monto')?.value
    }

    this._transferirService.transferirSaldo(transferencia).subscribe(data => {
      console.log(data);
      console.log(this._loginService.idClienteLogin)
    })
  }

  get usuario() {
  return this.transferirPesos.get('usuario');
  }

  get monto() {
  return this.transferirPesos.get('monto');
  }

}
