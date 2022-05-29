import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { problemGet } from 'src/app/shared/models/problem-get';
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

  public displayedColumns: string[] = ['type', 'department', 'audience', 'phoneNumber'];
  public dataSource: problemGet[]  = [

  ];

  constructor(
    private readonly _auth: AuthService,
    private readonly _backendApi: BackendApiService
  ) {
    this._auth.userAdmin.subscribe(isAdmin => {
      this.isAdmin = isAdmin;
    });
    this._backendApi.getProblems()
      .subscribe(problems => {
        if (problems) {
          this.dataSource.push(...problems);
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
      console.log(problem)
      this._backendApi.saveProblem({
        Type: problem.type,
        Department: problem.department,
        Audience: problem.audience,
        PhoneNumber: problem.phoneNumber
      });
    }
  }

}
