import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OperacionDetalleMPage } from './operacion-detalle-m.page';

const routes: Routes = [
  {
    path: '',
    component: OperacionDetalleMPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OperacionDetalleMPageRoutingModule {}
