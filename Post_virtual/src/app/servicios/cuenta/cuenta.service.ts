import { Injectable } from '@angular/core';
import { Cuenta } from '../../models/cuenta.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {

  cuentas: Cuenta[] = [];

  constructor(private http: HttpClient, private form: FormBuilder) { }



  obtenerTipoCuenta(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    return this.http.get('http://monyucab.somee.com/api/Dashboard/TiposCuentas', {headers: header});
  }

  obtenerBanco(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    return this.http.get('http://monyucab.somee.com/api/Dashboard/Bancos', {headers: header});
  }


  obtenerCuentas(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('idUsuario', localStorage.getItem('idUsuario'));

    return this.http.get('http://monyucab.somee.com/api/Dashboard/cuentas',{params: param, headers: header})
  }


}
