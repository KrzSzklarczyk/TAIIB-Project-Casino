import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import{AuthenticatedResponse} from "../../models/authenticated-response";
import { LoginModel } from '../../models/login-model';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  form!: FormGroup;
  invalidLogin: boolean = false;
  isLoginMode: boolean = true;
  credentials: LoginModel = {Login:'', Password:''};

  constructor(private router: Router, private http: HttpClient,private authService:AuthService) { }

  login = ( form: NgForm) => {
    if (form.valid) {
this.invalidLogin=this.authService.logIn(this.credentials);
      if(!this.invalidLogin) 
        this.router.navigate(["/"]);
  }



}
}

