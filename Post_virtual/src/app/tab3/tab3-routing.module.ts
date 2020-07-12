import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Tab3Page } from './tab3.page';

const routes: Routes = [
  {
    path: '',
    component: Tab3Page,
  },  {
    path: 'operacion-detalle',
    loadChildren: () => import('./operacion-detalle/operacion-detalle.module').then( m => m.OperacionDetallePageModule)
  },
  {
    path: 'operacion-detalle-m',
    loadChildren: () => import('./operacion-detalle-m/operacion-detalle-m.module').then( m => m.OperacionDetalleMPageModule)
  },
  {
    path: 'operacion-detalle-t',
    loadChildren: () => import('./operacion-detalle-t/operacion-detalle-t.module').then( m => m.OperacionDetalleTPageModule)
  },
  {
    path: 'pago',
    loadChildren: () => import('./pago/pago.module').then( m => m.PagoPageModule)
  },
  {
    path: 'cierre',
    loadChildren: () => import('./cierre/cierre.module').then( m => m.CierrePageModule)
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Tab3PageRoutingModule {}
