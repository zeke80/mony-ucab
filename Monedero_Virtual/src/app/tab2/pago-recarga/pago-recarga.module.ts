import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PagoRecargaPageRoutingModule } from './pago-recarga-routing.module';

import { PagoRecargaPage } from './pago-recarga.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PagoRecargaPageRoutingModule
  ],
  declarations: [PagoRecargaPage]
})
export class PagoRecargaPageModule {}
