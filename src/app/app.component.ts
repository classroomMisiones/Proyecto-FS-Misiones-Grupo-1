import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent implements OnInit{
  title = 'mymoney';

  registro = true
  inicio = true
  cripto = false
  misaldo = false
  usuario = false
  rutaActual = ""

  constructor(private router: Router) {}

  ngOnInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.determinarEstado(event.url)
      }
    })
  }

  determinarEstado(urlActual: string) {
    switch (urlActual) {
      case '/registro':
        this.registro = false
        this.misaldo = false
        this.cripto = false
        this.usuario = false
        this.inicio = true
        break;
      case '/':
        this.inicio = true
        this.registro = true
        this.cripto = false
        this.misaldo = false
        this.usuario = false
        break;
      case '/modulopesos':
        this.inicio = false
        this.registro = false
        this.cripto = true
        this.usuario = true
        this.misaldo = true
    }
  }
}
