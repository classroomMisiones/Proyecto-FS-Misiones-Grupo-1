import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  registro: FormGroup = new FormGroup({});
    

  constructor(private fb: FormBuilder) {

    this.registro = fb.group({
    usuario: new FormControl('', [Validators.required, Validators.minLength(5)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    contrasena: new FormControl('', [Validators.required, Validators.minLength(5)]),
    repetirContrasena: new FormControl('', [Validators.required, Validators.minLength(5)]),
    nombre: new FormControl('', [Validators.required, Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$'), Validators.minLength(2)]),
    apellido: new FormControl('', [Validators.required, Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$'), Validators.minLength(2)])}, 
    )
   }

  ngOnInit(): void {
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
