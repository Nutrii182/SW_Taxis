import { Component, OnInit } from '@angular/core';
import { ChoferService } from '../../../Services/chofer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chofer-editar',
  templateUrl: './chofer-editar.component.html',
  styleUrls: ['./chofer-editar.component.css']
})
export class ChoferEditarComponent implements OnInit {

  chofer: any;

  constructor(private choferService: ChoferService, private route: ActivatedRoute) {
    let id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
  }

}
