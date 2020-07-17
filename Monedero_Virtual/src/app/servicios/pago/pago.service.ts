import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Pago } from '../../models/pago.model';

@Injectable({
  providedIn: 'root'
})
export class PagoService {

  saldo: number;

  public pagos: Pago[] = [
    {
      idpago: 1,
      idusuario_solicitante: 1,
      idusuario_receptor: 1,
      fechasolicitud: '01/01/2020',
      monto: 0,
      estatus: '1'
    },
  ];

  public pagosS: Pago[] = [
    {
      idpago: 1,
      idusuario_solicitante: 1,
      idusuario_receptor: 1,
      fechasolicitud: '01/01/2020',
      monto: 0,
      estatus: '1'
    },
  ];

  constructor(
    public http: HttpClient
  ) { }

  guardarSaldo(sald: number) {
    this.saldo = sald;
  }

  getSaldo() {
    return this.saldo;
  }

  getVacio() {
    return [...this.pagos];
  }

  guardarPago(pagos: Pago[]) {
    this.pagos = pagos;

  }
  guardarPagoSol(pagos: Pago[]) {
    this.pagosS = pagos;

  }

  getPagos(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/pagosSolicitadosReceptor';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }

  getPagosSol(idusuario: number) {
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

  getpagoSol(operacionID: number){
    return {
      ...this.pagosS.find(operacion => {
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

  pagoCuenta(id:number, user: string, mont: number, ref: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/realizarPagoCuenta';

    let data = {
      "idOrigen" : id,
      "usuarioReceptor" : user,
      "monto" : mont,
      "referencia": ref
    };

    return this.http.post(url, data);
  }

  pagoTarjeta(id:number, user: string, mont: number, ref: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/realizarPagoTarjeta';

    let data = {
      "idOrigen" : id,
      "usuarioReceptor" : user,
      "monto" : mont,
      "referencia": ref
    };

    return this.http.post(url, data);
  }

  pagoMonedero(id:number, user: string, mont: number, ref: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/realizarPagoMonedero';

    let data = {
      "idOrigen" : id,
      "usuarioReceptor" : user,
      "monto" : mont,
      "referencia": ref
    };

    return this.http.post(url, data);
  }

  // nuevo back

  recargaTarjeta(body) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    return this.http.post('http://monyucab.somee.com/api/monedero/RecargaMonederoTarjeta', body, {headers: tokenHeader});
  }

  recargaCuenta(body) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    return this.http.post('http://monyucab.somee.com/api/monedero/RecargaMonederoCuenta', body, {headers: tokenHeader});
  }


}
