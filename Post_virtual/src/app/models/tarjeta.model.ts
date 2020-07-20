export class Tarjeta {
    "idTarjeta": number;
        "idUsuario": number;
        "numero": number;
        "fechaVencimiento": {
            "dayOfYear": number;
            "year": number;
            "month": number;
            "day": number;
            "dayOfWeek": number;
            "isLeapYear": boolean;
            "isInfinity": boolean;
            "isNegativeInfinity": boolean;
            "isFinite": boolean;
        };
        "cvc": number;
        "estatus": number
}