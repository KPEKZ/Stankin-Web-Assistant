import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MonoTypeOperatorFunction, Observable } from 'rxjs';
import { authData } from '../models/authData';
import { Employee } from '../models/employee';
import { EmployeeDto } from '../models/employee-dto';
import { UserInfo } from '../models/user-info';
import { Role } from '../models/user-role';

@Injectable({
  providedIn: 'root'
})
export class BackendApiService {

  private _stankinUrl = 'https://rinh-api.kovalev.team/';
  private _localhost = 'http://localhost:5000/api/';

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

  public registerUserInfo(userInfo : UserInfo): void {
    this._http.post(this._localhost + 'UserInfo',userInfo).subscribe();
  }
  public registerUserAuthData(userAuthDate: authData,): void {
    this._http.post(this._localhost + 'UserAuthData',userAuthDate).subscribe();
  }

  public registerUserRole(roleName: Role): void {
    this._http.post(this._localhost + 'Roles',roleName).subscribe();
  }

}
