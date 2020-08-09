import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PagoPaypalPage } from './pago-paypal.page';

const routes: Routes = [
  {
    path: '',
    component: PagoPaypalPage
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagoPaypalPageRoutingModule {}
