import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { UserResponseDTO } from '../../../models/user.models';
import { AuthenticatedResponse } from '../../../models/authenticated-response';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent  implements OnInit, OnDestroy{
  
  constructor(private authService: AuthService, private http: HttpClient) { }
  intervalId: any;
  ngOnInit() {
    // Call the methods every second
    this.intervalId = setInterval(() => {
      this.getUsrName();
      this.getCredits();
    }, 100);
  }
  ngOnDestroy() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }
  @Input() userName: string = 'anonymous';
  @Input() credits: number = 0;
  isDropdownOpen = false;
  cred :AuthenticatedResponse ={accessToken:localStorage.getItem("accessToken")??'',refreshToken:localStorage.getItem("refreshToken")??''};
  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
   
  }

  isUserAuthenticated = (): boolean => {
    return this.authService.isUserAuthenticated();
  }
getUsrName()
{this.cred.accessToken=localStorage.getItem("accessToken")??'';
this.cred.refreshToken=localStorage.getItem("refreshToken")??'';

  if(this.cred.accessToken==''||this.cred.refreshToken=='')this.userName='anonymous'
  else{
  this.http.post<UserResponseDTO>("https://localhost:7063/Account/getUserInfo", this.cred, {
    headers: new HttpHeaders({ "Content-Type": "application/json"})
  })
  .subscribe({
    next: (response: UserResponseDTO) => {
      this.userName= response.nickName;
    },
    
  }
 ); 
}}
getCredits()
{
  this.cred.accessToken=localStorage.getItem("accessToken")??'';
  {this.cred.refreshToken=localStorage.getItem("refreshToken")??'';
  
    if(this.cred.accessToken==''||this.cred.refreshToken=='')this.credits=0 ;
    else{
    this.http.post<number>("https://localhost:7063/Account/getCredits", this.cred, {
      headers: new HttpHeaders({ "Content-Type": "application/json"})
    })
    .subscribe({
      next: (response: number) => {
        this.credits=response;
      },
      
    }
   )
  }
}
}
  logOut() {
    this.authService.logOut();
  }

}

