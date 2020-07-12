import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {

  show = false;

  constructor( private http : HttpClient) { }

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
