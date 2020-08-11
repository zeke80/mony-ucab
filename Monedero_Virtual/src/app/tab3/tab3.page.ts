import { Component, OnInit } from '@angular/core';
import { OperacionService } from '../servicios/operacion/operacion.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Usuario } from '../models/usuario.model';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { CuentaService } from '../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../servicios/tarjeta/tarjeta.service';
import { Platform, NavController, NavParams } from '@ionic/angular';
//import {  } from 'ionic-angular';
//import {  } from 'ionic-angular';
//import { type } from 'os';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page implements OnInit{

  cuentas = [];
  ocuentas = [];
  operaciones = [];
  tarjetas = [];
  otarjetas = [];
  operacionesTarjeta = [];
  monederos = [];
  reintegros = [];
  usuario: Usuario
  public navParams = new NavParams();
  aux = false;

  constructor(
    public _tarjetaService: TarjetaService,
    public _cuentaServices: CuentaService,
    public _operacionServices: OperacionService,
    public router: Router,
    public _usuarioServices: UsuarioService,
    private _activatedRoute: ActivatedRoute,
    public navCtrl: NavController

  ) {
    this._activatedRoute.paramMap.subscribe(params => {
      this.ngOnInit();
  });
  }
  

  ngOnInit(){
    this.usuario = this._usuarioServices.getUsuario();
    //this.operaciones = this._operacionServices.getoperacionesCuentaVacio();
  
    //this.monederos = this._operacionServices.getoperacionesMonederoVacio();
    this.reintegros = this._operacionServices.getreintegrosVacio();
   
    if(this.aux){
    this.getAccountsAndLoadOperations();
    this.loadMonederoperations();
    //this.getTargetsAndLoadTargetOperations();
    this.loadTargetOperations();
    this.loadAccountsOperations();
    }
    this.aux=true;
    }

    loadMonederoperations(){
      this._operacionServices.getoperacionesMonedero(this.usuario.idUsuario)
      .toPromise().then((data: any )=>{
        this.monederos = data;
      }).then(()=>this.cleanMonederoOperations());
    } //carga de operaciones monedero
    isNotClosingOperation(monedero){
      return monedero.infoAdicional.tipoOperacion.idTipoOperacion !== 4;
    }

    cleanMonederoOperations(){
      this.monederos = this.monederos.filter(this.isNotClosingOperation);
    }

    loadTargetOperations(){
      this.tarjetas = [];
      this.otarjetas = [];
      this._tarjetaService.obtenerTarjetas(this.usuario.idUsuario)
          .subscribe((data: any) => {
            this.tarjetas = data;
            this.tarjetas.forEach((tarjeta)=>{
              this._operacionServices.getoperacionesTarjeta(tarjeta.idTarjeta).subscribe(
                (data: any) => { 
                  for (let opp of data) {
                    this.otarjetas.push(opp);
                  }   
                },
                error => {
                 console.log("Error en subscribe")
                });
            }); 
          });
    }

    public test(event , otarjeta ){
      // this.navCtrl. push(page2,{
      // item:item
      // });
      this.router.navigate(['/tabs/operaciones/tarjeta/', { idTarjeta: otarjeta['idTarjeta'], idOperacionTarjeta: otarjeta['idOperacionTarjeta']}])
    } // pasar informacion de una page a otra

    loadAccountsOperations(){
      this.cuentas = [];
      this.ocuentas = [];
      this._cuentaServices.obtenerCuenta(this.usuario.idUsuario).subscribe((data:any) =>{
          this.cuentas = data;
          console.log("cuentas",this.cuentas);
          this.cuentas.forEach((cuenta)=>{
            this._operacionServices.getoperacionesCuenta(cuenta._idCuenta).subscribe((data:any) =>{
            for (let opp of data){
              this.ocuentas.push(opp);
            }
            });
          });
          console.log("Operaciones Cuentas: ",this.ocuentas);
      });
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
