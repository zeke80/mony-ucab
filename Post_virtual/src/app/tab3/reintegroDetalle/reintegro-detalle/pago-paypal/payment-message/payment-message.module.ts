import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PaymentMessagePageRoutingModule } from './payment-message-routing.module';

import { PaymentMessagePage } from './payment-message.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PaymentMessagePageRoutingModule
  ],
  declarations: [PaymentMessagePage]
})
export class PaymentMessagePageModule {}
