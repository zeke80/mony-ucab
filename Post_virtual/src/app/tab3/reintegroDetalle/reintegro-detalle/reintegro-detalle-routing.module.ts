import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReintegroDetallePage } from './reintegro-detalle.page';

const routes: Routes = [
  {
    path: '',
    component: ReintegroDetallePage
  },
  {
    path: 'pago-paypal',
    loadChildren: () => import('./pago-paypal/pago-paypal.module').then( m => m.PagoPaypalPageModule)
  },  {
    path: 'pago-stripe',
    loadChildren: () => import('./pago-stripe/pago-stripe.module').then( m => m.PagoStripePageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ReintegroDetallePageRoutingModule {}
