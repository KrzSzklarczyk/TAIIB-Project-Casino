import { Component, OnInit } from '@angular/core';

import { UserResponseDTO } from '../../../models/user.models';
import { AuthenticatedResponse } from '../../../models/authenticated-response';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-admin-panel-user',
  templateUrl: './admin-panel-user.component.html',
  styleUrls: ['./admin-panel-user.component.css']
})
export class AdminPanelUserComponent implements OnInit {
  Users: UserResponseDTO[] = [];
  cred:AuthenticatedResponse ={accessToken:'',refreshToken:''}
  constructor(private http:HttpClient) {}
  displayedColumns: string[] = ['userId', 'email', 'nickName', 'avatar', 'credits', 'userType', 'actions'];

  ngOnInit(): void {
   
   this.GetAllUsers();
    console.log(this.Users);
  }
  GetAllUsers=():void=>
    {this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
        this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
        
    this.Users=[];
        if (this.cred.accessToken == '' || this.cred.refreshToken == '') {
         return
        
         }
        
        this.http.post<UserResponseDTO[]>("https://localhost:7063/Account/getAllUsers", this.cred, {
            headers: new HttpHeaders({ "Content-Type": "application/json"})
          })
          .subscribe({
            next: (response: UserResponseDTO[]) => {
            
              this.Users=response;
             
            },
            error: (err: HttpErrorResponse) => {this.Users=[]}
          });
         
    }
    RemoveUser=( id:number ):void=>
      {
        this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
        this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
        
   
        if (this.cred.accessToken == '' || this.cred.refreshToken == '') {
         return
        
         }
         const url = `https://localhost:7063/Account/RemoveUser/${id}`;
        this.http.post<boolean>(url, this.cred, {
            headers: new HttpHeaders({ "Content-Type": "application/json"})
          })
          .subscribe({
            next: (response: boolean) => {
            
              if(response)
                {
this.GetAllUsers();
return
                }
             
            },
            error: (err: HttpErrorResponse) => {return}
          });
      }
}
