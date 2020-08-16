import { AuthorisedSideNavService } from './../side-nav/services/authorised-side-nav.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-opciones-admin',
  templateUrl: './opciones-admin.component.html',
  styleUrls: ['./opciones-admin.component.css']
})
export class OpcionesAdminComponent implements OnInit {

  constructor(public s_sideNav : AuthorisedSideNavService) { }

  ngOnInit(): void {
  }

}
