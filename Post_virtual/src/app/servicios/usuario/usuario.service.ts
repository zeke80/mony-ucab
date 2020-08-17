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


}
