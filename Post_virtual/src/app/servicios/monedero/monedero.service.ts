import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MonederoService {

  constructor(
    public http: HttpClient
  ) { }

  
}
