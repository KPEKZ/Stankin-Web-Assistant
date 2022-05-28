import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss']
})
export class ProblemComponent implements OnInit {
  public isAdmin = this._auth._isAdmin;

  @ViewChild(MatTable)
  table!: MatTable<{
    type: string;
    department: string;
    room: string;
    phone: string;
  }>;

  public displayedColumns: string[] = ['type', 'department', 'room', 'phone'];
  public dataSource  = [
    {type: 'Утеря пропуска',department: 'Единый деканат', room: 'ауд. 233', phone: '+7(499)973-38-34'},
    {type: 'Проблема с модульным журналом',department: 'Единый деканат', room: 'ауд. 233', phone: '+7(499)973-38-34'},
    {type: 'Проблема с ЭОС',department: '-', room: 'ТП 3-9', phone: '-'},
  ];

  constructor(
    private readonly _auth: AuthService,
    private readonly _backendApi: BackendApiService
  ) {
    this._auth.userAdmin.subscribe(isAdmin => {
      this.isAdmin = isAdmin;
    });
  }

  ngOnInit(): void {
  }

  addData(type: HTMLInputElement, dep: HTMLInputElement, room: HTMLInputElement, phone: HTMLInputElement) {
    this.dataSource.push({type: type.value, department: dep.value, room: room.value, phone: phone.value});
    this.table.renderRows();
  }

  removeData() {
    this.dataSource.pop();
    this.table.renderRows();
  }

}
