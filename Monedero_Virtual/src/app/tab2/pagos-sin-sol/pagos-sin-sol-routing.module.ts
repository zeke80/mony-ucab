import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PagosSinSolPage } from './pagos-sin-sol.page';

const routes: Routes = [
  {
    path: '',
    component: PagosSinSolPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagosSinSolPageRoutingModule {}
