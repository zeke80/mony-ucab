import { Component, OnInit } from '@angular/core';
import { OperacionService } from '../servicios/operacion/operacion.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Usuario } from '../models/usuario.model';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { CuentaService } from '../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../servicios/tarjeta/tarjeta.service';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page implements OnInit{

  cuentas = [];
  operaciones = [];
  tarjetas = [];
  operacionesTarjeta = [];
  monederos = [];
  reintegros = [];
  usuario: Usuario

  constructor(
    public _tarjetaService: TarjetaService,
    public _cuentaServices: CuentaService,
    public _operacionServices: OperacionService,
    public router: Router,
    public _usuarioServices: UsuarioService,
    private _activatedRoute: ActivatedRoute,

  ) {
    this._activatedRoute.paramMap.subscribe(params => {
      this.ngOnInit();
  });
  }

  ngOnInit(){
    this.operaciones = this._operacionServices.getoperacionesCuentaVacio();
    this.tarjetas = this._operacionServices.getoperacionesTarjetaVacio();
    this.monederos = this._operacionServices.getoperacionesMonederoVacio();
    this.reintegros = this._operacionServices.getreintegrosVacio();
    this.usuario = this._usuarioServices.getUsuario();
    this.getAccountsAndLoadOperations();
    this.loadMonederoperations();
    this.getTargetsAndLoadTargetOperations();
    }

    loadTargetOperations(){
      this.tarjetas.forEach((tarjeta)=>{
        this._operacionServices.getoperacionesTarjeta(tarjeta.idTarjeta)
        .toPromise().then((data:any)=>this.operacionesTarjeta = data)
        .catch(()=>console.log('Usurio no posee tarjetas.'));
      });
    }

    getTargetsAndLoadTargetOperations(){
      this._tarjetaService.obtenerTarjetas(this.usuario.idUsuario)
      .toPromise().then((data: any) => {
        this.tarjetas = data;
        }).then(()=>this.loadTargetOperations());
    }

    loadMonederoperations(){
      this._operacionServices.getoperacionesMonedero(this.usuario.idUsuario)
      .toPromise().then((data: any )=>{
        this.monederos = data;
      })
    }

    getAccountsAndLoadOperations(){
      this._cuentaServices.obtenerCuenta(this.usuario.idUsuario)
      .toPromise().then((data: any) => {
        this.cuentas = data;
      }).then(()=>this.loadOperations());
    }

    loadOperations(){
      for(let cuenta of this.cuentas){
        this._operacionServices.getoperacionesCuenta(cuenta._idCuenta)
        .subscribe((data: any) => {
        this.operaciones=data ;
        this._operacionServices.guardarCuentas(this.operaciones);
        });
      }
    }
}
