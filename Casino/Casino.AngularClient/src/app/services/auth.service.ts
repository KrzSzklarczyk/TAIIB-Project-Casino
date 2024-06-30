import { Injectable } from '@angular/core';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { LoginModel } from '../models/login-model';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AuthenticatedResponse } from '../models/authenticated-response';
import { UserRegisterRequestDTO } from '../models/register-model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper: JwtHelperService,private http: HttpClient,private router :Router) { }

  isUserAuthenticated(): boolean {
    const token = localStorage.getItem("accessToken");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  }

  logOut = () => {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
  }
  
  logIn = (creds:LoginModel) :boolean=>{

this.http.post<AuthenticatedResponse>("https://localhost:7063/Account/Login", creds, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
  
        const token = response.accessToken;
          const refreshToken = response.refreshToken;
          localStorage.setItem("accessToken", token);
          localStorage.setItem("refreshToken", refreshToken);
          this.router.navigate(["/"]);
          return false;
        },
        error: (err: HttpErrorResponse) =>{ return true}
      });return true;
    }
register = (userDto:UserRegisterRequestDTO ):boolean =>
    {

 this.http.post<AuthenticatedResponse>("https://localhost:7063/Account/register", userDto, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.accessToken;
          const refreshToken = response.refreshToken;
          localStorage.setItem("accessToken", token);
          localStorage.setItem("refreshToken", refreshToken);
          this.router.navigate(["/"]);
         return false;
        },
        error: (err: HttpErrorResponse) => {return true}
    });return true
  }
}
  
  
  
