import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OperacionDetalleRPageRoutingModule } from './operacion-detalle-r-routing.module';

import { OperacionDetalleRPage } from './operacion-detalle-r.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OperacionDetalleRPageRoutingModule
  ],
  declarations: [OperacionDetalleRPage]
})
export class OperacionDetalleRPageModule {}
