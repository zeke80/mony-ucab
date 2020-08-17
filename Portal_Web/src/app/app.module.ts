import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, CanActivate } from '@angular/router';
import { DatePipe } from '@angular/common';

import { LoginService } from './home/login-form/services/login.service';
import { AuthorisedSideNavService } from './authorised/side-nav/services/authorised-side-nav.service';
import { MovimientosService } from './authorised/tabla-movimientos/services/movimientos.service';
import { BloquearService } from './authorised/bloquear/services/bloquear.service';
import { PerfilService } from './authorised/perfil/services/perfil.service';
import { ConfiguracionesService } from './authorised/configuraciones/services/configuraciones.service';
import { InicioService } from './authorised/pantalla-inicio/services/inicio.service';
import { RecuperarContrasenaService } from './home/recuperar-contrasena/services/recuperar-contrasena.service';
import { AdminUsuariosService } from './authorised/admin-usuarios/services/admin-usuarios.service';
import { ReportesService } from './authorised/reportes/services/reportes.service';
import { GrupoFamiliarService } from './authorised/grupo-familiar/services/grupo-familiar.service';
import { EstablecerLimiteService } from './authorised/establecer-limite/services/establecer-limite.service';
import { EstablecerComisionService } from './authorised/establecer-comision/services/establecer-comision.service';

import { LoginGuard } from './guard/login.guard';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './home/nav-menu/nav-menu.component';
import { LoginFormComponent } from './home/login-form/login-form.component';
import { SignupFormComponent } from './home/signup-form/signup-form.component';
import { HomeComponent } from './home/home/home.component';
import { SideNavTogglerComponent } from './authorised/side-nav-toggler/side-nav-toggler.component';
import { SideNavComponent } from './authorised/side-nav/side-nav.component';
import { LayoutComponent } from './authorised/layout/layout.component';
import { TopNavComponent } from './authorised/top-nav/top-nav.component';
import { BloquearComponent } from './authorised/bloquear/bloquear.component';
import { TablaMovimientosComponent } from './authorised/tabla-movimientos/tabla-movimientos.component';
import { PerfilComponent } from './authorised/perfil/perfil.component';
import { ConfiguracionesComponent } from './authorised/configuraciones/configuraciones.component';
import { ProductosComponent } from './authorised/productos/productos.component';
import { AgregarTarjetaComponent } from './authorised/agregar-tarjeta/agregar-tarjeta.component';
import { AgregarCuentaComponent } from './authorised/agregar-cuenta/agregar-cuenta.component';
import { PantallaInicioComponent } from './authorised/pantalla-inicio/pantalla-inicio.component';
import { RecuperarContrasenaComponent } from './home/recuperar-contrasena/recuperar-contrasena.component';
import { ReportesComponent } from './authorised/reportes/reportes.component';
import { AdminUsuariosComponent } from './authorised/admin-usuarios/admin-usuarios.component';
import { GrupoFamiliarComponent } from './authorised/grupo-familiar/grupo-familiar.component';
import { RetirarFormComponent } from './authorised/retirar-form/retirar-form.component';
import { RetirarService } from './authorised/retirar-form/services/retirar.service';
import { AddFamiliarComponent } from './authorised/add-familiar/add-familiar.component';
import { AddFamiliarService } from './authorised/add-familiar/services/add-familiar.service';
import { EditUserComponent } from './authorised/edit-user/edit-user.component';
import { ResetPasswordComponent } from './authorised/reset-password/reset-password.component';
import { OpcionesAdminComponent } from './authorised/opciones-admin/opciones-admin.component';
import { EstablecerLimiteComponent } from './authorised/establecer-limite/establecer-limite.component';
import { EstablecerComisionComponent } from './authorised/establecer-comision/establecer-comision.component';
import { ResetPasswordService } from './authorised/reset-password/services/reset-password.service';
import { EditUserService } from './authorised/edit-user/services/edit-user.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginFormComponent,
    SignupFormComponent,
    HomeComponent,
    SideNavTogglerComponent,
    SideNavComponent,
    LayoutComponent,
    TopNavComponent,
    BloquearComponent,
    TablaMovimientosComponent,
    PerfilComponent,
    ConfiguracionesComponent,
    ProductosComponent,
    AgregarTarjetaComponent,
    AgregarCuentaComponent,
    PantallaInicioComponent,
    RecuperarContrasenaComponent,
    ReportesComponent,
    AdminUsuariosComponent,
    GrupoFamiliarComponent,
    AddFamiliarComponent,
    EditUserComponent,
    ResetPasswordComponent,
    RetirarFormComponent,
    AddFamiliarComponent,
    OpcionesAdminComponent,
    EstablecerLimiteComponent,
    EstablecerComisionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'sign-up', component: SignupFormComponent },
      { path: 'login', component: LoginFormComponent },
      { path: 'dashboard', component: LayoutComponent, canActivate : [LoginGuard] },
      { path: 'recuperar-contrasena', component: RecuperarContrasenaComponent },
      { path: 'pw-reset/:userID/:resetPasswordToken', component: ResetPasswordComponent }
    ])
  ],
  providers: [
    LoginService, 
    AuthorisedSideNavService,
    MovimientosService,
    BloquearService,
    PerfilService,
    ConfiguracionesService, 
    InicioService,
    RecuperarContrasenaService,
    DatePipe,
    ProductosComponent, 
    LoginGuard,
    AdminUsuariosService,
    ReportesService,
    GrupoFamiliarService,
    RetirarService,
    AddFamiliarService,
    EstablecerComisionService,
    EstablecerLimiteService,
    ResetPasswordService,
    EditUserService,
    InicioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
