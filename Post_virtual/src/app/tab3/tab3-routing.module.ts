import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Tab3Page } from './tab3.page';

const routes: Routes = [
  {
    path: '',
    component: Tab3Page,
  },
  {
    path: 'pago',
    loadChildren: () => import('./pago/pago.module').then( m => m.PagoPageModule)
  },
  {
    path: 'cierre',
    loadChildren: () => import('./cierre/cierre.module').then( m => m.CierrePageModule)
  },
  {
    path: 'reintegro-detalle',
    loadChildren: () => import('./reintegroDetalle/reintegro-detalle/reintegro-detalle.module').then( m => m.ReintegroDetallePageModule)
  }


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Tab3PageRoutingModule {}
