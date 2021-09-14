import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-recovery-password',
  templateUrl: './recovery-password.component.html',
  styleUrls: ['./recovery-password.component.css']
})
export class RecoveryPasswordComponent implements OnInit {

  recuperar = new FormGroup({
    recuperarContrasena: new FormControl('', [Validators.required, Validators.email])
  })
  

  constructor() { }

  ngOnInit(): void {
  }

  get recuperarContrasena() {
    return this.recuperar.get('recuperarContrasena')
  }

}
