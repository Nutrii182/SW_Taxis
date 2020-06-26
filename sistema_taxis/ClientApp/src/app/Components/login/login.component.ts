import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UsuarioModel } from '../../Models/usuario.model';
import { UsuarioService } from '../../Services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: UsuarioModel = new UsuarioModel();
  constructor(private usuario: UsuarioService, private router: Router) { }

  ngOnInit() {
  }

  logeo(form: NgForm) {

    if (form.invalid)
      return;

    this.usuario.login(this.user).subscribe(result => {
      this.router.navigate(["home"]);
    }, (e) => {
        console.log(e.error);
    });
  }
}
