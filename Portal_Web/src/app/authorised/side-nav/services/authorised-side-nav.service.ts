import { RetirarService } from './../../retirar-form/services/retirar.service';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

import { BloquearService } from './../../bloquear/services/bloquear.service';
import { MovimientosService } from './../../tabla-movimientos/services/movimientos.service';
import { PerfilService } from './../../perfil/services/perfil.service';
import { ProductosService } from './../../productos/services/productos.service';
import { ConfiguracionesService } from './../../configuraciones/services/configuraciones.service';
import { InicioService } from './../../pantalla-inicio/services/inicio.service';
import { LoginService } from './../../../home/login-form/services/login.service';

import { ProductosComponent } from './../../productos/productos.component';
import { AdminUsuariosService } from '../../admin-usuarios/services/admin-usuarios.service';
import { ReportesService } from '../../reportes/services/reportes.service';
import { GrupoFamiliarService } from '../../grupo-familiar/services/grupo-familiar.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorisedSideNavService {
  hideSideNav: boolean = false;
 
  constructor(
    private s_movimientos : MovimientosService,
    private s_bloquear : BloquearService,
    private s_perfil : PerfilService,
    private s_configuraciones : ConfiguracionesService,
    private s_productos : ProductosService,
    private s_inicio : InicioService,
    private s_admin_usuarios : AdminUsuariosService,
    private s_reportes : ReportesService,
    private s_grupo_familiar : GrupoFamiliarService,
    private c_producto : ProductosComponent,
    private router : Router,
    private location: Location,
    private s_login : LoginService,
    private s_retirar : RetirarService
    ) { }
 
  toggleSideNav(): void {
    this.hideSideNav = !this.hideSideNav;
  }

  toggleMovimientos() {
    this.s_movimientos.show = true;

    this.s_grupo_familiar.show = false;
    this.s_retirar.show = false;
    this.s_reportes.show = false;
    this.s_admin_usuarios.show = false;
    this.s_bloquear.show = false;
    this.s_perfil.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();
  }

  toggleBloquear() {
    this.s_bloquear.show = true;

    this.s_admin_usuarios.show = false;
    this.s_retirar.show = false;
    this.s_grupo_familiar.show = false;
    this.s_reportes.show = false;
    this.s_movimientos.show = false;
    this.s_perfil.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();
  }

  togglePerfil() {
    this.s_perfil.username = localStorage.getItem('username');
    this.s_perfil.show = true;

    this.s_admin_usuarios.show = false;
    this.s_retirar.show = false;
    this.s_grupo_familiar.show = false;
    this.s_reportes.show = false;
    this.s_movimientos.show = false;
    this.s_bloquear.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();
  }

  toggleInicio() {
    this.s_inicio.show = true;

    this.s_admin_usuarios.show = false;
    this.s_retirar.show = false;
    this.s_grupo_familiar.show = false;
    this.s_reportes.show = false;
    this.s_movimientos.show = false;
    this.s_bloquear.show = false;
    this.s_perfil.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.c_producto.ocultarProductos();
  }

  toggleConfiguraciones() {
    this.s_configuraciones.show = true;

    this.s_admin_usuarios.show = false;
    this.s_retirar.show = false;
    this.s_grupo_familiar.show = false;
    this.s_reportes.show = false;
    this.s_movimientos.show = false;
    this.s_bloquear.show = false;
    this.s_perfil.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();
  }

  toogleProductos() {
    this.s_productos.show = true;

    this.s_admin_usuarios.show = false;
    this.s_retirar.show = false;
    this.s_grupo_familiar.show = false;
    this.s_reportes.show = false;
    this.s_configuraciones.show = false;
    this.s_movimientos.show = false;
    this.s_bloquear.show = false;
    this.s_perfil.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarAgregar();
    this.c_producto.ngOnInit();
  }

  toggleUsuarios() {
    this.s_admin_usuarios.show = true;

    this.s_retirar.show = false;
    this.s_grupo_familiar.show = false;
    this.s_reportes.show = false;
    this.s_bloquear.show = false;
    this.s_movimientos.show = false;
    this.s_perfil.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();
  }

  toggleReportes() {
    this.s_reportes.show = true;

    this.s_retirar.show = false;
    this.s_grupo_familiar.show = false;
    this.s_admin_usuarios.show = false;
    this.s_bloquear.show = false;
    this.s_movimientos.show = false;
    this.s_perfil.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();
  }

  toggleGrupoFamiliar() {
    this.s_grupo_familiar.show = true;

    this.s_reportes.show = false;
    this.s_retirar.show = false;
    this.s_admin_usuarios.show = false;
    this.s_bloquear.show = false;
    this.s_movimientos.show = false;
    this.s_perfil.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();
  }

  toggleRetirar(){
    this.s_retirar.show = true;

    this.s_grupo_familiar.show = false;
    this.s_reportes.show = false;
    this.s_admin_usuarios.show = false;
    this.s_bloquear.show = false;
    this.s_movimientos.show = false;
    this.s_perfil.show = false;
    this.s_configuraciones.show = false;
    this.s_productos.show = false;
    this.s_inicio.show = false;
    this.c_producto.ocultarProductos();

  }

  logout() {
    this.s_login.logout();
    localStorage.clear();
    this.location.back();
  }
}
