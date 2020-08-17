import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { Reintegro } from '../../models/reintegro.model';
import { AlertController } from '@ionic/angular';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { element } from 'protractor';

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
      console.log('ID ' + id);
      this.operacion = this._operacionServices.getreintegro(id);
      console.log("OPERACION " + this.operacion.idUsuarioSolicitante)
      console.log("OPERACION " + this.operacion.idUsuarioReceptor)
      this._usuarioServices.getUserInfo(this.operacion.idUsuarioSolicitante)
          .subscribe((data: any) =>{
         this.userS = data['result']['email']
     });
     this._usuarioServices.getUserInfo(this.operacion.idUsuarioReceptor)
      .subscribe((data: any) => {
        this.userR = data['result']['email'];
      });
    });
    
  }

}
