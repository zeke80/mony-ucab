import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OperacionDetalleRPage } from './operacion-detalle-r.page';

const routes: Routes = [
  {
    path: '',
    component: OperacionDetalleRPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OperacionDetalleRPageRoutingModule {}
