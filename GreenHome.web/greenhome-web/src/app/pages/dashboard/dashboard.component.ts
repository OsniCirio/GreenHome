import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  standalone:false
})
export class DashboardComponent implements OnInit, OnDestroy {

  leitura: any = {};
  interval: any;

  deviceId = 'estufa-01'; // mesmo ID do ESP32

  constructor(private api: ApiService) { }

  ngOnInit() {
    this.atualizar();

    // Atualiza a cada 5 segundos
    this.interval = setInterval(() => {
      this.atualizar();
    }, 5000);
  }

  ngOnDestroy() {
    clearInterval(this.interval);
  }

  atualizar() {
    this.api.getUltimaLeitura(this.deviceId).subscribe({
      next: (res: any) => {
        this.leitura = res;
      },
      error: () => {
        console.log('Erro ao buscar leitura');
      }
    });
  }
}
