import { Component, OnInit } from '@angular/core';
import { ChoferModel } from '../../../Models/chofer.model';
import { ChoferService } from '../../../Services/chofer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chofer',
  templateUrl: './chofer.component.html',
  styleUrls: ['./chofer.component.css']
})
export class ChoferComponent implements OnInit {

  chofers: ChoferModel[];
  mensajeError: string;

  constructor(private chofer: ChoferService, private router: Router) {
    chofer.GetChoferes().subscribe((data: ChoferModel[]) => {
      this.chofers = data;
    },
      (e) => {
        console.log(e);
      });
  }

  ngOnInit() {
    this.chofers = [];
  }

}
