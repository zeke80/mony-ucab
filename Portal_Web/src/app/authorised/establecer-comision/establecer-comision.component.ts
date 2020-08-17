
import { Component, OnInit } from '@angular/core';
import { PerfilService } from './../perfil/services/perfil.service';
import { AdminUsuariosService } from './../admin-usuarios/services/admin-usuarios.service';
import { EstablecerComisionService } from './services/establecer-comision.service';

@Component({
  selector: 'app-establecer-comision',
  templateUrl: './establecer-comision.component.html',
  styleUrls: ['./establecer-comision.component.css']
})
export class EstablecerComisionComponent implements OnInit {

  usuarios : any;
  idComercio =0;
  comision;
  usuarioEmail : any;

  constructor(  public s_comision : EstablecerComisionService,
                private s_admin :AdminUsuariosService,
                public s_perfil : PerfilService) { }

  ngOnInit(): void {
    this.cargarComercios();
    
  }

  cambiarComision(){
    this.s_comision.setComision(this.idComercio.toString(),this.comision).subscribe(
      (data :any) => {
        alert(data.message)
      },
      (err : any)=>{
        console.log(err);
      }
    );
  }

  cargarComercios(){
    this.s_comision.consultarComercio().subscribe(
      (data : any ) =>{
        this.usuarios = data;
      },
      (err : any) => {
        console.log(err);
      }
    )
  }


}
