import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TuiDestroyService } from '@taiga-ui/cdk/services';
import { Observable, takeUntil } from 'rxjs';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { UserInfo } from 'src/app/shared/models/user-info';
import { UserInfoGet } from 'src/app/shared/models/user-info-get';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public isLoading = true;
  public form : FormGroup;
  public userId : number = this._auth._userId;
  public user : UserInfoGet = {
    login: '',
    password: '',
    e_mail: '',
    firstName: '',
    secondName: '',
    patronymic: '',
    phoneNumber: '',
    group: '',
    roleName: '',
    permission: ''
  };


  constructor(
    private readonly _backendApi: BackendApiService,
    private readonly _auth: AuthService,
    private readonly _destroy$: TuiDestroyService,
  ) {
    this.form = new FormGroup({
      login: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
      group: new FormControl(null, Validators.required),
      e_mail: new FormControl(null, Validators.required),
      firstName: new FormControl(null, Validators.required),
      secondName: new FormControl(null, Validators.required),
      patronymic: new FormControl(null),
      phoneNumber: new FormControl(null, Validators.required),
      roleName: new FormControl(null, Validators.required),
      permission: new FormControl(null, Validators.required)
    });
   }

  ngOnInit(): void {
    this._auth.userId.pipe(takeUntil(this._destroy$)).subscribe(id => {
      this.userId = id;
    });

    this._backendApi.getUserInfoById(this.userId)
    .pipe(takeUntil(this._destroy$))
    .subscribe(user => {
      this.user = user;
      this.isLoading = false;
      this.form.patchValue({
        login: user.login,
        password: user.password,
        group: user.group,
        e_mail: user.e_mail,
        firstName: user.firstName,
        secondName: user.secondName,
        patronymic: user.patronymic,
        phoneNumber: user.phoneNumber,
        roleName: user.roleName,
        permission: user.permission
      });
    });

  }

  onSubmit() {
    if (!this.form.invalid) {
      this._backendApi.changeUserInfo({
        UserID:this.userId,
        Login:this.form.value.login,
        Password: this.form.value.password,
        Group: this.form.value.group,
        E_mail: this.form.value.e_mail,
        FirstName: this.form.value.firstName,
        SecondName: this.form.value.secondName,
        Patronymic: this.form.value.patronymic,
        PhoneNumber: this.form.value.phoneNumber,
        RoleName: this.form.value.roleName,
        Permission: this.form.value.permission
      });
      this._auth.userAdmin.next(this.form.value.RoleName === 'admin' ? true : false);
    }
  }

}
