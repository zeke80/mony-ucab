export class Usuario {
    constructor(
        public idUsuario: number,
        public idTipoUsuario: number,
        public idTipoIdentificacion: number,
        public usuario: string,
        public fechaRegistro: string,
        public nroIdentificacion: number,
        public email: string,
        public telefono: string,
        public direccion: string,
        public estatus: number,
    ) {

    }
}
