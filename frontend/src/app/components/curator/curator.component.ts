import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-curator',
  templateUrl: './curator.component.html',
  styleUrls: ['./curator.component.scss']
})
export class CuratorComponent implements OnInit {
  public id:number = this._auth._userId;
  public text: string='';

  constructor(
    private readonly _auth: AuthService,
    private readonly _backendApi: BackendApiService
  ) { }

  ngOnInit(): void {
    this._auth.userId.subscribe(id => {
      this.id = id;
    });
    this._backendApi.getUserCuratorById(this.id)
    .subscribe(perfomance =>
      this.text = perfomance
    );
  }

}
