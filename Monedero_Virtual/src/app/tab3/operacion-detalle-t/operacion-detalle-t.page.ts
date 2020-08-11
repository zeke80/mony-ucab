import { Component, OnInit } from '@angular/core';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionTarjeta } from '../../models/operacionTarjeta.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { Usuario } from '../../models/usuario.model';
import { AlertController } from '@ionic/angular';
import { PersonaService } from '../../servicios/persona/persona.service';
import { HttpErrorResponse } from '@angular/common/http';
import { TarjetaService } from '../../servicios/tarjeta/tarjeta.service';

@Component({
  selector: 'app-operacion-detalle-t',
  templateUrl: './operacion-detalle-t.page.html',
  styleUrls: ['./operacion-detalle-t.page.scss'],
})
export class OperacionDetalleTPage implements OnInit {

  operacion: OperacionTarjeta;
  userR: string;
  userS: string;
  nrotarjeta: string;
  idreceptor: number;
  usuario: Usuario;
  idusuarioRealizador: number;
  aux: boolean = true;
  fecha: any;
  tarjetas = [];
  monto: number;
  referencia:string;
  getValue: any;
  getValue1: any;

  constructor(
    public _operacionServices: OperacionService,
    public _activatedRoute: ActivatedRoute,
    public _usuarioServices: UsuarioService,
    public _tarjetaServices: TarjetaService,
    public _personaServices: PersonaService,
    public router: Router,
    public alert: AlertController,
  ) {
   }

  ngOnInit() {
    // this._activatedRoute.paramMap.subscribe(paramMap => {
    //   const recipeID = paramMap.get('operacionID');
    //   let id: number = +recipeID;
    //   this.operacion = this._operacionServices.getoperacionTarjeta(id);
    // });
    this.getValue= this._activatedRoute.snapshot.paramMap.get("idTarjeta")
    this.getValue1= this._activatedRoute.snapshot.paramMap.get("idOperacionTarjeta")
    console.log("Params ", this._activatedRoute.snapshot.paramMap.get("idTarjeta"))
    console.log("Params ", this._activatedRoute.snapshot.paramMap.get("idOperacionTarjeta"))


    this.usuario = this._usuarioServices.getUsuario();
    let routeUrl = this.router.url;
    //console.log(routeUrl);
    let routeSplit = routeUrl.split('/')

    let separator = routeUrl[3].split(';')
    console.log(routeUrl[3])
    //console.log(routeSplit);

  
    // this._operacionServices.getoperacionesTarjeta(1).subscribe(operaciones => {
    //   console.log('Operaciones ', operaciones['length']);
    //   for (let i = 0; i < operaciones['length']; i++) {
    //     const element = operaciones[i];
    //     if (element['idOperacionTarjeta'] === Number(routeSplit[4]))
    //     {
    //       // this._tarjetaServices.obtenerTarjetas(this.usuario.idUsuario).subscribe(
    //       //   (data: any) => {
    //       //     //if ()
    //       //     this.nrotarjeta = data.numero
    //       //     console.log(data)
    //       //   }
    //       // );
    //       console.log(element)
    //       this.fecha = element['fecha'];
    //       this.referencia = element['referencia'];
    //       this.monto = element['monto'];
    //     }
    //   }
    // })
    // console.log(routeSplit[4]);
    // this._usuarioServices.inforUsurio(this.operacion.idUsuarioReceptor)
    // .subscribe((data: any) => {
    //   this.userR = data.usuario;
    //   this.idreceptor = data.idusuario;
    // });

  
    // this._tarjetaServices.infoTarjeta(this.operacion.idtarjeta)
    //     .subscribe((data: any) => {
    //       console.log(data);
    //       this.nrotarjeta = data.numero;
    //       this.idusuarioRealizador = data.idusuario;
    //       this._usuarioServices.inforUsurio(this.idusuarioRealizador)
    //           .subscribe((data: any) => {
    //             this.userS = data.usuario;
    //           });
    //     });
    // this.fecha = this.operacion.fecha.split('T', 1 );
    // this._personaServices.getPersona(this.operacion.idUsuarioReceptor)
    // .subscribe((data: any) => {
    //   if (data) {
    //     this.aux = false;
    //   }
    //   else {
    //     this.aux = true;
    //   }
    // });

  }

  SolicitarReintegro() {
    this.reintegroS();
  }

  async reintegroS() {
    const alertElement = await this.alert.create({
      header: '¿Esta seguro que solicitar reintegro?',
      message: 'Va a solicitar el reintegro de esta operación',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
            this._operacionServices.SolicitarReintegro(this.operacion.referencia )
                .subscribe((data: any) => {
                  this.router.navigate(['/tabs/operaciones']);
                });
          }
        },

        {
          text: 'Cancelar',
          role: 'cancelar'
        }
      ]
    });

    await alertElement.present();

  }

}
