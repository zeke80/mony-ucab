import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ReintegroDetallePageRoutingModule } from './reintegro-detalle-routing.module';

import { ReintegroDetallePage } from './reintegro-detalle.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ReintegroDetallePageRoutingModule
  ],
  declarations: [ReintegroDetallePage]
})
export class ReintegroDetallePageModule {}
