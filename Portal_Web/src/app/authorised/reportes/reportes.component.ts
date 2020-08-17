import { Component, OnInit } from '@angular/core';
import { ReportesService } from './services/reportes.service';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent implements OnInit {

  constructor(
    public s_reportes : ReportesService
  ) { }

  ngOnInit(): void {

  }

}
