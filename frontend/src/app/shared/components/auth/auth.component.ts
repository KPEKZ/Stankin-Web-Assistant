import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TuiDestroyService } from '@taiga-ui/cdk/services';
import { takeUntil } from 'rxjs';
import { BackendApiService } from '../../services/backend-api.service';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  public isLogin = false;
  public form : FormGroup;

  constructor(
    private readonly _backendApi: BackendApiService,
    private readonly _router : Router,
    private readonly _destroy$: TuiDestroyService,
    private readonly _auth: AuthService
  ) {
    this.form = new FormGroup({
      "Login": new FormControl(null, Validators.required),
      "Password": new FormControl(null, Validators.required),
      "Group": new FormControl(null, Validators.required),
      "E_mail": new FormControl(null, Validators.required),
      "FirstName": new FormControl(null, Validators.required),
      "SecondName": new FormControl(null, Validators.required),
      "Patronymic": new FormControl(null),
      "PhoneNumber": new FormControl(null, Validators.required),
      "RoleName": new FormControl(null, Validators.required),
      "Permission": new FormControl(null, Validators.required)
    });
   }

  ngOnInit(): void {}

  public onSubmit() {
    this.register();
  }

  public register():void {
    if (this.form.valid) {
      this._backendApi.registerUserInfo({
        Login: this.form.value.Login,
        Password: this.form.value.Password,
        Group: this.form.value.Group,
        E_mail: this.form.value.E_mail,
        FirstName: this.form.value.FirstName,
        SecondName: this.form.value.SecondName,
        Patronymic: this.form.value.Patronymic,
        PhoneNumber: this.form.value.PhoneNumber,
        RoleName: this.form.value.RoleName,
        Permission: this.form.value.Permission,
      });
      this._router.navigate(['/teachers']);
    }

  }

  public login(): void {
    if (this.form.value.Login && this.form.value.Password) {
      this._auth.login(this.form.value.Login,this.form.value.Password);
    }
  }

  public onSwitch(): void {
    this.isLogin = !this.isLogin;
  }

}
