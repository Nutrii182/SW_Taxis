import { Component } from '@angular/core';
import { ChoferModel } from '../../Models/chofer.model';
import { ChoferService } from '../../Services/chofer.service';

@Component({
  selector: 'app-chofer',
  templateUrl: './chofer.component.html',
  styleUrls: ['./chofer.component.css']
})
export class ChoferComponent{

  chofers: ChoferModel[] = [];
  mensajeError: string;

  constructor(private chofer: ChoferService) {
    chofer.GetChoferes().subscribe((data: ChoferModel[]) => {
      this.chofers = data;
      console.log(this.chofers);
    });
  }

}
