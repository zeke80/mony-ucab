import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PagoStripePageRoutingModule } from './pago-stripe-routing.module';

import { PagoStripePage } from './pago-stripe.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PagoStripePageRoutingModule
  ],
  declarations: [PagoStripePage]
})
export class PagoStripePageModule {}
