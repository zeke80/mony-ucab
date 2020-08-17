import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PaymentMessagePage } from './payment-message.page';

const routes: Routes = [
  {
    path: '',
    component: PaymentMessagePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PaymentMessagePageRoutingModule {}
