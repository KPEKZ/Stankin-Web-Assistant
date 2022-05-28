import { Component, OnInit } from '@angular/core';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-headmen',
  templateUrl: './headmen.component.html',
  styleUrls: ['./headmen.component.scss']
})
export class HeadmenComponent implements OnInit {
  public groupName ?:any;
  public headMen: string = '';
  constructor(private readonly _backendApi: BackendApiService) { }

  ngOnInit(): void {
  }

  public onChange(event: any) {
    this.groupName = event.target.value;
    this._backendApi.getHeadMen(this.groupName)
      .subscribe(headmen => this.headMen = headmen);
  }
}
