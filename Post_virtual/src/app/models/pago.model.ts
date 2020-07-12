export class Pago {
    idpago: number;
    idusuariosolicitante: number;
    idusuarioreceptor: number;
    fechasolicitud: string;
    monto: number;
    estatus: string;
    referencia?: string;
}
