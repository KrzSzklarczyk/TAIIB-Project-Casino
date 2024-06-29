import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { UserResponseDTO } from '../../../models/user.models';
import { UserRole } from "../../../models/UserRole";
import { AuthenticatedResponse } from '../../../models/authenticated-response';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})

export class HeaderComponent implements OnInit, OnDestroy {
  @Input() userName: string = '';
  @Input() credits: number = 0;
  @Input() rola: String ='';
  isDropdownOpen = false;
  userRoleEnum: typeof UserRole = UserRole
  userRole: UserRole | undefined = undefined
  constructor(private authService: AuthService, private http: HttpClient) {}
  intervalId: any;
  ngOnInit() {
    // Call the methods every second
    this.intervalId = setInterval(() => {
      this.getUsrName();
      this.getCredits();
      this.getUserRole();
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

    if (this.cred.accessToken == '' || this.cred.refreshToken == '')
      this.userName = 'anonymous';
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
          },
        });
    }
  }
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
      if (!(this.cred.accessToken == '' || this.cred.refreshToken == ''))
        this.http
        .post<String>(
          'https://localhost:7063/Account/GetUserRole',
          this.cred,
          {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
          }
        )
        .subscribe({
          next: (response: String) => {
            this.rola = response;
          },
      });
    }
  }
  
  logOut() {
    this.authService.logOut();
  }
}
