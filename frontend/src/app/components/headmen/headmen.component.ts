import { Component, OnInit } from '@angular/core';
import { TuiDestroyService } from '@taiga-ui/cdk/services';
import { takeUntil } from 'rxjs/operators';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-headmen',
  templateUrl: './headmen.component.html',
  styleUrls: ['./headmen.component.scss']
})
export class HeadmenComponent implements OnInit {
  public groupName ?:any;
  public headMen: string = '';
  public id: number = 1;
  constructor(
    private readonly _backendApi: BackendApiService,
    private readonly _auth: AuthService,
    private readonly _destroy$: TuiDestroyService,
  ) {
    this._auth.userId.pipe(takeUntil(this._destroy$)).subscribe(id => {
      this.id = id;
    })
  }

  ngOnInit(): void {
  }

  public onChange(event: any) {
    this.groupName = event.target.value;
    this._backendApi.getHeadMen(this.groupName,this.id)
      .subscribe(headmen => {
        if (headmen) {
          this.headMen = headmen
        }

      });
  }
}
