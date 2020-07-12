import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';
import { LoginPage } from '../login/login.page';
import { LoginGuard } from '../guard/login.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginPage,
    loadChildren: () => import('../login/login.module').then(m => m.LoginPageModule)
  },
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
        loadChildren: () => import ('../tab3/operacion-detalle-r/operacion-detalle-r.module').then(m => m.OperacionDetalleRPageModule)
      },
      {
        path: 'operaciones/pago',
        loadChildren: () => import ('../tab3/pago/pago.module').then(m => m.PagoPageModule)
      },
      {
        path: 'operaciones/cierre',
        loadChildren: () => import ('../tab3/cierre/cierre.module').then(m => m.CierrePageModule)
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
