import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';
import { LoginGuard } from '../guard/login.guard';

const routes: Routes = [
  {
    path: 'tabs',
    component: TabsPage,
    canActivate: [LoginGuard],
    children: [
      {
        path: 'perfil',
        loadChildren: () => import('../tab1/tab1.module').then(m => m.Tab1PageModule)
      },
      {
        path: 'cuenta',
        loadChildren: () => import('../tab2/tab2.module').then(m => m.Tab2PageModule)
      },
      {
        path: 'operaciones',
        loadChildren: () => import('../tab3/tab3.module').then(m => m.Tab3PageModule)
      },
      
      {
        path: 'operaciones/:operacionID',
        loadChildren: () => import('../tab3/operacion-detalle/operacion-detalle.module').then(m => m.OperacionDetallePageModule)
      },
      {
        path: 'operaciones/monedero/:operacionID',
        loadChildren: () => import ('../tab3/operacion-detalle-m/operacion-detalle-m.module').then(m => m.OperacionDetalleMPageModule)
      },
      {
        path: 'operaciones/tarjeta/:operacionID',
        loadChildren: () => import ('../tab3/operacion-detalle-t/operacion-detalle-t.module').then(m => m.OperacionDetalleTPageModule)
      },
      {
        path: 'operaciones/reintegro/:operacionID',
        loadChildren: () => import ('../tab3/operacion-detalle-r/oparecion-detalle-r.module').then(m => m.OparecionDetalleRPageModule)
      },
      {
        path: 'cuenta/pago',
        loadChildren: () => import ('../tab3/pago/pago.module').then(m => m.PagoPageModule)
      },
      {
        path: 'cuenta/solicitudPago/:pagoID',
        loadChildren: () => import ('../tab2/solicitud-pago/solicitud-pago.module').then(m => m.SolicitudPagoPageModule)
      },
      {
        path: 'cuenta/pagoSinSolicitud',
        loadChildren: () => import ('../tab2/pagos-sin-sol/pagos-sin-sol.module').then(m => m.PagosSinSolPageModule)
      },
      {
        path: 'cuenta/recarga',
        loadChildren: () => import ('../tab2/recarga/recarga.module').then(m => m.RecargaPageModule)
      },
      {
        path: 'cuenta/retiro',
        loadChildren: () => import ('../tab2/retiro/retiro.module').then(m => m.RetiroPageModule)
      },
      {
        path: '',
        redirectTo: '/tabs/cuenta',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TabsPageRoutingModule {}
