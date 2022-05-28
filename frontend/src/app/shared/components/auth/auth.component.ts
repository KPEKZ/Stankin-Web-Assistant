import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BackendApiService } from '../../services/backend-api.service';

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
    private readonly _router : Router
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
        Permission: this.form.value.RoleName === 'student' ? 'read' : 'write',
      });
      this._router.navigate(['/teachers']);
    }

  }

  public login(): void {

  }

  public onSwitch(): void {
    this.isLogin = !this.isLogin;
  }

}
