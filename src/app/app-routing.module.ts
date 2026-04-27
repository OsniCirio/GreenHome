import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RegrasComponent } from './pages/regras/regras.component';
import { VegetaisComponent } from './pages/vegetais/vegetais.component';
import { DispositivosComponent } from './pages/dispositivos/dispositivos.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { GraficoComponent } from './pages/graficos/grafico.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'regras', component: RegrasComponent },
  { path: 'vegetais', component: VegetaisComponent },
  { path: 'dispositivos', component: DispositivosComponent },
  { path: 'graficos', component: GraficoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
