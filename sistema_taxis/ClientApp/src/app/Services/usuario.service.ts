import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsuarioModel } from '../Models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  login(usuario: UsuarioModel) {
    const userData = {
      ...usuario
    }
    return this.http.post('api/Login/IniciarSesion', userData);
  }
}
