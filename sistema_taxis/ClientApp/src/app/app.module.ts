import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './Components/Shared/nav-menu/nav-menu.component';
import { HomeComponent } from './Components/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { ChoferComponent } from './Components/chofer/chofer.component';
import { UnidadComponent } from './Components/unidad/unidad.component';
import { PagoComponent } from './Components/pago/pago.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ChoferComponent,
    UnidadComponent,
    PagoComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'home', component: HomeComponent },
      { path: 'chofer', component: ChoferComponent },
      { path: 'unidad', component: UnidadComponent },
      { path: 'pago', component: PagoComponent },
      { path: '**', pathMatch: 'full', redirectTo: 'Home' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
