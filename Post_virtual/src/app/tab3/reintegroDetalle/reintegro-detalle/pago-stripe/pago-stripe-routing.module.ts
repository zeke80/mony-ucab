import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PagoStripePage } from './pago-stripe.page';

const routes: Routes = [
  {
    path: '',
    component: PagoStripePage
  },
  {
    path: 'confirmacion-stripe',
    loadChildren: () => import('./confirmacion-stripe/confirmacion-stripe.module').then( m => m.ConfirmacionStripePageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagoStripePageRoutingModule {}
