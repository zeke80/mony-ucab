import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  show = false;
  
  constructor(private http : HttpClient) {}

  private _refresh =new Subject<void>();

  get refreshInfo(){
    return this._refresh;
  }

  consultar(){

    
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJiYTllYTg2Ni1mMzRlLTQ1Y2QtYmE1Yi00MjI1YjMxZmE5MGMiLCJMb2dnZWRPbiI6IjgvMTEvMjAyMCAyOjM4OjM5IEFNIiwibmJmIjoxNTk3MTM4NzE5LCJleHAiOjE1OTcxNDE0MTksImlhdCI6MTU5NzEzODcxOX0.cmJqOvd_pth8tZCH9GXlSkPSYYMoOX7ubq3UZGANRCw"});
    let param = new HttpParams().set('Usuario', 'maria');
    let url ="http://monyucab.somee.com/api/dashboard/InformacionPersona";

    return this.http.get(url, {params : param, headers : header});

  }

  consultarEstadosCiviles(){
    let url = "http://monyucab.somee.com/api/dashboard/EstadosCiviles";
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJiYTllYTg2Ni1mMzRlLTQ1Y2QtYmE1Yi00MjI1YjMxZmE5MGMiLCJMb2dnZWRPbiI6IjgvMTEvMjAyMCAyOjM4OjM5IEFNIiwibmJmIjoxNTk3MTM4NzE5LCJleHAiOjE1OTcxNDE0MTksImlhdCI6MTU5NzEzODcxOX0.cmJqOvd_pth8tZCH9GXlSkPSYYMoOX7ubq3UZGANRCw"});
    return this.http.get(url, {headers : header});
  }

  modificar(nombre : string, 
    apellido : string,
    telefono : string,
    direccion : string,
    razonSocial : string,
    idEstadoCivil : number
    ){
    let url = "http://monyucab.somee.com/api/authentication/modification";

    let id = parseInt(localStorage.getItem('id'),10);

    let body = {
    "nombre": nombre,
    "apellido": apellido,
    "telefono":telefono,
    "direccion": direccion,
    "razonSocial": razonSocial,
    "idEstadoCivil": idEstadoCivil,
    "idUsuario": id
    }

    
    
    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJiYTllYTg2Ni1mMzRlLTQ1Y2QtYmE1Yi00MjI1YjMxZmE5MGMiLCJMb2dnZWRPbiI6IjgvMTEvMjAyMCAyOjM4OjM5IEFNIiwibmJmIjoxNTk3MTM4NzE5LCJleHAiOjE1OTcxNDE0MTksImlhdCI6MTU5NzEzODcxOX0.cmJqOvd_pth8tZCH9GXlSkPSYYMoOX7ubq3UZGANRCw"});
    return this.http.post(url,body, {headers : header})
    .pipe(
      tap(() => {
        this._refresh.next();
      })
    );

  }

}
