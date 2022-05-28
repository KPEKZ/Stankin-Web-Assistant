import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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
    private readonly _auth: AuthService
    ) {
      this._auth.userId.subscribe(id => {
        this.userId = id;
        this._backendApi.getUserInfoById(id)
          .subscribe(user => this.user = user);
      });
    }

  ngOnInit(): void {}

  onToggle() : void {
    this._isToggled = !this._isToggled;
    this.toggleEvent.emit(this._isToggled);
  }
}
