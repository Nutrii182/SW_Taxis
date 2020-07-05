import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UnidadService {

  usuario: any;
  constructor(private http: HttpClient) {
    this.usuario = JSON.parse(localStorage.getItem('usuario'));
  }

  GetUnidades() {

    const headers = new HttpHeaders({
      Authorization: 'Bearer ' + this.usuario.user.token
    });
    return this.http.get('api/Unidad/GetUnidades', { headers });
  }

  GetUnidad(id: string) {
    const headers = new HttpHeaders({
      Authorization: 'Bearer ' + this.usuario.user.token
    });
    return this.http.get(`api/Unidad/GetUnidad/${id}`, { headers });
  }

  DeleteUnidad(id: string) {
    const headers = new HttpHeaders({
      Authorization: 'Bearer ' + this.usuario.user.token
    });
    return this.http.delete(`api/Unidad/${id}`, { headers });
  }
}
