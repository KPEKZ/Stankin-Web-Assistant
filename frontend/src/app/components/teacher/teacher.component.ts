import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { takeUntil } from 'rxjs';
import { Employee } from 'src/app/shared/models/employee';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';
import {TuiDestroyService} from '@taiga-ui/cdk';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.scss']
})
export class TeacherComponent implements OnInit {
  public isLoading = true;
  public displayedColumns: string[] = ['ФИО', 'Почта', 'Телефон', 'Аватар'];
  public shortDataEmployee: string[] = ['fullName', 'email', 'phone', 'authorUrlProfile'];
  public dataSource: MatTableDataSource<Employee>;

  @ViewChild(MatPaginator) public paginator!: MatPaginator;
  @ViewChild(MatSort) public sort!: MatSort;

  constructor(
    private readonly _backendApi: BackendApiService ,
    @Inject(TuiDestroyService) private readonly _destroy$ :TuiDestroyService
  ) {
    this.dataSource = new MatTableDataSource<Employee>();
  }

  ngOnInit(): void {
    this._backendApi.getEmployee()
    .pipe(takeUntil(this._destroy$))
    .subscribe(employees => {
      this.dataSource.data = employees;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.isLoading = false;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
