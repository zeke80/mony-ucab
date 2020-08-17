import { Component, OnInit } from '@angular/core';
import { LoginService } from './../../home/login-form/services/login.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  constructor(public user_service : LoginService) { 
  }

  ngOnInit(): void {
  }

}
