import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransferirService {

  private myAppUrl = "https://localhost:44393/";
  private myApiUrl = "api/Tranferencias/"

  constructor(private http: HttpClient) { }

  transferirSaldo(form: any): Observable<any> {
    return this.http.post(this.myAppUrl + this.myApiUrl, form);
  }
}
