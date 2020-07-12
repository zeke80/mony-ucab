import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { Reintegro } from '../../models/reintegro.model';
import { AlertController } from '@ionic/angular';
import { UsuarioService } from '../../servicios/usuario/usuario.service';


@Component({
  selector: 'app-operacion-detalle-r',
  templateUrl: './operacion-detalle-r.page.html',
  styleUrls: ['./operacion-detalle-r.page.scss'],
})
export class OperacionDetalleRPage implements OnInit {

  operacion: Reintegro;
  userS: string;
  userR: string;

  constructor(
    public _activatedRoute: ActivatedRoute,
    public _operacionServices: OperacionService,
    public alert: AlertController,
    public router: Router,
    public _usuarioServices: UsuarioService
  ) { }

  ngOnInit() {
    this._activatedRoute.paramMap.subscribe(paramMap => {
      const recipeID = paramMap.get('operacionID');
      let id: number = +recipeID;
      this.operacion = this._operacionServices.getreintegro(id);

    });
    this._usuarioServices.inforUsurio(this.operacion.idusuario_solicitante)
        .subscribe((data: any) => {
          this.userS = data.usuario;
        });
    this._usuarioServices.inforUsurio(this.operacion.idusuario_receptor)
    .subscribe((data: any) => {
      this.userR = data.usuario;
    });
  }

  async aceptarReintegro() {
    const alertElement = await this.alert.create({
      header: '¿Esta seguro que quiere aceptar?',
      message: 'Va a aceptar el reintegro de la operacion',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
            this._operacionServices.aceptarReintegro(this.operacion.idreintegro)
                .subscribe((data: any) => {
                  this.router.navigate(['/tabs/operaciones']);
                });
          }
        },
        {
          text: 'Denegar',
          handler: () => {
            this._operacionServices.recharzarReintegro(this.operacion.idreintegro)
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
