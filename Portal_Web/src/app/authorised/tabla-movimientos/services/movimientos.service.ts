import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {

  show = false;

  constructor( private http : HttpClient) { }

  consultarCobros(){
    let url = "http://monyucab.somee.com/api/dashboard/CobrosActivos";
    let param = new HttpParams().set('IdUsuario', '2');

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJiYTllYTg2Ni1mMzRlLTQ1Y2QtYmE1Yi00MjI1YjMxZmE5MGMiLCJMb2dnZWRPbiI6IjgvMTMvMjAyMCAzOjE2OjExIEFNIiwibmJmIjoxNTk3MzEzNzcxLCJleHAiOjE1OTczMTY0NzEsImlhdCI6MTU5NzMxMzc3MX0.cAgn6WObfmoJNpMbXR0zC6AGgM4rCbbVFQhJAcutfcM"}); 
    
    return this.http.get(url, {params : param, headers : header});
  }

  
  consultarCuentas(){
    let url = "http://monyucab.somee.com/api/Usuario/operacionesCuentas";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);
    
    return this.http.post(url, {'id' : id});
  }

  consultarTarjeta (){
    let url = "http://monyucab.somee.com/api/Usuario/operacionesTarjetas";
    
    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    return this.http.post(url, {'id' : id});
  }

  consutarMonedero (){
    let url = "http://monyucab.somee.com/api/Usuario/operacionesMonedero"

    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    return this.http.post(url, {'id' : id});
  }


  consultarSaldo(){
    let url = "http://monyucab.somee.com/api/Usuario/saldo"

    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    return this.http.post(url, {'id' : id});
  }

  consutarTodoParam(inicio : string, fin : string){
    let url = "http://monyucab.somee.com/api/Usuario/Filtrartodasoperaciones";

    let user = localStorage.getItem('usuario').toLocaleUpperCase();
  

    let data = {
      headers :  new HttpHeaders ({
        "fechainicio" : inicio,
        "fechafinal" : fin,
        "usuario" : user  
      }) 
    };

    return this.http.get<any>(url, data);
  }


  consutarMonederoParam(inicio : string, fin : string){
    let url = "http://monyucab.somee.com/api/Usuario/FiltraroperacionesMonedero";

    let user = localStorage.getItem('usuario').toLocaleUpperCase();
  

    let data = {
      headers :  new HttpHeaders ({
        "fechainicio" : inicio,
        "fechafinal" : fin,
        "usuario" : user 
      }) 
    };

    console.log(data);

    return this.http.get<any>(url, data);
  }


  
  consultarTarjetaParam(inicio : string, fin : string){
    let url = "http://monyucab.somee.com/api/Usuario/FiltraroperacionesTarjeta";

    let user = localStorage.getItem('usuario').toLocaleUpperCase();
  

    let data = {
      headers :  new HttpHeaders ({
        "fechainicio" : inicio,
        "fechafinal" : fin,
        "usuario" : user 
      }) 
    };

    return this.http.get<any>(url, data);
  }

  
  consultarCuentasParam(inicio : string, fin : string){
    let url = "http://monyucab.somee.com/api/Usuario/FiltraroperacionesCuenta";

    let user = localStorage.getItem('usuario').toLocaleUpperCase();

    let data = {
      headers :  new HttpHeaders ({
        "fechainicio" : inicio,
        "fechafinal" : fin,
        "usuario" : user 
      }) 
    };

    return this.http.get<any>(url, data);
  }
}
