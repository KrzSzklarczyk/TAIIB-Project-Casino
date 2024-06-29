import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { UserResponseDTO } from '../../../models/user.models';
import { UserType } from "../../../models/UserRole";
import { AuthenticatedResponse } from '../../../models/authenticated-response';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})

export class HeaderComponent implements OnInit, OnDestroy {
  @Input() userName: string = '';
  @Input() credits: number = 0;
  isDropdownOpen = false;
  
  @Input()  userRole: UserType =UserType.User;
  constructor(private authService: AuthService, private http: HttpClient) {}
  intervalId: any;
  ngOnInit() {
    // Call the methods every second
    this.intervalId = setInterval(() => {
      this.getUsrName();
    //  this.getCredits();
   //   this.getUserRole();
    }, 100);
  }

  ngOnDestroy() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }
  cred: AuthenticatedResponse = {
    accessToken: localStorage.getItem('accessToken') ?? '',
    refreshToken: localStorage.getItem('refreshToken') ?? '',
  };
  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  isUserAuthenticated = (): boolean => {
    return this.authService.isUserAuthenticated();
  };
  getUsrName() {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';

    if (this.cred.accessToken == '' || this.cred.refreshToken == ''){
      this.userName = 'anonymous';
    this.credits=0;
    this.userRole=UserType.User;
    }
    else {
      this.http
        .post<UserResponseDTO>(
          'https://localhost:7063/Account/getUserInfo',
          this.cred,
          {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
          }
        )
        .subscribe({
          next: (response: UserResponseDTO) => {
            this.userName = response.nickName;
            this.credits=response.credits;
            this.userRole=response.userType;
          },
        });
    }
  }/*
  getCredits() {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    {
      this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';

      if (this.cred.accessToken == '' || this.cred.refreshToken == '')
        this.credits = 0;
      else {
        this.http
          .post<number>(
            'https://localhost:7063/Account/getCredits',
            this.cred,
            {
              headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
            }
          )
          .subscribe({
            next: (response: number) => {
              this.credits = response;
            },
          });
      }
    }
  }
  getUserRole() {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    {
      this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
      if ((this.cred.accessToken == '' || this.cred.refreshToken == ''))
        this.userRole=0
      else{
        this.http
        .post<number>(
          'https://localhost:7063/Account/GetUserRole',
          this.cred,
          {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
          }
        )
        .subscribe({
          next: (response: number) => {
            this.userRole = response;
          },
      });
    }}
  }
  */
  logOut() {
    this.authService.logOut();
  }
}
