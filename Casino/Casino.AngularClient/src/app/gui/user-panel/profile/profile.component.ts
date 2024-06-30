import { Component, Input } from '@angular/core';
import { AuthenticatedResponse } from '../../../models/authenticated-response';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { UserType } from '../../../models/UserRole';
import { UserResponseDTO } from '../../../models/user.models';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { UserChangeDTO } from '../../../models/userChangeDto';

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
  showChangePasswordForm = false;
  changePasswordForm: FormGroup;
  
  //form!: FormGroup;
  //validateHTML = this.userService.validateHTML.bind(this.userService)

  constructor(private fb: FormBuilder, private formBuilder: FormBuilder, private http: HttpClient, private userService: UserService) { 
    this.changePasswordForm = this.fb.group({
      currentPassword: ['', Validators.required],
      newPassword: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit() {
    this.getUserInfo();
    // this.form.get('password')?.setValidators([
    //   Validators.required,
    //   Validators.minLength(6),
    //   this.userService.passwordValidator()
    // ])

    // this.form.addControl('confirmedPassword', this.formBuilder.control(
    //   'User1234!',
    //   [Validators.required,
    //     this.userService.passwordMatchValidator(this.form)
    //   ]));
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

  toggleChangePasswordForm() {
    this.getUserInfo();
    this.showChangePasswordForm = !this.showChangePasswordForm;
  }

  changePassword() {
    
    if (this.changePasswordForm.valid) {
      console.log("test")
      const newPassword = this.changePasswordForm.get('newPassword')?.value;
      this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
        this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
        
   const us:UserChangeDTO = { token:this.cred, cos : newPassword}
        if (this.cred.accessToken == '' || this.cred.refreshToken == '') {
         
         return
        
         }
        
        this.http.put<boolean>("https://localhost:7063/Account/ChangePasswd", us, {
            headers: new HttpHeaders({ "Content-Type": "application/json"})
          })
          .subscribe({
            next: (response: boolean) => {
             
             return
            },
            error: (err: HttpErrorResponse) => {return}
          }); 
      }
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
