import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { TuiDestroyService } from '@taiga-ui/cdk/services';
import { takeUntil } from 'rxjs/operators';
import { UserInfoGet } from '../../models/user-info-get';
import { BackendApiService } from '../../services/backend-api.service';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  private _isToggled = false;
  public userId = this._auth._userId;
  public user: UserInfoGet = {
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


  @Output() public toggleEvent: EventEmitter<boolean> = new EventEmitter();

  constructor(
    private readonly _backendApi: BackendApiService,
    private readonly _auth: AuthService,
    private readonly _router: Router,
    private readonly _destroy$: TuiDestroyService,
    ) {
      this._auth.userId.pipe(takeUntil(this._destroy$)).subscribe(id => {
        this.userId = id;
        this._backendApi.getUserInfoById(id).pipe(takeUntil(this._destroy$))
          .subscribe(user => this.user = user);
      });
    }

  ngOnInit(): void {}

  onToggle() : void {
    this._isToggled = !this._isToggled;
    this.toggleEvent.emit(this._isToggled);
  }

  onLogout(): void {
    this.user = {
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

    this._router.navigate(['/auth']);
  }
}
