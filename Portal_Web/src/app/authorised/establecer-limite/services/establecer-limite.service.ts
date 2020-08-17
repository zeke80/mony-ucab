import { Injectable } from '@angular/core';
import { Globals } from './../../../common/globals';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EstablecerLimiteService {

  show = false;
  private _refresh = new Subject<void>();
  readonly baseURI = Globals.API_URL;
  id = localStorage.getItem('userIntID');

  constructor( private http : HttpClient) { }

  get refreshInfo() {
    return this._refresh;
  }

  setLimite(limite : string, idParametro : number){
    let url = this.baseURI + "Admin/EstablecerLimiteParametro";

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 

    let body = {
      "limite" : limite,
      "idParametro" : idParametro
    };

    return this.http.post(url,body, {headers : header})
    .pipe(
      tap(() => {
        this._refresh.next();
      })
    );
  }

  getParametro(){
    let url = this.baseURI + "dashboard/Parametros";

    let header = new HttpHeaders ({'Authorization' : 'Bearer ' + localStorage.getItem('token')}); 

    return this.http.get(url, {headers : header})

  }


}