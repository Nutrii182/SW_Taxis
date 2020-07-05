import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DataTablesModule } from 'angular-datatables';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './Components/Shared/nav-menu/nav-menu.component';
import { HomeComponent } from './Components/Home/home.component';
import { LoginComponent } from './Components/Usuario/login/login.component';
import { ChoferComponent } from './Components/Chofer/chofer/chofer.component';
import { UnidadComponent } from './Components/Unidad/unidad/unidad.component';
import { PagoComponent } from './Components/Pago/pago/pago.component';
import { FooterComponent } from './Components/Shared/footer/footer.component';
import { RegistroComponent } from './Components/Usuario/registro/registro.component';
import { UsuarioComponent } from './Components/Usuario/usuario/usuario.component';
import { ChoferNuevoComponent } from './Components/Chofer/chofer-nuevo/chofer-nuevo.component';
import { ChoferEditarComponent } from './Components/Chofer/chofer-editar/chofer-editar.component';
import { ChoferDetalleComponent } from './Components/Chofer/chofer-detalle/chofer-detalle.component';
import { UnidadDetalleComponent } from './Components/Unidad/unidad-detalle/unidad-detalle.component';
import { UnidadNuevoComponent } from './Components/Unidad/unidad-nuevo/unidad-nuevo.component';
import { UnidadEditarComponent } from './Components/Unidad/unidad-editar/unidad-editar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ChoferComponent,
    UnidadComponent,
    PagoComponent,
    FooterComponent,
    RegistroComponent,
    UsuarioComponent,
    ChoferNuevoComponent,
    ChoferEditarComponent,
    ChoferDetalleComponent,
    UnidadDetalleComponent,
    UnidadNuevoComponent,
    UnidadEditarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DataTablesModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'registro', component: RegistroComponent },
      { path: 'home', component: HomeComponent },
      { path: 'chofer', component: ChoferComponent },
      { path: 'nuevochofer', component: ChoferNuevoComponent },
      { path: 'editachofer/:id', component: ChoferEditarComponent },
      { path: 'detallechofer/:id', component: ChoferDetalleComponent },
      { path: 'unidad', component: UnidadComponent },
      { path: 'nuevaunidad', component: UnidadNuevoComponent },
      { path: 'editaunidad/:id', component: UnidadEditarComponent },
      { path: 'detalleunidad/:id', component: UnidadDetalleComponent },
      { path: 'pago', component: PagoComponent },
      { path: 'usuario', component: UsuarioComponent },
      { path: '**', pathMatch: 'full', redirectTo: 'login' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
