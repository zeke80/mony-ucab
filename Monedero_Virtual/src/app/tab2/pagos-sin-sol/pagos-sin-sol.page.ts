import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PagoService } from '../../servicios/pago/pago.service';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { Usuario } from '../../models/usuario.model';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../../servicios/tarjeta/tarjeta.service';
import { AlertController } from '@ionic/angular';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-pagos-sin-sol',
  templateUrl: './pagos-sin-sol.page.html',
  styleUrls: ['./pagos-sin-sol.page.scss'],
})
export class PagosSinSolPage implements OnInit {


  usuario: Usuario;
  show = true;

  hijo: number;

  constructor(
    public _activatedRoute: ActivatedRoute,
    public _pagoServices: PagoService,
    public _usuarioServices: UsuarioService,
    public _cuentaServices: CuentaService,
    public _tarjetaServices: TarjetaService,
    public router: Router,
    public alert: AlertController

  ) { }

  ngOnInit() {
    this.usuario = this._usuarioServices.getUsuario();
    this.hijo = this._usuarioServices.getHijo();
  }

  realizarSolicitud(f: NgForm) {
    this.show = false;
    var body;

    if (this.hijo != 0 ) {
      body = {
        idUsuarioSolicitante: this.hijo,
        emailPagador: f.value.user,
        monto: f.value.monto,
      };
    } else {
      body = {
        idUsuarioSolicitante: this.usuario.idUsuario,
        emailPagador: f.value.user,
        monto: f.value.monto,
      };
    }

    this._pagoServices.realizarCobro(body)
        .subscribe((data: any) => {
          this.show = true;
          this.router.navigate(['/tabs/cuenta']);
        });

  }

}
