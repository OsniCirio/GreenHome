import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { LayoutComponent } from './layout/layout.component';
import { CommonModule } from '@angular/common';
import { RegrasComponent } from './pages/regras/regras.component';
import { VegetaisComponent } from './pages/vegetais/vegetais.component';
import { DispositivosComponent } from './pages/dispositivos/dispositivos.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { GraficoComponent } from './pages/graficos/grafico.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    RegrasComponent,
    VegetaisComponent,
    DashboardComponent,
    DispositivosComponent,
    GraficoComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
