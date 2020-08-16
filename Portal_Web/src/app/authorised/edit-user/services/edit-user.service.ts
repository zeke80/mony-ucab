import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { pipe, Subject, BehaviorSubject } from 'rxjs';
import { Globals } from 'src/app/common/globals';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EditUserService {
  
  show = false;
  username = localStorage.getItem('username');
  
  private messageSource = new BehaviorSubject({});
  currentUserData = this.messageSource.asObservable();
  
  constructor(private http : HttpClient) {}

  private _refresh = new Subject<void>();
  readonly baseURI = Globals.API_URL;

  get refreshInfo() {
    return this._refresh;
  }

  editUsuario(userEmail){
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    let param = new HttpParams().set('Usuario', userEmail);
    let url = this.baseURI + "Dashboard/InformacionPersona";

    this.messageSource.next(this.http.get(url, {params : param, headers : header}));
  }

  consultarEstadosCiviles(){  
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    let url = this.baseURI + "Dashboard/EstadosCiviles";
    
    return this.http.get(url, {headers : header});
  }

  modificar(
    nombre : string, 
    apellido : string,
    telefono : string,
    direccion : string,
    razonSocial : string,
    idEstadoCivil : number
    ) {

    let url = this.baseURI + "Authentication/modification";
    let id = parseInt(localStorage.getItem('userIntID'), 10);

    let body = {
    "nombre": nombre,
    "apellido": apellido,
    "telefono":telefono,
    "direccion": direccion,
    "razonSocial": razonSocial,
    "idEstadoCivil": idEstadoCivil,
    "idUsuario": id
    }
    
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    return this.http.post(url,body, {headers : header})
    .pipe(
      tap(() => {
        this._refresh.next();
      })
    );
  }
  
}
