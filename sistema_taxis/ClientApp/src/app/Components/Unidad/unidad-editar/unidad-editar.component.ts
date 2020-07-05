import { Component, OnInit } from '@angular/core';
import { UnidadService } from '../../../Services/unidad.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-unidad-editar',
  templateUrl: './unidad-editar.component.html',
  styleUrls: ['./unidad-editar.component.css']
})
export class UnidadEditarComponent implements OnInit {

  constructor(private unidadService: UnidadService, private route: ActivatedRoute) {
    let id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
  }

}
