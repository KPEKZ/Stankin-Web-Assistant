import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { TuiDestroyService } from '@taiga-ui/cdk/services';
import { takeUntil } from 'rxjs';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { problemGet } from 'src/app/shared/models/problem-get';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss']
})
export class ProblemComponent implements OnInit {
  public isLoading = true;
  public isAdmin = this._auth._isAdmin;

  @ViewChild(MatTable)
  table!: MatTable<{
    type: string;
    department: string;
    room: string;
    phone: string;
  }>;

  public displayedColumns: string[] = ['type', 'department', 'audience', 'phoneNumber'];
  public dataSource: problemGet[]  = [

  ];

  constructor(
    private readonly _auth: AuthService,
    private readonly _backendApi: BackendApiService,
    private readonly _destroy$: TuiDestroyService,
  ) {
    this._auth.userAdmin.pipe(takeUntil(this._destroy$)).subscribe(isAdmin => {
      this.isAdmin = isAdmin;
    });
    this._backendApi.getProblems().pipe(takeUntil(this._destroy$))
      .subscribe(problems => {
        if (problems) {
          this.dataSource.push(...problems);
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
      this._backendApi.saveProblem({
        Type: problem.type,
        Department: problem.department,
        Audience: problem.audience,
        PhoneNumber: problem.phoneNumber
      });
    }
  }

}
