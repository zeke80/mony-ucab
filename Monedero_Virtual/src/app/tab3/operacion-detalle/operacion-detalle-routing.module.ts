import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OperacionDetallePage } from './operacion-detalle.page';

const routes: Routes = [
  {
    path: '',
    component: OperacionDetallePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OperacionDetallePageRoutingModule {}
