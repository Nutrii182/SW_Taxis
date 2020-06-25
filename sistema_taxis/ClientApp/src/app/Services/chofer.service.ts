import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChoferService {

  constructor(private http: HttpClient) {
    console.log('Servicio Chofer Listo');
  }

  GetChoferes() {
    return this.http.get('api/Chofer/ObtenerChoferes');
  }
}
