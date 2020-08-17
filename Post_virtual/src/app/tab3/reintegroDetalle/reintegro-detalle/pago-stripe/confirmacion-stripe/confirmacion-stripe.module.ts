import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConfirmacionStripePageRoutingModule } from './confirmacion-stripe-routing.module';

import { ConfirmacionStripePage } from './confirmacion-stripe.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ConfirmacionStripePageRoutingModule
  ],
  declarations: [ConfirmacionStripePage]
})
export class ConfirmacionStripePageModule {}
