import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PagosSinSolPageRoutingModule } from './pagos-sin-sol-routing.module';

import { PagosSinSolPage } from './pagos-sin-sol.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PagosSinSolPageRoutingModule
  ],
  declarations: [PagosSinSolPage]
})
export class PagosSinSolPageModule {}
