import { Component, OnInit } from '@angular/core';
import { ModsService } from '../../../services/mods.service';
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
  constructor(private modsService: ModsService,private http:HttpClient) {}

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
}
