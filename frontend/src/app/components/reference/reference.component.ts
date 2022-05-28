import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-reference',
  templateUrl: './reference.component.html',
  styleUrls: ['./reference.component.scss']
})
export class ReferenceComponent implements OnInit {
  public isAdmin = this._auth._isAdmin;

  public displayedColumns: string[] = ['type', 'department', 'room', 'phone'];
  public dataSource  = [
    {type: 'Справка с места обучения',department: 'управление персоналом', room: 'каб. 0609', phone: '+7(499)972-95-13'},
    {type: 'Справка о периоде обучения',department: 'Единый деканат', room: 'ауд. 233', phone: '+7(499)973-38-34'},
    {type: 'Справка для военкомата',department: 'второй отдел', room: 'каб. 0605', phone: '+7(499)972-94-24'},
    {type: 'Справка о размере и наличии стипендии',department: 'Бухгалтерия', room: 'фауд. 0732', phone: '+7(499)-972-94-55'},
  ];

  @ViewChild(MatTable)
  table!: MatTable<{
    type: string;
    department: string;
    room: string;
    phone: string;
  }>;

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
