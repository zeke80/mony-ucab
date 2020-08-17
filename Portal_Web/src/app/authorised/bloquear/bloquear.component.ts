import { Component, OnInit } from '@angular/core';
import { BloquearService } from './services/bloquear.service';

@Component({
  selector: 'app-bloquear',
  templateUrl: './bloquear.component.html',
  styleUrls: ['./bloquear.component.css']
})
export class BloquearComponent implements OnInit {

  pagos : any;

  constructor(public s_bloquear : BloquearService) { }

  ngOnInit(): void {
    this.consultarPagos();
  }

  consultarPagos(){
    this.s_bloquear.consultarPagos().subscribe(data =>{
      this.pagos = data;
    });
  }

}
