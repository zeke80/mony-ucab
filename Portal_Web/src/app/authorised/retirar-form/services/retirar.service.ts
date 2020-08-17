import { Globals } from './../../../common/globals';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RetirarService {

    show = false;
    readonly baseURI = Globals.API_URL;
    id = localStorage.getItem('userIntID');
    private _refresh = new Subject<void>();
    
  constructor( private http: HttpClient) { }

  getSaldo(){

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 
    let param = new HttpParams().set('idusuario',this.id );
    let url = this.baseURI + "monedero/Consultar";

    return this.http.get(url, {params : param, headers : header});
  }

  get refreshInfo() {
    return this._refresh;
  }

  retirar(idCuenta : number, monto : any){
    let url = this.baseURI + "Monedero/retiro";

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 

    let idUsuario = parseInt(this.id,10);

    let montoInt = parseInt(monto,10);

    let body = {
      "idUsuarioReceptor" : idUsuario,
      "idMedioPaga" : idCuenta,
      "monto" : montoInt,
      "idOperacion" : 0
    }

    return this.http.post(url, body, {headers : header }).pipe(
      tap(() => {
        this._refresh.next();
      })
    );

  }


}
