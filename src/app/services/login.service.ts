import { Injectable } from '@angular/core';
import { LoginI } from '../models/login.interface'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
 
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private myAppUrl = "https://localhost:44393/";
  private myApiUrl = "api/Login/"
  public idClienteLogin: number = 0;

  constructor(private http: HttpClient) { }

  loginConEmailoUsuario(form: any): Observable<any> {
    return this.http.post(this.myAppUrl + this.myApiUrl, form);
  }
}
