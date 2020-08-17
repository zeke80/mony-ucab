import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SolicitudPagoPage } from './solicitud-pago.page';

const routes: Routes = [
  {
    path: '',
    component: SolicitudPagoPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SolicitudPagoPageRoutingModule {}
