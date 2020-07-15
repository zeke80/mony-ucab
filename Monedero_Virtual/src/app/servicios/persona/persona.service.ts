import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Persona } from '../../models/persona.model';
@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  public persona: Persona[] = [
    {
      nombre: '',
      apellido: '',
      fecha_nacimiento: '',
      estadoCivil: ''
    }
  ];

  constructor(
    public http: HttpClient
  ) { }

  getVacio(){
    return this.persona[0];
  }

  getPersona(idusuario: number){
    let url: string = 'http://monyucab.somee.com/api/Usuario/infoPersona';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);

  }
  ajustarPersona(idusuario: number, nombreP:string, apellidoP: string){
    let url: string = 'http://monyucab.somee.com/api/Usuario/ajustarPersona';

    let data = {
      "idUsuario" : idusuario,
      "nombre" : nombreP,
      "apellido" : apellidoP
    };

    return this.http.post(url, data);

  }
}
