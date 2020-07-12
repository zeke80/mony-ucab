import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SolicitudPagoPageRoutingModule } from './solicitud-pago-routing.module';

import { SolicitudPagoPage } from './solicitud-pago.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SolicitudPagoPageRoutingModule
  ],
  declarations: [SolicitudPagoPage]
})
export class SolicitudPagoPageModule {}
