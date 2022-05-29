import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { TuiDestroyService } from '@taiga-ui/cdk/services';
import { takeUntil } from 'rxjs/operators';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { IreferenceGet } from 'src/app/shared/models/reference-get';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-reference',
  templateUrl: './reference.component.html',
  styleUrls: ['./reference.component.scss']
})
export class ReferenceComponent implements OnInit {
  public isAdmin = this._auth._isAdmin;
  public isLoading = true;
  public displayedColumns: string[] = ['type', 'department', 'audience', 'phoneNumber'];
  public dataSource : IreferenceGet[]  = [

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
    private readonly _backendApi: BackendApiService,
    private readonly _destroy$: TuiDestroyService,
  ) {
    this._auth.userAdmin.pipe(takeUntil(this._destroy$)).subscribe(isAdmin => {
      this.isAdmin = isAdmin;
    });
    this._backendApi.getReferences().pipe(takeUntil(this._destroy$))
    .subscribe(references => {
      if (references) {
        this.dataSource.push(...references);
        this.isLoading = false;
      }
    });

   }

  ngOnInit(): void {
  }

  addData(type: HTMLInputElement, dep: HTMLInputElement, room: HTMLInputElement, phone: HTMLInputElement) {
    this.dataSource.push({type: type.value, department: dep.value, audience: room.value, phoneNumber: phone.value});
    this.table.renderRows();
  }

  removeData() {
    this.dataSource.pop();
    this.table.renderRows();
  }

  onSave() {
    for(let problem of this.dataSource) {
      this._backendApi.saveReference({
        Type: problem.type,
        Department: problem.department,
        Audience: problem.audience,
        PhoneNumber: problem.phoneNumber
      });
    }
  }

}
