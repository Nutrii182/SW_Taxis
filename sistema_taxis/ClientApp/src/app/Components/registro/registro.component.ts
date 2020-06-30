import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../Services/usuario.service';
import { UsuarioModel } from '../../Models/usuario.model';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  user: UsuarioModel = new UsuarioModel();
  constructor(private usuario: UsuarioService, private router: Router) { }

  ngOnInit() {
  }

  registrar(form: NgForm) {

    if (form.invalid)
      return;
    console.log(this.user);

  }

}
