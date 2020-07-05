import { Component, OnInit } from '@angular/core';
import { UnidadService } from '../../../Services/unidad.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-unidad-detalle',
  templateUrl: './unidad-detalle.component.html',
  styleUrls: ['./unidad-detalle.component.css']
})
export class UnidadDetalleComponent implements OnInit {

  unidad: any;

  constructor(private unidadService: UnidadService, private route: ActivatedRoute) {
    let id = this.route.snapshot.paramMap.get('id');

    this.unidadService.GetUnidad(id).subscribe(uni => {
      this.unidad = uni;
      console.log(this.unidad);
    });
  }

  ngOnInit() {
  }

}
