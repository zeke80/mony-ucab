import { Component, OnInit } from '@angular/core';
import { CuentaService } from '../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../servicios/tarjeta/tarjeta.service';
import { Usuario } from '../models/usuario.model';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { PagoService } from '../servicios/pago/pago.service';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../servicios/login/login.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page implements OnInit {

  cuentas = [];
  tarjetas = [];
  pagos = [];
  saldo = 0;
  usuario: Usuario

  constructor(
    public _cuentaServices: CuentaService,
    public _tarjetaService: TarjetaService,
    public _usuarioService: UsuarioService,
    public _pagoServices: PagoService,
    public _activatedRoute: ActivatedRoute,
    public _logiServices: LoginService,
    public router: Router,
    public alert: AlertController
  ) {
    this._activatedRoute.paramMap.subscribe(params => {
      this.ngOnInit();
  });
  }

  ngOnInit(){
    this.usuario = this._usuarioService.getUsuario();

    this.cuentas = this._cuentaServices.getVacio();
    this._cuentaServices.getCuentas(this.usuario.idUsuario)
         .subscribe((data: any) => {
           this.cuentas = data;
         });
    this.tarjetas = this._tarjetaService.getVacio();
    this._tarjetaService.getTarjetas(this.usuario.idUsuario)
         .subscribe((data: any) => {
           this.tarjetas = data;
         });
    this.pagos = this._pagoServices.getVacio();
    this._pagoServices.getPagos(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.pagos = data;
          this._pagoServices.guardarPago(this.pagos);
        });
    this._usuarioService.saldo(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.saldo = data;
          console.log(this.saldo);
        },
        (error: HttpErrorResponse) => {
            this.AlertServer();
        });
  }

  logout() {
    this._logiServices.logout();
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
