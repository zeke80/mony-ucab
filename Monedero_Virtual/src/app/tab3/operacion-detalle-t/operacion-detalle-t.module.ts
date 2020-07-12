import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OperacionDetalleTPageRoutingModule } from './operacion-detalle-t-routing.module';

import { OperacionDetalleTPage } from './operacion-detalle-t.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OperacionDetalleTPageRoutingModule
  ],
  declarations: [OperacionDetalleTPage]
})
export class OperacionDetalleTPageModule {}
