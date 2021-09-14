import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    contrasena: new FormControl('', [Validators.required, Validators.minLength(5)])
  })

  constructor() { }

  ngOnInit(): void {
  }

  get email() {
    return this.login.get('email')
  }
  get contrasena() {
    return this.login.get('contrasena')
  }

}
