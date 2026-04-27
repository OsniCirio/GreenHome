import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { ChangeDetectorRef } from '@angular/core';
import { VegetalModel } from '../../models/vegetal.model';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-regras',
  templateUrl: './regras.component.html',
  standalone: false
})

export class RegrasComponent implements OnInit {

  constructor(private fb: FormBuilder, private api: ApiService, private cd: ChangeDetectorRef) { }
  
  regras: any[] = [];
  vegetais: VegetalModel[] = [];
  form!: FormGroup;
  

  async ngOnInit() {
    

    this.form = this.fb.group({
      vegetalId: ['', Validators.required],
      temperaturaMinima: [0, Validators.required],
      temperaturaMaxima: [0, Validators.required],
      umidadeMinima: [0, Validators.required],
      umidadeMaxima: [0, Validators.required],
      luminosidadeMinima: [0, Validators.required],
      luminosidadeMaxima: [0, Validators.required],
      corR: [255],
      corG: [0],
      corB: [0],
      intensidade: [150]
    });

    await this.carregar();
  }
  novo() {
    this.form.reset({
      corR: 255,
      corG: 0,
      corB: 0,
      intensidade: 150
    });
  }
  async carregar() {
    this.regras = await firstValueFrom(this.api.getRegras());
    this.vegetais = await firstValueFrom(this.api.getVegetais());
    this.cd.detectChanges();
  }

  salvar() {
    if (this.form.invalid) return;

    this.api.criarRegra(this.form.value).subscribe(() => {
      this.form.reset({
        corR: 255,
        corG: 0,
        corB: 0,
        intensidade: 150
      });
      this.carregar();
    });
  }
}
