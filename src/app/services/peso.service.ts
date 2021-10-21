import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PesoService {
private myAppUrl = "https://localhost:44393/";
private myApiUrl = "api/Carteras/";

  constructor(private http: HttpClient) { 

  }

  getListpesos(): Observable<any>{
    return this.http.get(this.myAppUrl + this.myApiUrl);
  }
}
