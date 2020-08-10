import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PagoPaypalPage } from './pago-paypal.page';

const routes: Routes = [
  {
    path: '',
    component: PagoPaypalPage
  },
  {
    path: 'payment-message',
    loadChildren: () => import('./payment-message/payment-message.module').then( m => m.PaymentMessagePageModule)
  },
  {
    path: 'confirmacion-paypal',
    loadChildren: () => import('./confirmacion-paypal/confirmacion-paypal.module').then( m => m.ConfirmacionPaypalPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagoPaypalPageRoutingModule {}
