import { Injectable } from '@angular/core';
@Injectable()
export class AuthService {
 
    public getToken(): string {
    return localStorage.getItem('jwt');
  }


  public isAuthenticated(): boolean {
    // get the token
    const token = this.getToken();
    // return a boolean reflecting 
    // whether or not the token is expired

    if(!token) return false;

    return this.isTokenExpired(token);
  }
 

  private isTokenExpired(token: string) {
    const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    return expiry * 1000 > Date.now();
  }
}