import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pago } from '../../models/pago.model';

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

  constructor(
    public http: HttpClient
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

}
