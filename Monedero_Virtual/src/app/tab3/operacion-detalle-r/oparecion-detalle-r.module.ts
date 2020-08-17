import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OparecionDetalleRPageRoutingModule } from './oparecion-detalle-r-routing.module';

import { OparecionDetalleRPage } from './oparecion-detalle-r.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OparecionDetalleRPageRoutingModule
  ],
  declarations: [OparecionDetalleRPage]
})
export class OparecionDetalleRPageModule {}
