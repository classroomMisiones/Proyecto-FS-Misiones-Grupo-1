import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

 @Input() registro: boolean = true
 @Input() inicio: boolean = true
 @Input() cripto: boolean = false
 @Input() misaldo: boolean = false
 @Input() usuario: boolean = false
 @Input() salir: boolean = true

  constructor() { }

  ngOnInit(): void {
  }

}
