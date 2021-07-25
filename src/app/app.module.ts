import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './usuario/login/login.component';
import { RegistrationFormComponent } from './usuario/registration-form/registration-form.component';

import { VenderCriptoMonedaComponent } from './CriptoMoneda/vender-cripto-moneda/vender-cripto-moneda.component';
import { ModuloPesosComponent } from './Inicio/modulo-pesos/modulo-pesos.component';
import { TransferirPesosComponent } from './modulo-pesos/transferir-pesos/transferir-pesos.component';
import { UltimasTransferenciasPesosComponent } from './modulo-pesos/ultimas-transferencias-pesos/ultimas-transferencias-pesos.component';


@NgModule({
  declarations: [
    AppComponent,
    RegistrationFormComponent,
    LoginComponent,
    VenderCriptoMonedaComponent,
    ModuloPesosComponent,
    TransferirPesosComponent,
    UltimasTransferenciasPesosComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
  
})

export class AppModule { }
