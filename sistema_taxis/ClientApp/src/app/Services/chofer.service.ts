import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChoferService{

  usuario: any;

  constructor(private http: HttpClient) {
    this.usuario = JSON.parse(localStorage.getItem('usuario'));
  }

  GetChoferes() {

    const headers = new HttpHeaders({
      Authorization: 'Bearer ' + this.usuario.user.token
    });
    return this.http.get('api/Chofer/GetChofers', { headers });
  }

  GetChofer(id: string) {

    const headers = new HttpHeaders({
      Authorization: 'Bearer ' + this.usuario.user.token
    });
    return this.http.get(`api/Chofer/${id}`, { headers });
  }
}
