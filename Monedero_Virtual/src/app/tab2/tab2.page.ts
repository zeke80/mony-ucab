import { Component, OnInit } from '@angular/core';
import { CuentaService } from '../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../servicios/tarjeta/tarjeta.service';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { Usuario } from '../models/usuario.model';
import { PagoService } from '../servicios/pago/pago.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginService } from '../servicios/login/login.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page implements OnInit{

  tarjetas = [];
  cuentas = [];
  pagos = [];
  saldo = 0;
  usuario: Usuario;
  user: string;

  constructor(
    public _cuentaServices: CuentaService,
    public _tarjetaService: TarjetaService,
    public _usuarioService: UsuarioService,
    public _pagoServices: PagoService,
    public router: Router,
    public _activatedRoute: ActivatedRoute,
    public _logiServices: LoginService,
    public alert: AlertController
  ) {
    this._activatedRoute.paramMap.subscribe(params => {
      this.ngOnInit();
  });
  }

  ngOnInit(){
    this.user = localStorage.getItem('user');
    this._usuarioService.getUserInfo(this.user)
    .subscribe((data: any) => {
      this._logiServices.login();
      let usuario = new Usuario(data.result.idUsuario, data.result.idTipoUsuario, data.tipoIdentificacion.idTipoIdentificacion,
          data.result.usuario, data.result.fechaRegistro, data.result.nroIdentificacion, data.result.email, data.result.telefono,
          data.result.direccion, data.result.estatus);
      this._usuarioService.guardarUsuario(usuario);
      this.usuario = this._usuarioService.getUsuario();

      this._usuarioService.getSaldo(this.usuario.idUsuario)
          .subscribe((data: any) => {
            this.saldo = data;
          });

      this._tarjetaService.obtenerTarjetas(this.usuario.idUsuario)
          .subscribe((data: any) => {
            this.tarjetas = data;
          });

      this._cuentaServices.obtenerCuenta(this.usuario.idUsuario)
          .subscribe((data: any) => {
            this.cuentas = data;
          });
      this._pagoServices.obtenerSolicitudes(this.usuario.idUsuario)
          .subscribe((data: any) => {
            this.pagos = data;
            this._pagoServices.guardarPago(this.pagos);
          });
    });

  }

  solicitudPago() {
    this.router.navigate(['tabs/cuenta/pagoSinSolicitud']);
  }

  solicitudRetiro() {
    this.router.navigate(['tabs/cuenta/retiro']);
  }

  recarga() {
    this.router.navigate(['tabs/cuenta/recarga']);
  }

  logout() {
    this._logiServices.logout();
    localStorage.setItem('guard', 'false');
    this.router.navigate(['/login']);
  }

  async AlertServer() {
    const alertElement = await this.alert.create({
      header: 'Error inesperado',
      message: 'intentelo mas tarde',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
          }
        },

      ]
    });

    await alertElement.present();

  }

}
