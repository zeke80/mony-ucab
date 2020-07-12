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
    this._activatedRoute.paramMap.subscribe(paramMap => {
      const recipeID = paramMap.get('operacionID');
      let id: number = +recipeID;
      this.operacion = this._operacionServices.getoperacionTarjeta(id);
    });
    this.usuario = this._usuarioServices.getUsuario();
    this._usuarioServices.inforUsurio(this.operacion.idUsuarioReceptor)
    .subscribe((data: any) => {
      this.userR = data.usuario;
      this.idreceptor = data.idusuario;
    });
    this._tarjetaServices.infoTarjeta(this.operacion.idtarjeta)
        .subscribe((data: any) => {
          console.log(data);
          this.nrotarjeta = data.numero;
          this.idusuarioRealizador = data.idusuario;
          this._usuarioServices.inforUsurio(this.idusuarioRealizador)
              .subscribe((data: any) => {
                this.userS = data.usuario;
              });
        });
    this.fecha = this.operacion.fecha.split('T', 1 );
    this._personaServices.getPersona(this.operacion.idUsuarioReceptor)
    .subscribe((data: any) => {
      if (data) {
        this.aux = false;
      }
      else {
        this.aux = true;
      }
    });

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
