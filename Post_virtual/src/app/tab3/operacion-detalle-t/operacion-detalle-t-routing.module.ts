import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OperacionDetalleTPage } from './operacion-detalle-t.page';

const routes: Routes = [
  {
    path: '',
    component: OperacionDetalleTPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OperacionDetalleTPageRoutingModule {}
