import { Component, OnInit } from '@angular/core';
import { ChoferService } from '../../../Services/chofer.service';
import { ChoferModel } from '../../../Models/chofer.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chofer-detalle',
  templateUrl: './chofer-detalle.component.html',
  styleUrls: ['./chofer-detalle.component.css']
})
export class ChoferDetalleComponent implements OnInit {

  chofer: any;

  constructor(private choferService: ChoferService, private route: ActivatedRoute) {
    let id = this.route.snapshot.paramMap.get('id');

    this.choferService.GetChofer(id).subscribe(chof => {
      this.chofer = chof;
      console.log(this.chofer);
    });
  }

  ngOnInit() {
  }

}
