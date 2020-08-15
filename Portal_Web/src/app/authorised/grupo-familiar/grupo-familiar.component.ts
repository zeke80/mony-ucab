import { Component, OnInit } from '@angular/core';

import { GrupoFamiliarService } from './services/grupo-familiar.service';
import { PerfilService } from '../perfil/services/perfil.service';

@Component({
  selector: 'app-grupo-familiar',
  templateUrl: './grupo-familiar.component.html',
  styleUrls: ['./grupo-familiar.component.css']
})
export class GrupoFamiliarComponent implements OnInit {

  subUsuarios : Array<any>;

  constructor(
    public s_grupo_familiar : GrupoFamiliarService,
    public s_perfil : PerfilService
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

  editFamiliar(usuario) {
    console.log(usuario);
    this.s_perfil.show = true;
    this.s_perfil.refreshInfo;
    this.s_grupo_familiar.show = false;
    this.s_perfil.username = usuario;
  }

}
