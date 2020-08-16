import { Component, OnInit } from '@angular/core';
import { AdminUsuariosService } from './services/admin-usuarios.service';

@Component({
  selector: 'app-admin-usuarios',
  templateUrl: './admin-usuarios.component.html',
  styleUrls: ['./admin-usuarios.component.css']
})
export class AdminUsuariosComponent implements OnInit {

  usuarios : Array<any>;

  constructor(
    public s_admin_usuarios : AdminUsuariosService
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.s_admin_usuarios.consultarUsuarios().subscribe(
      (data : any) => {
        this.usuarios = data;
        console.log(this.usuarios);
      },
      (err) => {
        alert(err);
      }
    )
  }

  deleteUsers(usuario, idUsuario) {
    this.s_admin_usuarios.deleteUsuarios(usuario, idUsuario).subscribe(
      (data : any) => {
        console.log(data);
        this.getUsers();
      },
      (err) => {
        alert(err);
      }
    )
  }

}
