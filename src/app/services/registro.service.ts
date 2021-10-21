import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {
  private myAppUrl = "https://localhost:44393/";
  private myApiUrl = "api/Clientes/"

  constructor(private http: HttpClient) { }

  registrarCliente(cliente: any): Observable<any> {
    return this.http.post(this.myAppUrl + this.myApiUrl, cliente);
  }
}
