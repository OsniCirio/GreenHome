import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { VegetalModel } from '../../models/vegetal.model';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-dispositivos',
  templateUrl: './dispositivos.component.html',
  standalone: false
})
export class DispositivosComponent implements OnInit {

  dispositivos: any[] = [];
  vegetais: VegetalModel[] = [];
  form!: FormGroup;
 

  constructor(private fb: FormBuilder, private api: ApiService, private cd: ChangeDetectorRef) { }

  ngOnInit() {


     this.form = this.fb.group({
      deviceId: ['', Validators.required],
      nome: ['', Validators.required],
      vegetalId: ['', Validators.required],
      ativo: [true]
    });

    this.carregar();
  }

  carregar() {
    this.api.getDispositivos().subscribe((d: any) => this.dispositivos = d);
    this.api.getVegetais().subscribe((v: VegetalModel[]) => {
      this.vegetais = v
      this.cd.detectChanges();
    });

  }

  salvar() {
    if (this.form.invalid) return;

    this.api.criarDispositivo(this.form.value).subscribe(() => {
      this.form.reset({ ativo: true });
      this.carregar();
    });
  }

  excluir(id: string) {
    this.api.deletarDispositivo(id).subscribe(() => {
      this.carregar();
    });
  }

  nomeVegetal(id: string) {
    return this.vegetais.find(v => v.id === id)?.nome || '---';
  }
}
