import { Component, OnInit } from '@angular/core';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionCuenta } from '../../models/operacionCuenta.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { Usuario } from '../../models/usuario.model';
import { AlertController } from '@ionic/angular';
import { PersonaService } from '../../servicios/persona/persona.service';


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
  aux: boolean = true;
  idusuarioRealizador: number;
  referencia: string;
  monto: number;
  correopagador: any;

  constructor(
    public _operacionServices: OperacionService,
    public _activatedRoute: ActivatedRoute,
    public _usuarioServices: UsuarioService,
    public _cuentaServices: CuentaService,
    public _personaServices: PersonaService,
    public router: Router,
    public alert: AlertController,
  ) { }

  ngOnInit() {

      this._activatedRoute.paramMap.subscribe(paramMap => {
      const recipeID = paramMap.get('monedero');
      let id: number = +recipeID;
      this.operacion = this._operacionServices.getoperacionCuenta(id);
    });
    
    this.usuario = this._usuarioServices.getUsuario();


    this._cuentaServices.obtenerCuenta(this.usuario.idUsuario).subscribe((data:any) =>{
        console.log(data.length)

        for (let i = 0; i < data.length; i++) {
          const element = data[i];
          console.log(element['_idCuenta'])
          console.log(this.operacion.idCuenta)
          if( element['_idCuenta'] === this.operacion.idCuenta){
          console.log(element);
          this.nroCuenta = element['_numero'];
          }
        }
       console.log(this.nroCuenta)
    });
        
    //});

    // this._usuarioServices.inforUsurio(this.operacion.idUsuarioReceptor)
    //     .subscribe((data: any) => {
    //       this.user = data.usuario;
    //       this.idreceptor = data.idusuario;
    //     });
    // this._usuarioServices.getUserInfo(this.operacion.idUsuarioReceptor).subscribe((data:any) => {
    //   console.log(data);
    // })     
    // this._cuentaServices.infoCuenta(this.operacion.idcuenta)
    //     .subscribe((data: any) => {
    //       this.nroCuenta = data.numero;
    //       this.idusuarioRealizador = data.idusuario;
    //       this._usuarioServices.inforUsurio(this.idusuarioRealizador)
    //           .subscribe((data: any) => {
    //             this.userR = data.usuario;
    //           });
    //     });
    // this._personaServices.getPersona(this.operacion.idUsuarioReceptor)
    //     .subscribe((data: any) => {
    //       if (data) {
    //         this.aux = false;
    //         console.log('estado 2 de aux: ' + this.aux);
    //       }
    //       else {
    //         this.aux = true;
    //         console.log('estado 2 de aux: ' + this.aux);
    //       }
    //     });
    // this.fecha = this.operacion.fecha.split('T', 1 );
  
  }

  SolicitarReintegro() {
    this.reintegroS();
  }

  async reintegroS() {
    var body = {
      idUsuarioSolicitante : this.usuario.idUsuario,
      emailPagador : this.operacion.monto,
      referencia : this.operacion.referencia
    }
    const alertElement = await this.alert.create({
      header: '¿Esta seguro que solicitar reintegro?',
      message: 'Va a solicitar el reintegro de esta operación',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
            console.log(body);
            this._operacionServices.SolicitarReintegroC(body)
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
