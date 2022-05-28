import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-academic-perfomance',
  templateUrl: './academic-perfomance.component.html',
  styleUrls: ['./academic-perfomance.component.scss']
})
export class AcademicPerfomanceComponent implements OnInit {
  public id:number = this._auth._userId;
  public text: string='';

  constructor(
    private readonly _auth: AuthService,
    private readonly _backendApi: BackendApiService
    ) {
      this._auth.userId.subscribe(id => {
        this.id = id;
      });
      this._backendApi.getUserPerfomance(this.id)
      .subscribe(perfomance =>
        this.text = perfomance
      );
    }

  ngOnInit(): void {

  }

}
