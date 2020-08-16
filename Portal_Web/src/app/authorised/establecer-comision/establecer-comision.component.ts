import { EstablecerComisionService } from './services/establecer-comision.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-establecer-comision',
  templateUrl: './establecer-comision.component.html',
  styleUrls: ['./establecer-comision.component.css']
})
export class EstablecerComisionComponent implements OnInit {

  constructor( public s_comision : EstablecerComisionService) { }

  ngOnInit(): void {
  }

}
