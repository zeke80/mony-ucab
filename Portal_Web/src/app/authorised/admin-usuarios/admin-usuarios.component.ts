import { Component, OnInit } from '@angular/core';
import { AdminUsuariosService } from './services/admin-usuarios.service';

@Component({
  selector: 'app-admin-usuarios',
  templateUrl: './admin-usuarios.component.html',
  styleUrls: ['./admin-usuarios.component.css']
})
export class AdminUsuariosComponent implements OnInit {

  constructor(
    public s_admin_usuarios : AdminUsuariosService
  ) { }

  ngOnInit(): void {
    
  }

}
