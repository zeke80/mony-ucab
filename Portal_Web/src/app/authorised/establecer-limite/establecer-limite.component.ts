import { EstablecerLimiteService } from './services/establecer-limite.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-establecer-limite',
  templateUrl: './establecer-limite.component.html',
  styleUrls: ['./establecer-limite.component.css']
})
export class EstablecerLimiteComponent implements OnInit {

  parametros : any;
  idParametro = 0;
  limite = 0;

  constructor(public s_limite : EstablecerLimiteService) { }

  ngOnInit(): void {
    this.consultarParametros();
  }

  consultarParametros(){
    this.s_limite.getParametro().subscribe(
      (data : any) => {
        console.log(data);
        this.parametros = data;

      },
      (err : any) =>{
        console.log(err);
      }
    );
  }
}
