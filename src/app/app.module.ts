import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './usuario/login/login.component';
import { RegistrationFormComponent } from './usuario/registration-form/registration-form.component';

import { VenderCriptoMonedaComponent } from './CriptoMoneda/vender-cripto-moneda/vender-cripto-moneda.component';
import { ModuloPesosComponent } from './Inicio/modulo-pesos/modulo-pesos.component';
import { NavbarComponent } from './navbarFooter/navbar/navbar.component';
import { FooterComponent } from './navbarFooter/footer/footer.component';

import { PerfilUsuarioComponent } from './usuario/perfil-usuario/perfil-usuario.component';

import { TransferirPesosComponent } from './modulo-pesos/transferir-pesos/transferir-pesos.component';
import { UltimasTransferenciasPesosComponent } from './modulo-pesos/ultimas-transferencias-pesos/ultimas-transferencias-pesos.component';
import { InicioCriptoComponent } from './inicioCriptomeda/inicio-cripto/inicio-cripto.component';
import { CompraCriptoComponent } from './compra-cripto/compra-cripto.component';
import { RouterModule, Routes } from '@angular/router';


const appRoutes: Routes = [
  { path: '', component: LoginComponent  },
  { path: 'registro', component: RegistrationFormComponent },
  { path: 'modulopesos', component: ModuloPesosComponent },
  { path: 'modulocripto', component: InicioCriptoComponent },
  { path: 'usuario', component: PerfilUsuarioComponent },
  { path: 'transferirpesos', component: TransferirPesosComponent },
  { path: 'comprarcripto', component: CompraCriptoComponent },
  { path: 'vendercripto', component: VenderCriptoMonedaComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    RegistrationFormComponent,
    LoginComponent,
    VenderCriptoMonedaComponent,
    ModuloPesosComponent,
    NavbarComponent,
    FooterComponent,
    PerfilUsuarioComponent,
    TransferirPesosComponent,
    UltimasTransferenciasPesosComponent,
    InicioCriptoComponent,
    CompraCriptoComponent

  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
  
})

export class AppModule { }
