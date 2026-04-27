import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VegetalModel } from '../models/vegetal.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // 👉 ajuste a porta conforme sua API
  private baseUrl = 'https://localhost:7097/api';

  constructor(private http: HttpClient) { }

  // =========================
  // 🌱 VEGETAIS
  // =========================

  getVegetais(): Observable<VegetalModel[]> {
    return this.http.get<VegetalModel[]>(`${this.baseUrl}/vegetais`);
  }

  getVegetalById(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/vegetais/${id}`);
  }

  criarVegetal(data: any): Observable<any> {
    debugger;
    return this.http.post(`${this.baseUrl}/vegetais`, { Nome: data, Descricao: data });
  }

  atualizarVegetal(id: string, data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/vegetais/${id}`, data);
  }

  deletarVegetal(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/vegetais/${id}`);
  }

  // =========================
  // 🌿 REGRAS DE CULTIVO
  // =========================

  getRegras(): Observable<any> {
    return this.http.get(`${this.baseUrl}/regrascultivo`);
  }

  getRegraById(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/regrascultivo/${id}`);
  }

  criarRegra(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/regrascultivo`, data);
  }

  atualizarRegra(id: string, data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/regrascultivo/${id}`, data);
  }

  deletarRegra(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/regrascultivo/${id}`);
  }

  // =========================
  // 📡 DISPOSITIVOS
  // =========================

  getDispositivos(): Observable<any> {
    return this.http.get(`${this.baseUrl}/dispositivos`);
  }

  getDispositivoById(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/dispositivos/${id}`);
  }

  criarDispositivo(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/dispositivos`, data);
  }

  atualizarDispositivo(id: string, data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/dispositivos/${id}`, data);
  }

  deletarDispositivo(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/dispositivos/${id}`);
  }

  // =========================
  // 📊 TELEMETRIA
  // =========================

  enviarTelemetria(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/telemetria/processar`, data);
  }

  getUltimaLeitura(deviceId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/telemetria/ultima/${deviceId}`);
  }

  getHistorico(deviceId: string): Observable<any> {
    return this.http.get(`${this.baseUrl}/telemetria/historico/${deviceId}`);
  }
}
