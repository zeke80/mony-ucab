import { Component, OnInit } from '@angular/core';
import { AdminUsuariosService } from './services/admin-usuarios.service';
import { EditUserService } from '../edit-user/services/edit-user.service';

@Component({
  selector: 'app-admin-usuarios',
  templateUrl: './admin-usuarios.component.html',
  styleUrls: ['./admin-usuarios.component.css']
})
export class AdminUsuariosComponent implements OnInit {

  usuarios : Array<any>;

  constructor(
    public s_admin_usuarios : AdminUsuariosService,
    public s_edit_user : EditUserService
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  showForm(userEmail) {
    this.s_edit_user.show = true;
    this.s_admin_usuarios.show = false;
    this.s_edit_user.editUsuario(userEmail);
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
        this.s_admin_usuarios.refreshInfo.subscribe(() => {
          this.getUsers();
        });
      },
      (err) => {
        alert(err);
      }
    );
  }

}
