import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit{
  title = 'mymoney';

  /*↓Estos bools controlan la visibilidad de elementos de la navbar↓*/
  registro = true
  inicio = true
  cripto = false
  misaldo = false
  usuario = false
  salir = false
  rutaActual = ""

  constructor(private router: Router) {}

  ngOnInit() {
    /*↓Escuchamos los eventos que dispara el router↓*/
    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.determinarEstado(event.url)
      }
    })
  }

  /* ↓En función a esos eventos, encendemos o apagamos partes de la navbar↓ */
  determinarEstado(urlActual: string) {
    switch (urlActual) {
      case '/registro':
        this.registro = true
        this.misaldo = false
        this.cripto = false
        this.usuario = false
        this.salir = false
        this.inicio = true
        break;
      case '/':
        this.inicio = true
        this.registro = true
        this.cripto = false
        this.misaldo = false
        this.usuario = false
        this.salir =false
        break;
      case '/modulopesos':
        this.inicio = false
        this.registro = false
        this.cripto = true
        this.usuario = true
        this.misaldo = true
        this.salir = true
    }
  }
}
