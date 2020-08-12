import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OperacionService } from '../../servicios/operacion/operacion.service';
import { OperacionMonedero } from '../../models/operacionMonedero.model';
import { UsuarioService } from '../../servicios/usuario/usuario.service';
import { CuentaService } from '../../servicios/cuenta/cuenta.service';
import { Usuario } from '../../models/usuario.model';
import { AlertController } from '@ionic/angular';
import { PersonaService } from '../../servicios/persona/persona.service';
import { element } from 'protractor';


@Component({
  selector: 'app-operacion-detalle-m',
  templateUrl: './operacion-detalle-m.page.html',
  styleUrls: ['./operacion-detalle-m.page.scss'],
})
export class OperacionDetalleMPage implements OnInit {

  operacion: OperacionMonedero;
  user: string;
  idreceptor: number;
  usuario: Usuario;
  fecha: any;
  aux: boolean = true;
  idtipooperacion: number;
  referencia: string;
  description: string;
  monto: number;
  idoperacionm:number;

  constructor(
    public _activatedRoute: ActivatedRoute,
    public _operacionServices: OperacionService,
    public _usuarioServices: UsuarioService,
    public _cuentaServices: CuentaService,
    public _personaServices: PersonaService,
    public router: Router,
    public alert: AlertController,
  ) { }

  ngOnInit() {
    this.usuario = this._usuarioServices.getUsuario();
    let routeUrl = this.router.url;
    console.log(routeUrl);
    let routeSplit = routeUrl.split('/')
    console.log(routeSplit);
    console.log(routeSplit[4]);

    this._operacionServices.getoperacionesMonedero(this.usuario.idUsuario).subscribe(operaciones => {
      console.log('Operaciones ', operaciones['length']);
      for (let i = 0; i < operaciones['length']; i++) {
        const element = operaciones[i];
        if (element['idOperacionMonedero'] === Number(routeSplit[4]))
        {
          console.log(element)
          this.idtipooperacion = element['infoAdicional']['tipoOperacion']['idTipoOperacion'];
          this.fecha = element['fecha'];
          this.referencia = element['referencia'];
          
          this.description = element['infoAdicional']['tipoOperacion']['descripcion'];
          this.idoperacionm = element['idOperacionMonedero'];
          if (element['infoAdicional']['operacionCuenta'] !== null && element['infoAdicional']['operacionTarjeta'] === null)
          {
            console.log("Tarjeta null");
            this.monto = element['infoAdicional']['operacionCuenta']['monto'];
            this.idreceptor = element['infoAdicional']['operacionCuenta']['idUsuarioReceptor']
            
          }
          else if (element['infoAdicional']['operacionCuenta'] === null && element['infoAdicional']['operacionTarjeta'] !== null)
          {
            console.log("Cuenta null");
            this.monto = element['infoAdicional']['operacionTarjeta']['monto'];
            this.idreceptor = element['infoAdicional']['operacionTarjeta']['idUsuarioReceptor']
          }
        }
      }
    })
  }

  SolicitarReintegro() {
    this.reintegroS();
  }

  async reintegroS() {
    var body = {
      idUsuarioReceptor : this.idreceptor,
      idMedioPaga : 1,
      monto : this.monto,
      idOperacion : this.idoperacionm
    }
    const alertElement = await this.alert.create({
      header: '¿Esta seguro que solicitar reintegro?',
      message: 'Va a solicitar el reintegro de esta operación',
      buttons: [
        {
          text: 'Aceptar',
          handler: () => {
            console.log(body);
            this._operacionServices.SolicitarReintegroM(body)
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
