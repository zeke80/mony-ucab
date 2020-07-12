import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OperacionDetallePageRoutingModule } from './operacion-detalle-routing.module';

import { OperacionDetallePage } from './operacion-detalle.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OperacionDetallePageRoutingModule
  ],
  declarations: [OperacionDetallePage]
})
export class OperacionDetallePageModule {}
