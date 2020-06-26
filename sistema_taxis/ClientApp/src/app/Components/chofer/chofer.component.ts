import { Component, OnInit } from '@angular/core';
import { ChoferModel } from '../../Models/chofer.model';
import { ChoferService } from '../../Services/chofer.service';

@Component({
  selector: 'app-chofer',
  templateUrl: './chofer.component.html',
  styleUrls: ['./chofer.component.css']
})
export class ChoferComponent implements OnInit {

  chofers: ChoferModel[];
  mensajeError: string;
  showContent: boolean;

  constructor(private chofer: ChoferService) {
    chofer.GetChoferes().subscribe((data: ChoferModel[]) => {
      this.chofers = data;
    });
  }

  ngOnInit() {
    this.chofers = [];
    this.showContent = false;
    setTimeout(() => this.showContent = true, 300);
  }

}
