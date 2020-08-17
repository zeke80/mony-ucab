export class User {
    "result": {
        "idUsuario": number,
        "idEntity": string,
        "usuario": string,
        "fechaRegistro": {
            "dayOfYear": number,
            "year": number,
            "month": number,
            "day": number,
            "dayOfWeek": number,
            "isLeapYear": boolean,
            "isInfinity": boolean,
            "isNegativeInfinity": boolean,
            "isFinite": boolean
        },
        "nroIdentificacion": number,
        "email": string,
        "telefono": string,
        "direccion": string,
        "estatus": number,
        "contrasena": string,
        "idTipoUsuario": number
    };
    "tipoIdentificacion": {
        "idTipoIdentificacion": number,
        "codigo": string,
        "descripcion": string,
        "estatus": number
    };
    "persona": {
        "nombre": string,
        "apellido": string,
        "fechaNacimiento": {
            "dayOfYear": number,
            "year": number,
            "month": number,
            "day": number,
            "dayOfWeek": number,
            "isLeapYear": boolean,
            "isInfinity": boolean,
            "isNegativeInfinity": boolean,
            "isFinite": boolean
        }
    };
    "estadoCivil": {
        "idEstadoCivil": number,
        "descripcion": string,
        "codigo": string,
        "estatus": number
    };
    "comercio": {
        "razonSocial": string,
        "nombreRepresentante": string,
        "apellidoRepresentante": string
    }
}
