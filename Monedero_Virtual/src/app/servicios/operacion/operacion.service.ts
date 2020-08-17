import { Injectable } from '@angular/core';
import { OperacionCuenta } from '../../models/operacionCuenta.model';
import { OperacionMonedero } from '../../models/operacionMonedero.model';
import { OperacionTarjeta } from '../../models/operacionTarjeta.model';
import { Reintegro } from '../../models/reintegro.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OperacionService {

  operacionesCuenta: OperacionCuenta[] = [
    {
      idOperacionCuenta: 0,
      idCuenta: 0,
      idUsuarioReceptor: 0,
      fecha: '',
      hora: '',
      monto: 0,
      referencia: 0
    }
  ];
  operacionesMonedero: OperacionMonedero[] = [
    {
      idOperacionMonedero: 0,
      idUsuario: 0,
      idTipoOperacion: 0,
      monto: 0,
      fecha: '',
      hora: '',
      referencia: 0
    }
  ];
  operacionesTarjeta: OperacionTarjeta[] = [
    {
      idOperacionTarjeta: 0,
      idUsuarioReceptor: 0,
      idTarjeta: 0,
      fecha: '',
      hora: '',
      monto: 0,
      referencia: 0
    }
  ];

  reintegros: Reintegro[] = [
    {
      idReintegro: 0,
      idUsuarioSolicitante: 0,
      idUsuarioReceptor: 0,
      fecha: '',
      referencia: '',
      referencia_reintegro:'',
      estatus: '',
      monto:0,
    }
  ];

  constructor(
    public http: HttpClient
  ) { }

  getoperacionesCuentaVacio() {

    return [...this.operacionesCuenta];

  }

  getoperacionesMonederoVacio() {

    return [...this.operacionesMonedero];

  }

  getoperacionesTarjetaVacio() {

    return [...this.operacionesTarjeta];

  }

  getreintegrosVacio() {

    return [...this.reintegros];

  }

  guardarCuentas(cuentas: OperacionCuenta[]) {
    this.operacionesCuenta = cuentas;
  }

  guardarTarjetas(tarjeta: OperacionTarjeta[]) {
    this.operacionesTarjeta = tarjeta;
  }

  guardarMonedero(monedero: OperacionMonedero[]) {
    this.operacionesMonedero = monedero;
  }

  guardarReintegros(reintegro: Reintegro[]) {
    this.reintegros = reintegro;
  }

  getoperacionesCuenta(idcuenta: number) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    let url: string = 'http://monyucab.somee.com/api/HistorialOperaciones/HistorialOperacionesCuenta?IdCuenta='+idcuenta;
    return this.http.get(url,{headers: tokenHeader});
  }

  getoperacionesTarjeta(idtarjeta: number) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    let url: string = 'http://monyucab.somee.com/api/HistorialOperaciones/HistorialOperacionesTarjeta?IdTarjeta='+idtarjeta;

    return this.http.get(url,{headers:tokenHeader});
  }

  getoperacionesMonedero(idusuario: number) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    let url: string = 'http://monyucab.somee.com/api/HistorialOperaciones/HistorialOperacionesMonedero?IdUsuario='+idusuario;
    return this.http.get(url,{headers: tokenHeader});
  }

  getoperacionesreintegros(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/infoReintegros';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }


  getoperacionCuenta(monedero: number){
    console.log(this.operacionesCuenta)
    return {
      ...this.operacionesCuenta.find(operacion => {
        return operacion.idOperacionCuenta === monedero;
      })
    };
  }

  getoperacionMonedero(operacionID: number){
    return {
      ...this.operacionesMonedero.find(operacion => {
        return operacion.idOperacionMonedero === operacionID;
      })
    };
  }

  getoperacionTarjeta(operacionID: number){
    return {
      ...this.operacionesTarjeta.find(operacion => {
        return operacion.idOperacionTarjeta === operacionID;
      })
    };
  }

  getreintegro(operacionID: number){
    return {
      ...this.reintegros.find(operacion => {
        return operacion.idReintegro === operacionID;
      })
    };
  }

  // SolicitarReintegro(ref: number) {
  //   let url: string = 'http://monyucab.somee.com/api/Usuario/solicitarReintegro';

  //   let data = {
  //     "referencia": ref
  //   };

  //   return this.http.post(url, data);
  // }

  //Nuevo Back
  
  obtenerReintegrosActivos(idUser) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    return this.http.get('http://monyucab.somee.com/api/dashboard/ReintegrosActivos?IdUsuario='+idUser+'&solicitante=1', {headers: tokenHeader});
  }

  obtenerReintegrosExitosos(idUser) {
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    return this.http.get('http://monyucab.somee.com/api/dashboard/ReintegrosExitosos?IdUsuario='+idUser+'&solicitante=0', {headers: tokenHeader});
  }

  SolicitarReintegro(body){
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
   return this.http.post('http://monyucab.somee.com/api/Transfer/SolicitarReintegro', body, {headers: tokenHeader});
 }


  SolicitarReintegroM(body){
     var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
    return this.http.post('http://monyucab.somee.com/api/Transfer/RealizarReintegroMonedero', body, {headers: tokenHeader});
  }
  SolicitarReintegroT(body){
    var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
   return this.http.post('http://monyucab.somee.com/api/Transfer/RealizarReintegroTarjeta', body, {headers: tokenHeader});
  }
  SolicitarReintegroC(body){
  var tokenHeader = new HttpHeaders({'Authorization': 'Bearer ' +  localStorage.getItem('token')});
  return this.http.post('http://monyucab.somee.com/api/Transfer/RealizarReintegroCuenta', body, {headers: tokenHeader});
  }
}
