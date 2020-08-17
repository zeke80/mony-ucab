import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OperacionDetalleMPageRoutingModule } from './operacion-detalle-m-routing.module';

import { OperacionDetalleMPage } from './operacion-detalle-m.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OperacionDetalleMPageRoutingModule
  ],
  declarations: [OperacionDetalleMPage]
})
export class OperacionDetalleMPageModule {}
