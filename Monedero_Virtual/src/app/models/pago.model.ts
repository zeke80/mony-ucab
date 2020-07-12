export class Pago {
    idpago: number;
    idusuario_solicitante: number;
    idusuario_receptor: number;
    fechasolicitud: string;
    monto: number;
    estatus: string;
    referencia?: number;
}
