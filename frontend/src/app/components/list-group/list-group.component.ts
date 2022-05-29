import { Component, OnInit } from '@angular/core';
import { TuiDestroyService } from '@taiga-ui/cdk/services';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { UserInfoGet } from 'src/app/shared/models/user-info-get';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-list-group',
  templateUrl: './list-group.component.html',
  styleUrls: ['./list-group.component.scss']
})
export class ListGroupComponent implements OnInit {
  public isLoading = true;
  public id = this._auth._userId;
  public text: string = '';
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
  public groupList: RegExpMatchArray[] = [];

  constructor(
    private readonly _auth: AuthService,
    private readonly _backendApi: BackendApiService,
    private readonly _destroy$: TuiDestroyService,
  ) { }

  ngOnInit(): void {
    this._auth.userId.pipe(takeUntil(this._destroy$)).subscribe(id => {
      this.id = id;
    });
    this._backendApi.getUserInfoById(this.id).pipe(
      switchMap(userInfo => {
        return this._backendApi.getUserListGroup(this.id,userInfo.group);
      }),
      tap(() => this.isLoading = false),
      takeUntil(this._destroy$)
    )
    .subscribe(text => {
      this.groupList = this.textTransform(text);
      this.isLoading = false;
    });

  }

  textTransform(str: string): RegExpMatchArray[] {
    const regex = /\d+\s\W+/gm;
    const arr = [...str.matchAll(regex)];
    return arr;
  }

}
