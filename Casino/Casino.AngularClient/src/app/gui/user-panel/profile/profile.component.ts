import { Component, Input } from '@angular/core';
import { AuthenticatedResponse } from '../../../models/authenticated-response';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserType } from '../../../models/UserRole';
import { UserResponseDTO } from '../../../models/user.models';

@Component({
  selector: 'app-user-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent {
  @Input() userName: string = '';
  @Input() credits: number = 0;
  @Input() userRole: UserType = UserType.User;
  @Input() avatar: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getUserInfo();
  }


  cred: AuthenticatedResponse = {
    accessToken: localStorage.getItem('accessToken') ?? '',
    refreshToken: localStorage.getItem('refreshToken') ?? '',
  };

  changeAvatar() {
    // Logic to change avatar
    console.log('Change Avatar clicked');
    this.getUserInfo();
  }

  changePassword() {
    // Logic to change password
    console.log('Change Password clicked');
    this.getUserInfo();
  }

  deleteAccount() {
    // Logic to delete account
    console.log('Delete Account clicked');
    this.getUserInfo();
  }

  logOut() {
    // Logic to log out
    console.log('Logout clicked');
    this.getUserInfo();
  }

  getUserInfo() {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';

    if (this.cred.accessToken == '' || this.cred.refreshToken == '') {
    } else {
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
            this.credits = response.credits;
            this.userRole = response.userType;
            this.avatar = response.avatar;
          },
        });
    }
  }
}
