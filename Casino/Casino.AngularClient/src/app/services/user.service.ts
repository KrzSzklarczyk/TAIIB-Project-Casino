import { Injectable } from '@angular/core';
import {FormGroup} from "@angular/forms";
import { UserResponseDTO } from '../models/user.models';
import { AuthenticatedResponse } from '../models/authenticated-response';
import { UserType } from '../models/UserRole';
import { HttpClient, HttpHeaders } from '@angular/common/http';


export interface ObjectKeyModel {
  [key: string]: any;
}

export interface PatchModel {
  path: string;
  value: any;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor (private http:HttpClient){}
  cred: AuthenticatedResponse = {accessToken:'', refreshToken:''};
  res : UserResponseDTO = { avatar:'',email:'',userType:UserType.User, userId:-2137,credits:-2137,nickName:''
  }

  validateHTML(form: FormGroup, field: string, error: string, excludeErrors: string[] = []): boolean {
    const hasError = form.get(field)?.hasError(error);
    const excludedErrors = excludeErrors.some(excludeError => form.get(field)?.hasError(excludeError));
    return !!hasError && !excludedErrors;
  }

getUserInfo= ():UserResponseDTO=>
  {

    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';

    if (this.cred.accessToken == '' || this.cred.refreshToken == ''){
   this.res.credits=0;
   this.res.nickName='anonymous';
   this.res.userType=UserType.User;
   return this.res;
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
           return response;
          },
        });
    }
    this.res.credits=0;
    this.res.nickName='anonymous';
    this.res.userType=UserType.User;
    return response;
  }


}
