import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../../Services/usuario.service';
import { UsuarioModel } from '../../../Models/usuario.model';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  user: UsuarioModel;
  constructor(private usuario: UsuarioService, private router: Router) { }

  ngOnInit() {
    this.user = new UsuarioModel();
  }

  registrar(form: NgForm) {

    if (form.invalid)
      return;

    this.usuario.registrar(this.user).subscribe(user => {
      if (user != null) {
        Swal.fire({
          title: 'Éxito',
          text: 'Usuario registrado correctamente',
          icon: 'success'
        });
        this.router.navigate(["login"]);
      }
    }, (e) => {
        Swal.fire({
          title: 'Error',
          text: 'Error Registrando Usuario',
          icon: 'error'
        });
    });

  }

}
