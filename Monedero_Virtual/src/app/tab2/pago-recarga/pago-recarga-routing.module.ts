import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PagoRecargaPage } from './pago-recarga.page';

const routes: Routes = [
  {
    path: '',
    component: PagoRecargaPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagoRecargaPageRoutingModule {}
