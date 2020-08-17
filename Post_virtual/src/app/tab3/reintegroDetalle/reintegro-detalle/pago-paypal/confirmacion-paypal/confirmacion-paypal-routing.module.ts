import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConfirmacionPaypalPage } from './confirmacion-paypal.page';

const routes: Routes = [
  {
    path: '',
    component: ConfirmacionPaypalPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConfirmacionPaypalPageRoutingModule {}
