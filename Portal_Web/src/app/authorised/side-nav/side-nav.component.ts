
import { Component, OnInit } from '@angular/core';
import { AuthorisedSideNavService } from './services/authorised-side-nav.service';



@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {

  showMenuAdmin = false;
  showComercio = localStorage.getItem('esComercio');

  constructor(public sideNavService: AuthorisedSideNavService) { }

  ngOnInit(): void {
    if (parseInt(localStorage.getItem('userIntID')) == 15){
      this.showMenuAdmin = true;
    }
    console.log(this.showComercio);
  }

  
}
