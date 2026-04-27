import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Chart } from 'chart.js/auto';


@Component({
  selector: 'app-grafico',
  templateUrl: './grafico.component.html',
  styleUrl: './grafico.component.css',
  standalone:false
})

export class GraficoComponent implements OnInit, OnDestroy {

  chart: any;
  interval: any;

  deviceId = 'estufa-01';

  constructor(private api: ApiService) { }

  ngOnInit() {
    debugger;
    this.criarGrafico();
    this.carregarDados();

    // Atualiza a cada 5s
    this.interval = setInterval(() => {
      this.carregarDados();
    }, 5000);
  }

  ngOnDestroy() {
    clearInterval(this.interval);
  }

  criarGrafico() {
    this.chart = new Chart('grafico', {
      type: 'line',
      data: {
        labels: [],
        datasets: [
          {
            label: 'Temperatura',
            data: [],
            borderWidth: 2
          },
          {
            label: 'Umidade',
            data: [],
            borderWidth: 2
          },
          {
            label: 'Luz',
            data: [],
            borderWidth: 2
          }
        ]
      }
    });
  }

  carregarDados() {
    this.api.getHistorico(this.deviceId).subscribe((res: any[]) => {

      const labels = res.map(x => new Date(x.dataLeitura).toLocaleTimeString());

      const temp = res.map(x => x.temperatura);
      const umid = res.map(x => x.umidade);
      const luz = res.map(x => x.luminosidade);

      this.chart.data.labels = labels;
      this.chart.data.datasets[0].data = temp;
      this.chart.data.datasets[1].data = umid;
      this.chart.data.datasets[2].data = luz;

      this.chart.update();
    });
  }
}
