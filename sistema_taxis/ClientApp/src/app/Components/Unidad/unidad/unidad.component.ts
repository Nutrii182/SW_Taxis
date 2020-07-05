import { Component, OnInit } from '@angular/core';
import { UnidadService } from '../../../Services/unidad.service';
import { UnidadModel } from '../../../Models/unidad.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-unidad',
  templateUrl: './unidad.component.html',
  styleUrls: ['./unidad.component.css']
})
export class UnidadComponent implements OnInit {

  unidades: UnidadModel[];

  constructor(private unidadService: UnidadService) {
    unidadService.GetUnidades().subscribe((uni: UnidadModel[]) => {
      this.unidades = uni;
    });
  }

  ngOnInit() {
    this.unidades = [];
  }

  eliminaUnidad(id: string) {
    Swal.fire({
      title: '¿Estás Seguro?',
      text: "No Podrás Revertirlo",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sí, Bórralo!'
    }).then((result) => {
      if (result.value) {
        this.unidadService.DeleteUnidad(id).subscribe(uni => {
          if (uni != null) {
            Swal.fire({
              title: 'Éxito',
              text: 'Unidad Eliminada Correctamente',
              icon: 'success'
            });
            location.reload();
          }
        }, (e) => {
          Swal.fire({
            title: 'Error',
            text: 'Error Eliminando Unidad',
            icon: 'error'
          });
        });
      }
    });
  }

}
