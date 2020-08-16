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
import {Tarjeta} from '../models/tarjeta.model';
import { Cuenta } from '../models/cuenta.model';
import { CobroActivo } from '../models/CobroActivo.model';
import { Cobro } from '../models/cobro.model';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page implements OnInit {

  cuentas: Cuenta[] = [];
  pagos = [];
  saldo = 0;
  usuario: Usuario;
  tarjetas: Tarjeta[]= [];
  banco: {} = {}; 
  cobrosCancelados: Cobro[]= [];
  cobrosExitosos: Cobro[]= [];

  cobrosActivos: CobroActivo[] = [];

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
      //this.ngOnInit();
  });
  }

  

  ngOnInit(){
    this._usuarioService.getDatosUsuario()
    .subscribe(
    (data: any) =>
    {
      
      localStorage.setItem('idUsuario', data.result.idUsuario);
      localStorage.setItem('usuario', data.result.usuario);
      localStorage.setItem('nombreU', data.persona.nombre);
      localStorage.setItem('apellido', data.persona.apellido);
      console.log(localStorage.getItem('idUsuario'));
      console.log(localStorage.getItem('usuario'));
      console.log(localStorage.getItem('nombreU'));
      console.log(localStorage.getItem('apellido'));
      },
      err => {
        console.log(err.message);
      }
    )

    this._usuarioService.saldoActual().subscribe(
      (res: any)=>{
        this.saldo = res;
      },
      (err:any)=>{

      }
    );

  this._tarjetaService.obtenerTarjetas().subscribe(
    (res: any)=>{
      
      this.tarjetas = res;
      //console.log(this.tarjetas); 
    },
    (err:any)=>{
      
    }
    );

    this._cuentaServices.obtenerCuentas().subscribe(
      (data: any) =>{
        this.banco = data;
        localStorage.setItem('idCuentaMonedero',this.banco[0]._idCuenta);
        //console.log(localStorage.getItem('idCuentaMonedero'));
        this.cuentas = data;
        //console.log(data);
      }
    );

    this._pagoServices.cobrosActivos().subscribe(
      (data: any) =>{
        this.cobrosActivos = data;
        console.log(data);
      }
    );

    this._pagoServices.cobrosCancelados().subscribe(
      (data: any) =>{
         this.cobrosCancelados= data;
         
      }
    );

    this._pagoServices.cobrosExitosos().subscribe(
      (data: any) =>{
         this.cobrosExitosos= data;
         
      }
    );

  } //final del ngoninit



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
  
//OPCION 1 DE REFRESH
   /*onRefresh(){
    this._usuarioService.getDatosUsuario()
    .subscribe(
    (data: any) =>
    {
      
      localStorage.setItem('idUsuario', data.result.idUsuario);
      localStorage.setItem('usuario', data.result.usuario);
      localStorage.setItem('nombreU', data.persona.nombre);
      localStorage.setItem('apellido', data.persona.apellido);
      console.log(localStorage.getItem('idUsuario'));
      console.log(localStorage.getItem('usuario'));
      console.log(localStorage.getItem('nombreU'));
      console.log(localStorage.getItem('apellido'));
      },
      err => {
        console.log(err.message);
      }
    )

    this._usuarioService.saldoActual().subscribe(
      (res: any)=>{
        this.saldo = res;
      },
      (err:any)=>{

      }
    );

  this._tarjetaService.obtenerTarjetas().subscribe(
    (res: any)=>{
      
      this.tarjetas = res;
      //console.log(this.tarjetas); 
    },
    (err:any)=>{
      
    }
    );

    this._cuentaServices.obtenerCuentas().subscribe(
      (data: any) =>{
        //this.banco = data;
        //localStorage.setItem('idCuentaMonedero',this.banco[0]._idCuenta);
        //console.log(localStorage.getItem('idCuentaMonedero'));
        //this.cuentas = data;
        //console.log(data);
      }
    );

    this._pagoServices.cobrosActivos().subscribe(
      (data: any) =>{
        this.cobrosActivos = data;
        //console.log(data);
      }
    );

    this._pagoServices.cobrosCancelados().subscribe(
      (data: any) =>{
         this.cobrosCancelados= data;
         
      }
    );

    this._pagoServices.cobrosExitosos().subscribe(
      (data: any) =>{
         this.cobrosExitosos= data;
         
      }
    );
  }*/

  async onClick(idPago){
  
    const alert = await this.alert.create({
      header: 'Cancelar',
      message: '¿Desea cancelar este cobro?',
      buttons: [
        {
          text: 'Cancelar',
          role: 'cancel',
          cssClass: 'secondary',
        },
        {
          text: 'Aceptar',
          handler: () => {
            
            this._pagoServices.cancelarCobro(idPago)
            .subscribe(
              (data: any) =>
              {
                
                //this.successToast('success', 'Cobro cancelado satisfactoriamente')
                console.log(data);
                //this.router.navigate(['/post']);
              },
              err =>{
                console.log(err);
                
                //this.presentToast('danger', 'Ha ocurrido un error al cancelar el cobro');
              }
            );         
          }
        }
      ]
    });
    await alert.present();
  }

  
  //OPCION 2 DE REFRESH

  ionViewWillEnter(){
    this._usuarioService.getDatosUsuario()
    .subscribe(
    (data: any) =>
    {
      
      localStorage.setItem('idUsuario', data.result.idUsuario);
      localStorage.setItem('usuario', data.result.usuario);
      localStorage.setItem('nombreU', data.persona.nombre);
      localStorage.setItem('apellido', data.persona.apellido);
      console.log(localStorage.getItem('idUsuario'));
      console.log(localStorage.getItem('usuario'));
      console.log(localStorage.getItem('nombreU'));
      console.log(localStorage.getItem('apellido'));
      },
      err => {
        console.log(err.message);
      }
    )

    this._usuarioService.saldoActual().subscribe(
      (res: any)=>{
        this.saldo = res;
      },
      (err:any)=>{

      }
    );

  this._tarjetaService.obtenerTarjetas().subscribe(
    (res: any)=>{
      
      this.tarjetas = res;
      //console.log(this.tarjetas); 
    },
    (err:any)=>{
      
    }
    );

    this._cuentaServices.obtenerCuentas().subscribe(
      (data: any) =>{
        this.banco = data;
        localStorage.setItem('idCuentaMonedero',this.banco[0]._idCuenta);
        //console.log(localStorage.getItem('idCuentaMonedero'));
        this.cuentas = data;
        //console.log(data);
      }
    );

    this._pagoServices.cobrosActivos().subscribe(
      (data: any) =>{
        this.cobrosActivos = data;
        console.log(data);
      }
    );

    this._pagoServices.cobrosCancelados().subscribe(
      (data: any) =>{
         this.cobrosCancelados= data;
         
      }
    );

    this._pagoServices.cobrosExitosos().subscribe(
      (data: any) =>{
         this.cobrosExitosos= data;
         
      }
    );
  }

  
}
