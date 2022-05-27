import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { EmployeeDto } from '../models/employee-dto';

@Injectable()
export class BackendApiService {
  private _stankinUrl = 'https://rinh-api.kovalev.team/';

  constructor(private readonly _http: HttpClient) {}

  public getEmployee(): Observable<Employee[]> {
    return this._http.get<Employee[]>(this._stankinUrl + 'employee');
  }

  public getEmployeeByid(id:number): Observable<Employee> {
    return this._http.get<Employee>(this._stankinUrl + 'employee/' + id);
  }

  public getEmployeeDtoById(id: number): Observable<EmployeeDto> {
    return this._http.get<EmployeeDto>(this._stankinUrl + 'employee/dto/' + id);
  }
}
