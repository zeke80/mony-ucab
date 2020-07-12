import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  show = false;
  
  constructor(private http : HttpClient) {
  }

  consultarUSuario(){
    let url = "http://monyucab.somee.com/api/Usuario/infoUsuario";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);
    
    return this.http.post(url, {'id' : id});

  }

  consultarPersona(){
    let url = "http://monyucab.somee.com/api/Usuario/infoPersona";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);
    
    return this.http.post(url, {'id' : id});

  }

  consultarComercio(){
    let url = "http://monyucab.somee.com/api/Usuario/infoComercio";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);
    
    return this.http.post(url, {'id' : id});

  }

  ajustarPersona(nombre : string, apellido : string){
    let url = "http://monyucab.somee.com/api/Usuario/ajustarPersona";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);
    
    return this.http.post(url, {'idUsuario' : id, 'nombre' : nombre, 'apellido' : apellido});
  }

  ajustarComercio(razonSocial : string, nombre : string, apellido : string){
    let url = "http://monyucab.somee.com/api/Usuario/ajustarComercio";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);
    
    return this.http.post(url, {'idUsuario' : id, 'razonSocial': razonSocial,'nombre' : nombre, 'apellido' : apellido});

  }

  ajustarUsuario(email : string, telefono : string, direccion : string, di : number){
    let url = "http://monyucab.somee.com/api/Usuario/ajustarComercio";

    let id = parseInt(localStorage.getItem('idUsuario'), 10);

    let user = localStorage.getItem('usuario');
    
    return this.http.post(url, {'idUsuario' : id, 'user': user,  'di': di ,'email' : email, 'telf' : telefono, 'dir' : direccion});

  }
}
