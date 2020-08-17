import { Injectable } from '@angular/core';
import { OperacionCuenta } from '../../models/operacionCuenta.model';
import { OperacionMonedero } from '../../models/operacionMonedero.model';
import { OperacionTarjeta } from '../../models/operacionTarjeta.model';
import { Reintegro } from '../../models/reintegro.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OperacionService {

  operacionesCuenta: OperacionCuenta[] = [
    {
      idoperacioncuenta: 0,
      idcuenta: 0,
      idUsuarioReceptor: 0,
      fecha: '',
      hora: '',
      monto: 0,
      referencia: 0
    }
  ];
  operacionesMonedero: OperacionMonedero[] = [
    {
      idoperacionesmonedero: 0,
      idusuario: 0,
      idTipoOperacion: 0,
      monto: 0,
      fecha: '',
      hora: '',
      referencia: 0
    }
  ];
  operacionesTarjeta: OperacionTarjeta[] = [
    {
      idoperaciontarjeta: 0,
      idUsuarioReceptor: 0,
      idtarjeta: 0,
      fecha: '',
      hora: '',
      monto: 0,
      referencia: 0
    }
  ];

  constructor(
    public http: HttpClient
  ) { }

}
