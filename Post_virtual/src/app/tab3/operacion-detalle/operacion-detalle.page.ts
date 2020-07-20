import { Component, OnInit } from '@angular/core';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionCuenta } from '../../models/operacionCuenta.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { Usuario } from '../../models/usuario.model';


@Component({
  selector: 'app-operacion-detalle',
  templateUrl: './operacion-detalle.page.html',
  styleUrls: ['./operacion-detalle.page.scss'],
})
export class OperacionDetallePage implements OnInit {

  operacion: OperacionCuenta;
  user: string;
  userR: string
  nroCuenta: string;
  idreceptor: number;
  usuario: Usuario;
  fecha: any;
  idusuarioRealizador: number;

  constructor(
    public _operacionServices: OperacionService,
    public _activatedRoute: ActivatedRoute,
    public _usuarioServices: UsuarioService,
    public _cuentaServices: CuentaService
  ) { }

  ngOnInit() {

  /*  this._activatedRoute.paramMap.subscribe(paramMap => {
      const recipeID = paramMap.get('operacionID');
      let id: number = +recipeID;
      this.operacion = this._operacionServices.getoperacionCuenta(id);
    });
  //  this.usuario = this._usuarioServices.getUsuario();
 //   this._usuarioServices.inforUsurio(this.operacion.idUsuarioReceptor)
        .subscribe((data: any) => {
          this.user = data.usuario;
          this.idreceptor = data.idusuario;
        });
    this._cuentaServices.infoCuenta(this.operacion.idcuenta)
        .subscribe((data: any) => {
          this.nroCuenta = data.numero;
          this.idusuarioRealizador = data.idusuario;
          this._usuarioServices.inforUsurio(this.idusuarioRealizador)
              .subscribe((data: any) => {
                this.userR = data.usuario;
              });
        });
    this.fecha = this.operacion.fecha.split('T', 1 );*/
  }

}
