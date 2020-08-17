import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConfirmacionPaypalPageRoutingModule } from './confirmacion-paypal-routing.module';

import { ConfirmacionPaypalPage } from './confirmacion-paypal.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ConfirmacionPaypalPageRoutingModule
  ],
  declarations: [ConfirmacionPaypalPage]
})
export class ConfirmacionPaypalPageModule {}
