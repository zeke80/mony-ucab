import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { Reintegro } from '../../models/reintegro.model';
import { AlertController } from '@ionic/angular';
import { UsuarioService } from '../../servicios/usuario/usuario.service';

@Component({
  selector: 'app-oparecion-detalle-r',
  templateUrl: './oparecion-detalle-r.page.html',
  styleUrls: ['./oparecion-detalle-r.page.scss'],
})
export class OparecionDetalleRPage implements OnInit {

  operacion: Reintegro;
  userS: string;
  userR: string;
  fecha: any;

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
    this.fecha = this.operacion.fecha_solicitud.split('T', 1 );
  }

}
