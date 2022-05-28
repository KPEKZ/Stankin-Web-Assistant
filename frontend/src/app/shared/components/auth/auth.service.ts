import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { TuiDestroyService } from "@taiga-ui/cdk/services";
import { takeUntil } from "rxjs";
import { BackendApiService } from "../../services/backend-api.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _isLogged = false;

  public get isLogged() {
    return this._isLogged;
  }

  public set isLogged(value: boolean) {
    this._isLogged = value;
  }
  constructor(
    private readonly _backendApi: BackendApiService,
    private readonly _destroy$: TuiDestroyService,
    private readonly _router: Router
  ) {

  }

  public login(login: string, password: string) {
    this._backendApi.loginUserInfo(login,password)
    .pipe(takeUntil(this._destroy$))
    .subscribe(user => {
      if (user === null) {
        alert('Неправильный логин или пароль, попробуйте снова!');
      } else {
        this.isLogged = true;
        this._router.navigate(['/teachers']);
      }
    });

  }


}
