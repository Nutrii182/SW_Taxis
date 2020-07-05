  import { Component, OnInit } from '@angular/core';
import { ChoferModel } from '../../../Models/chofer.model';
import { ChoferService } from '../../../Services/chofer.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-chofer',
  templateUrl: './chofer.component.html',
  styleUrls: ['./chofer.component.css']
})
export class ChoferComponent implements OnInit {

  chofers: ChoferModel[];
  mensajeError: string;

  constructor(private choferService: ChoferService, private router: Router) {
    choferService.GetChoferes().subscribe((data: ChoferModel[]) => {
      this.chofers = data;
    },
      (e) => {
        console.log(e);
      });
  }

  ngOnInit() {
    this.chofers = [];
  }

  eliminaChofer(id: string) {
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
        this.choferService.DeleteChofer(id).subscribe(ch => {
          if (ch != null) {
            Swal.fire({
              title: 'Éxito',
              text: 'Chofer Eliminado Correctamente',
              icon: 'success'
            });
            location.reload();
          }
        }, (e) => {
          Swal.fire({
            title: 'Error',
            text: 'Error Eliminando Chofer',
            icon: 'error'
          });
        });
      }
    });
  }

}
