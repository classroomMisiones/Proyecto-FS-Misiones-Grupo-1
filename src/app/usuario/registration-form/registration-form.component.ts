import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { RegistroService } from 'app/services/registro.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ConfirmedValidator } from 'app/usuario/registration-form/ConfirmedValidator';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  registro: FormGroup = new FormGroup({});
    

  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private _registroService: RegistroService,
    private router: Router) {

    this.registro = fb.group({
    usuario: new FormControl('', [Validators.required, Validators.minLength(5)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    contrasena: new FormControl('', [Validators.required, Validators.minLength(5)]),
    repetirContrasena: new FormControl('', [Validators.required, Validators.minLength(5)]),
    nombre: new FormControl('', [Validators.required, Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$'), Validators.minLength(2)]),
    apellido: new FormControl('', [Validators.required, Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$'), Validators.minLength(2)])
  },
    )
    { 
      validator: ConfirmedValidator('password', 'confirm_password')
    }
   }

  ngOnInit(): void {
  }

  agregarCliente() {
    const cliente: any = {
      usuario: this.registro.get('usuario')?.value,
      contrasena: this.registro.get('contrasena')?.value,
      nombre: this.registro.get('nombre')?.value,
      apellido: this.registro.get('apellido')?.value,
      email: this.registro.get('email')?.value
    }
    console.log(cliente);
    this._registroService.registrarCliente(cliente).subscribe(data => {
      this.toastr.success("El registro se ha realizado exitosamente. Puede comenzar a usar su billetera", 
      "Registro exitoso", {closeButton: true});
      this.registro.reset();
      this.router.navigateByUrl('');
    })
  }

  get usuario() {
    return this.registro.get('usuario');
    }
  get email() {
    return this.registro.get('email');
    }
  get contrasena() {
    return this.registro.get('contrasena');
    }
  get repetirContrasena() {
    return this.registro.get('repetirContrasena');
    }
  get nombre() {
    return this.registro.get('nombre');
    }
  get apellido() {
    return this.registro.get('apellido');
    }
}
