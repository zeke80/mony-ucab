import { Injectable } from '@angular/core';
import { Globals } from 'src/app/common/globals';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AddFamiliarService {

  show = false;
  
  constructor(private http : HttpClient) { }

  readonly baseURI = Globals.API_URL;

  registrarPersona(
    usuario : string,
    nombre : string,
    apellido : string,
    contra : string,
    email : string,
    telefono : string,
    direccion : string,
    nroIdentificacion : number,
    idUsuarioF : number,
    idTipoUsuario : number,
    idTipoIdentificacion : number,
    idEstadoCivil : number,
    anoNacimiento : number,
    mesNacimiento : number,
    diaNacimiento : number,
    razonSocial : string,
    anoRegistro : number,
    mesRegistro : number,
    diaRegistro : number

  ){

    let url = this.baseURI + "Authentication/RegisterFamiliar";

    let body2 = {
      "usuario": usuario,
      "email": email,
      "password": contra,
      "idUsuarioF": idUsuarioF,
      "idTipoUsuario": idTipoUsuario,
      "idTipoIdentificacion": idTipoIdentificacion,
      "idEstadoCivil": idEstadoCivil,
      "anoRegistro":anoRegistro,
      "mesRegistro":mesRegistro,
      "diaRegistro":diaRegistro,
      "nroIdentificacion": nroIdentificacion,
      "telefono": telefono,
      "direccion": direccion,
      "estatus": 1,
      "comercio": false,
      "nombre": nombre,
      "apellido": apellido,
      "anoNacimiento": anoNacimiento,
      "mesNacimiento": mesNacimiento,
      "diaNacimiento":diaNacimiento,
      "razonSocial": razonSocial
  };
    return this.http.post(url, body2);
  }

}
