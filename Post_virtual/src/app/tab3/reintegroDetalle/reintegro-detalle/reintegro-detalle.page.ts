import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reintegro-detalle',
  templateUrl: './reintegro-detalle.page.html',
  styleUrls: ['./reintegro-detalle.page.scss'],
})
export class ReintegroDetallePage implements OnInit {

  reintegroDetalle = {
    "idReintegro": null,
    "idUsuarioSolicitante": null,
    "fecha": {
        "year": null,
        "month": null,
        "day": null,
    },
    "monto": null,
    "estatus": '',
    "referencia": ''
  }

  constructor() { }

  setDetalle(){
   this.reintegroDetalle.idReintegro = localStorage.getItem('idReintegroDetalle');
   this.reintegroDetalle.idUsuarioSolicitante = localStorage.getItem('idUsuarioSolicitanteDetalle');
   this.reintegroDetalle.fecha.day = localStorage.getItem('diaDetalle');
   this.reintegroDetalle.fecha.month = localStorage.getItem('mesDetalle');
   this.reintegroDetalle.fecha.year = localStorage.getItem('anoDetalle');
   this.reintegroDetalle.monto = localStorage.getItem('montoDetalle');
   this.reintegroDetalle.estatus = localStorage.getItem('estatusDetalle');
   this.reintegroDetalle.referencia = localStorage.getItem('referenciaDetalle');
  }

getUser(){
  
}

  ngOnInit() {
    this.setDetalle();
    //hay que poner el email del usuario, aca hay solo el id del usuario oslicitante
    
  }

}
