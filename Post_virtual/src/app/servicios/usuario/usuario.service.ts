import { Injectable } from '@angular/core';
import { Usuario } from '../../models/usuario.model';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  public usuario: Usuario[] = [
    {
      idUsuario: 0,
      idTipoUsuario: 0,
      idTipoIdentificacion: 0,
      usuario: '',
      fechaRegistro: '',
      nroIdentificacion: 0,
      email: '',
      telefono: '',
      direccion: '',
      estatus: 0

    }
  ];



  constructor(
    public http: HttpClient, private form: FormBuilder
  ) { }

    usuarioModel = this.form.group({
    nombre : ['', Validators.required],
    apellido : ['', Validators.required],
    telefono : ['', Validators.required],
    direccion : ['', Validators.required],
    razonSocial : ['', Validators.required],
    idEstadoCivil : [0, Validators.required],
    idUsuario : [0 , Validators.required]
  });

  /*getUsuario(){
    return this.usuario[0];
  }*/

  /*guardarStorage(usuarioC: Usuario, idUsuario: number, idTipoUsuario: number, usuario: string,
                 fechaRegistro: string, nroIdentificacion: number, email: string, telefono: string, direccion: string ) {

    localStorage.setItem('idUsuario', idUsuario.toString());
    localStorage.setItem('idTipoUsuario', idTipoUsuario.toString());
    localStorage.setItem('usuario', usuario);
    localStorage.setItem('fechaRegistro', fechaRegistro);
    localStorage.setItem('nroIdentificacion', nroIdentificacion.toString());
    localStorage.setItem('email', email);
    localStorage.setItem('telefono', telefono);
    localStorage.setItem('direccion', direccion);

    this.usuario[0] = usuarioC;
  }*/

  getDatosUsuario(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('Usuario', localStorage.getItem('email'));
    let url = "http://localhost:49683/api/Dashboard/InformacionPersona";
    return this.http.get(url, {params: param, headers: header});
  }
  
  

  saldoActual(){
    
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('IdUsuario', localStorage.getItem('idUsuario'));
    let url = "http://localhost:49683/api/monedero/Consultar";
  

    return this.http.get(url, {params: param, headers: header});
  }

  getDatosPerfil(){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    let param = new HttpParams().set('Usuario', localStorage.getItem('email'));
    let url = "http://localhost:49683/api/Dashboard/InformacionPersona";
    return this.http.get(url, {params: param, headers: header});
  }



  modificarUsaurio(usuario: User){
    let header = new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')});
    var body = {
      nombre : usuario.persona.nombre,
      apellido : usuario.persona.apellido,
      telefono : usuario.result.telefono,
      direccion : usuario.result.direccion,
      razonSocial : usuario.comercio.razonSocial,
      idEstadoCivil : Number(usuario.estadoCivil.idEstadoCivil),
      idUsuario: parseInt(localStorage.getItem('idUsuario'))
    };
    return this.http.post('http://localhost:49683/api/Authentication/Modification', body , {headers: header});
  }

 /* inforUsurio(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/infoUsuario';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }

  ajustarUsurio(idusuario: number, usuario:string, di:number, correo:string, telefono:string, direccion:string) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/ajustarUsuario';

    let data = {
      "idUsuario" : idusuario,
      "user" : user,
      "di" : di,
      "email": correo,
      "telf" : telefono,
      "dir" : direccion
    };

    return this.http.post(url, data);
  }

  saldo(idusuario: number) {
    let url: string = 'http://monyucab.somee.com/api/Usuario/saldo';

    let data = {
      "id" : idusuario
    };

    return this.http.post(url, data);
  }*/


}
