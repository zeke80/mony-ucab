import { Component, OnInit, ɵConsole } from '@angular/core';
import { OperacionService } from '../servicios/operacion/operacion.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Usuario } from '../models/usuario.model';
import { UsuarioService } from '../servicios/usuario/usuario.service';
import { CuentaService } from '../servicios/cuenta/cuenta.service';
import { TarjetaService } from '../servicios/tarjeta/tarjeta.service';
import { Platform, NavController, NavParams } from '@ionic/angular';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page implements OnInit{

  cuentas = [];
  cuentasm = [];
  ocuentas = [];
  operaciones = [];
  tarjetas = [];
  otarjetas = [];
  operacionesTarjeta = [];
  monederos = [];
  omonederos = [];
  reintegros = [];
  reintegrose = [];
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
    this.operaciones = this._operacionServices.getoperacionesCuentaVacio();
  
    this.monederos = this._operacionServices.getoperacionesMonederoVacio();
    this.reintegros = this._operacionServices.getreintegrosVacio();
   
    if(this.aux){
    this.operacionesmonedero();
    this.loadTargetOperations();
    this.loadAccountsOperations();
    this.loadReintegrosOperations();
    }
    this.aux=true;
    }

    operacionesmonedero(){
      this.monederos = [];
      this.omonederos = [];

      this._cuentaServices.obtenerCuenta(this.usuario.idUsuario).subscribe((data:any) =>{
        this.monederos = data;
        this.monederos.forEach((monedero)=>{
          if(monedero.infoAdicional._tipoCuenta.idTipoCuenta === 3){
            this._operacionServices.getoperacionesMonedero(this.usuario.idUsuario).subscribe((data:any) =>{
            for (let i = 0; i < data.length; i++) {
              const element = data[i];
              if (element['infoAdicional']['operacionCuenta'] !== null)
              {
                if( element['infoAdicional']['operacionCuenta']['idCuenta'] === monedero._idCuenta){
                 this.omonederos.push(element);
                }
              }
            }
            });
          }
        });
      });
      
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
            console.log("operaciones Tarjetas:",this.otarjetas);
            this._operacionServices.guardarTarjetas(this.otarjetas);
          });
    }
    
    loadAccountsOperations(){
      this.cuentas = [];
      this.ocuentas = [];
      this._cuentaServices.obtenerCuenta(this.usuario.idUsuario).subscribe((data:any) =>{
          this.cuentas = data;
          console.log("cuentas",this.cuentas);
          this.cuentas.forEach((cuenta)=>{
            if(cuenta.infoAdicional._tipoCuenta.idTipoCuenta === 1 || cuenta.infoAdicional._tipoCuenta.idTipoCuenta === 2 ){
              this._operacionServices.getoperacionesCuenta(cuenta._idCuenta).subscribe((data:any) =>{

              for (let opp of data){
              this.ocuentas.push(opp);
              }   
              });
            }
          });
          console.log("Operaciones Cuentas: ",this.ocuentas);
          this._operacionServices.guardarCuentas(this.ocuentas);
      });
    } // EN ESPERA HASTA QUE SE SUBA EL ARREGLO DEL JSON AL SERVER
    loadReintegrosOperations(){
      this._operacionServices.obtenerReintegrosActivos(this.usuario.idUsuario).subscribe((data:any)=>{
      this.reintegros = data;
        console.log("Reintegros solicitados",this.reintegros)
        this._operacionServices.guardarReintegros(this.reintegros);
      });
      this._operacionServices.obtenerReintegrosExitosos(this.usuario.idUsuario).subscribe((data:any)=>{
        this.reintegrose = data;
        console.log("reintregros exitosos",this.reintegrose)
        this._operacionServices.guardarReintegros(this.reintegrose);
      });
    }
    // getAccountsAndLoadOperations(){
    //   this._cuentaServices.obtenerCuenta(this.usuario.idUsuario)
    //   .toPromise().then((data: any) => {
    //     this.cuentas = data;
    //   }).then(()=>this.loadOperations());
    // }

    // loadOperations(){
    //   for(let cuenta of this.cuentas){
    //     this._operacionServices.getoperacionesCuenta(cuenta._idCuenta)
    //     .subscribe((data: any) => {
    //     this.operaciones=data ;
    //     this._operacionServices.guardarCuentas(this.operaciones);
    //     });
    //   }
    // }
}
