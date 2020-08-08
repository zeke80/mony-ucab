import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PagoPaypalPageRoutingModule } from './pago-paypal-routing.module';

import { PagoPaypalPage } from './pago-paypal.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PagoPaypalPageRoutingModule
  ],
  declarations: [PagoPaypalPage]
})
export class PagoPaypalPageModule {}
