import { Injectable } from '@angular/core';
import { Globals } from 'src/app/common/globals';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AdminUsuariosService {

  show: boolean = false;
  readonly baseURI = Globals.API_URL;
  private _refresh = new Subject<void>();
  
  constructor(private http : HttpClient) { }

  get refreshInfo() {
    return this._refresh;
  }

  consultarUsuarios() {
    let url = this.baseURI + "Admin/ConsultaUsuarios";
    let param = new HttpParams().set('query', 'WHERE usuario.estatus = 1');
    let header = new HttpHeaders({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    return this.http.get(url, {params : param, headers : header});
  }

  deleteUsuarios(usuario, idUsuario) {
    let url = this.baseURI + "Admin/EliminarUsuario";
    let param = new HttpParams().set('idUsuario', idUsuario).set('usuario', usuario);
    let header = new HttpHeaders({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    
    return this.http.delete(url, {params : param, headers : header})
          .pipe(
            tap(() => {
              this._refresh.next();
            })
          );
  }
  
}
