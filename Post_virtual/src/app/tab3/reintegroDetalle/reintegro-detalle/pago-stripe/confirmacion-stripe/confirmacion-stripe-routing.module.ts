import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConfirmacionStripePage } from './confirmacion-stripe.page';

const routes: Routes = [
  {
    path: '',
    component: ConfirmacionStripePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConfirmacionStripePageRoutingModule {}
