import { Injectable } from '@angular/core';
import { Cuenta } from '../../models/cuenta.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {

  cuentas: Cuenta[] = [
    {
      idCuenta: 0,
      idUsuario: 0,
      idTipoCuenta: 0,
      idBanco: 0,
      numero: '00000'
    }
  ];

  constructor(
    public http: HttpClient
  ) { }

  getVacio() {

    return [...this.cuentas];

  }

  getCuentas(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/infoCuentas';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }

  infoCuenta(idcuenta: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/infoCuenta';

    let data = {
      "id" : idcuenta
    };

    return this.http.post(url, data);
  }

  obtenerCuenta(usuarioID) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    return this.http.get('http://monyucab.somee.com/api/dashboard/Cuentas?IdUsuario=' + usuarioID, {headers: tokenHeader});
  }

}
