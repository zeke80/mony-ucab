import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Pago } from '../../models/pago.model';
import { FormBuilder, Validators } from '@angular/forms';
import { Cobro } from 'src/app/models/cobro.model';

@Injectable({
  providedIn: 'root'
})
export class PagoService {

  public pagos: Pago[] = [
    {
      idpago: 1,
      idusuariosolicitante: 1,
      idusuarioreceptor: 1,
      fechasolicitud: '01/01/2020',
      monto: 0,
      estatus: '1'
    }
  ];


  solicitante = '1';

  constructor(
    public http: HttpClient,private form: FormBuilder
  ) { }

  getVacio() {
    return [...this.pagos];
  }

  guardarPago(pagos: Pago[]) {
    this.pagos = pagos;

  }

  getPagos(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/pagosSolicitadosSolicitante';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }

  getpago(operacionID: number){
    return {
      ...this.pagos.find(operacion => {
        return operacion.idpago === operacionID;
      })
    };
  }

  solicitudPago(id: number, user: string, mont: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/solicitarPago';

    let data = {
      "idUsuarioSolicitante" : id,
      "userReceptor" : user,
      "monto" : mont
    };

    return this.http.post(url, data);
  }

  cobrosActivos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', this.solicitante )
    return this.http.get('http://localhost:49683/api/dashboard/cobrosactivos', {params: param, headers: header})
  }

  cobrosCancelados(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', '1')
    return this.http.get('http://localhost:49683/api/dashboard/CobrosCancelados', {params: param, headers: header})
  }

  cobrosExitosos(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'))
    .set('solicitante', '1')
    return this.http.get('http://localhost:49683/api/dashboard/CobrosExitosos', {params: param, headers: header})
  }

  realizarCobro(cobro: Cobro){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    var body = {
      idUsuarioSolicitante: parseInt(localStorage.getItem('idUsuario')),
      emailPagador: cobro.emailPagador,
      monto: cobro.monto
    }
    console.log(body);
    return this.http.post('http://localhost:49683/api/Transfer/realizarcobro',body, {headers: header});
  }

}
