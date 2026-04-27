import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-vegetais',
  templateUrl: './vegetais.component.html',
  styleUrl: './vegetais.component.css',
  standalone: false
})

export class VegetaisComponent implements OnInit {

  vegetais: any[] = [];
  novo: any = { nome: '' };
  form!: FormGroup;

  constructor(private fb: FormBuilder, private api: ApiService,
    private cd: ChangeDetectorRef
    
  )
  {

  }

  ngOnInit() {
    this.form = this.fb.group({
      nome: ['']
    });

    this.carregar();
  }
  
  carregar() {
    this.api.getVegetais().subscribe({
      next: (res: any) => {
        this.vegetais = res;
      },
      error: (err) => {
        console.error('Erro na API:', err);
      }
    });
  }

  salvar() {
    debugger;
    this.novo = this.form.value.nome;
    this.api.criarVegetal(this.novo).subscribe(() => {
      this.novo = { nome: '' };
      this.carregar();
    });
  }

  excluir(id: string) {
    Swal.fire({
      title: 'Remover Vegetal',
      text: 'Confirma a remoção do vegetal?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {

      if (result.isConfirmed) {
        this.api.deletarVegetal(id).subscribe(() => {
          Swal.fire('Excluído!', 'Vegetal removido.', 'success');
          this.carregar();
          this.cd.detectChanges();
        });
      }
    });
  }
}
