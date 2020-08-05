import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReintegroDetallePage } from './reintegro-detalle.page';

const routes: Routes = [
  {
    path: '',
    component: ReintegroDetallePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ReintegroDetallePageRoutingModule {}
