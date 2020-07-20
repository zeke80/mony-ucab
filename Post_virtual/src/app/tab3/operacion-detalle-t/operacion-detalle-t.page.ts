import { Component, OnInit } from '@angular/core';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionTarjeta } from '../../models/operacionTarjeta.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { TarjetaService } from '../../servicios/tarjeta/tarjeta.service';
import { Usuario } from '../../models/usuario.model';

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
  fecha: any;
  idusuarioRealizador: number;

  constructor(
    public _operacionServices: OperacionService,
    public _activatedRoute: ActivatedRoute,
    public _usuarioServices: UsuarioService,
    public _tarjetaServices: TarjetaService
  ) { }

  ngOnInit() {
   /* this._activatedRoute.paramMap.subscribe(paramMap => {
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
    console.log(this.operacion);*/
  }

}
