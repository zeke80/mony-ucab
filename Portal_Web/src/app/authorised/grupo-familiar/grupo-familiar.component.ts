import { Component, OnInit } from '@angular/core';

import { GrupoFamiliarService } from './services/grupo-familiar.service';
import { EditUserService } from '../edit-user/services/edit-user.service';

@Component({
  selector: 'app-grupo-familiar',
  templateUrl: './grupo-familiar.component.html',
  styleUrls: ['./grupo-familiar.component.css']
})
export class GrupoFamiliarComponent implements OnInit {

  subUsuarios : Array<any>;

  constructor(
    public s_grupo_familiar : GrupoFamiliarService,
    public s_edit_user : EditUserService
  ) { }

  ngOnInit(): void {
    this.getGrupoFamiliar();
  }

  getGrupoFamiliar() {
    this.s_grupo_familiar.getSubUsuarios().subscribe(
      (data : any) => {
        this.subUsuarios = data;
        console.log(this.subUsuarios);
      },
      (err) => {
        alert(err);
      }
    )
  }

  addFamiliar() {

  }

  editFamiliar(userEmail) {
    console.log(userEmail);
    this.s_edit_user.show = true;
    this.s_grupo_familiar.show = false;

    this.s_edit_user.userEmail = userEmail;
    this.s_edit_user.editUsuario(userEmail);
  }

}
