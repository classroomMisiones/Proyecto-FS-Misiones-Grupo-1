import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'app/services/login.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  idClienteLogin: number = 0;

  login = new FormGroup({
    email: new FormControl('', [Validators.required]),
    contrasena: new FormControl('', [Validators.required, Validators.minLength(5)])
  })

  constructor(private toastr: ToastrService,
    private _loginService: LoginService,
    private router: Router) { }

  ngOnInit(): void {
  }

  loginConEmailoUsuario() {
    const logincliente: any = {
      email: this.login.get('email')?.value,
      contrasena: this.login.get('contrasena')?.value
    }

    this._loginService.loginConEmailoUsuario(logincliente).subscribe(data => {
      console.log(data);
      if (data == 0) {
        this.toastr.warning("Algún dato es incorrecto, pruebe nuevamente.", "Oops...", {closeButton: true})
      } else {
        this.toastr.success("Ha iniciado sesión exitosamente.", 
      "Sesión Iniciada", {closeButton: true});
      this._loginService.idClienteLogin = data;
      console.log("El valor de idClienteLogin en el Login Service es de: " + this._loginService.idClienteLogin);
      this.login.reset();
      this.router.navigateByUrl('/modulopesos');
      }
    })
  }

  get email() {
    return this.login.get('email')
  }
  get contrasena() {
    return this.login.get('contrasena')
  }

}
