import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  form!: FormGroup;
  invalidLogin: boolean = false; 
  isLoginMode: boolean = true;

  //credentials: LoginModel = {emailAddress:'', password:''};

  constructor(private router: Router, private http: HttpClient) { }

  login = ( form: NgForm) => {
    if (form.valid) {
      this.http.post<AuthenticatedResponse>("http://localhost:5080/api/account/login", this.credentials, {
        headers: new HttpHeaders({ "Content-Type": "application/json"})
      })
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.accessToken;
          const refreshToken = response.refreshToken;
          localStorage.setItem("accessToken", token); 
          localStorage.setItem("refreshToken", refreshToken);
          this.invalidLogin = false; 
          this.router.navigate(["/"]);
        },
        error: (err: HttpErrorResponse) => this.invalidLogin = true
      })
    }
  }

  
}