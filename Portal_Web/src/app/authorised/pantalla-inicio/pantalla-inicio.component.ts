import { Component, OnInit } from '@angular/core';

import { InicioService } from './services/inicio.service';

@Component({
  selector: 'app-pantalla-inicio',
  templateUrl: './pantalla-inicio.component.html',
  styleUrls: ['./pantalla-inicio.component.css']
})
export class PantallaInicioComponent implements OnInit {

  nombre = localStorage.getItem('username');
  userIntID = localStorage.getItem('userIntID');
  saldo : any ;

  constructor(public s_inicio : InicioService) { }

  ngOnInit(): void {
    this.s_inicio.consultarSaldo(this.userIntID).subscribe(data => {
      console.log(data);
      this.saldo = data;
    });
  }


}
