import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
//#region .. Private Fields ..
private accountBaseUrl = environment.apiBaseUrl + "/api/account";
//#endregion

//#region .. Constructors ..
constructor(private http: HttpClient) {
 
}

authenticate(email: string, password: string): Observable<any>{
  return this.http.post(this.accountBaseUrl + '/authenticate', 
  {
    email: email,
    password: password
  });
}
}
