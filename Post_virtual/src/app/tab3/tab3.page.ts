import { Component, OnInit } from '@angular/core';
import { OperacionService } from '../servicios/operacion/operacion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from '../models/usuario.model';
import { UsuarioService } from '../servicios/usuario/usuario.service';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page implements OnInit{

  cuentas = [];
  tarjetas = [];
  monederos = [];
  reintegros = [];
  usuario: Usuario;
  cont: number = 0;

  constructor(
    public _operacionServices: OperacionService,
    public _usuarioServices: UsuarioService,
    private _activatedRoute: ActivatedRoute,
    public router: Router
  ) {
    this._activatedRoute.paramMap.subscribe(params => {
      this.ngOnInit();
  });
  }

  ngOnInit(){
    this.getData();
  }

  getData() {
    this.cuentas = this._operacionServices.getoperacionesCuentaVacio();
    this.tarjetas = this._operacionServices.getoperacionesTarjetaVacio();
    this.monederos = this._operacionServices.getoperacionesMonederoVacio();
    this.reintegros = this._operacionServices.getreintegrosVacio();
    this.usuario = this._usuarioServices.getUsuario();
    this._operacionServices.getoperacionesCuenta(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.cuentas = data;
          this._operacionServices.guardarCuentas(this.cuentas);
        });
    this._operacionServices.getoperacionesTarjeta(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.tarjetas = data;
          this._operacionServices.guardarTarjetas(this.tarjetas);

        });
    this._operacionServices.getoperacionesMonedero(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.monederos = data;
          this._operacionServices.guardarMonedero(this.monederos);
        });
    this._operacionServices.getoperacionesreintegros(this.usuario.idUsuario)
        .subscribe((data: any) => {
          this.reintegros = data;
          this._operacionServices.guardarReintegros(this.reintegros);
        });
  }

  solicitudPago() {
    this.router.navigate(['tabs/operaciones/pago']);
  }

  cierre() {
    this.router.navigate(['tabs/operaciones/cierre']);
  }

}
