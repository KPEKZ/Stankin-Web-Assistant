import { HttpClient, HttpHeaders, HttpUrlEncodingCodec } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { EmployeeDto } from '../models/employee-dto';
import { UserInfo } from '../models/user-info';
import { UserInfoGet } from '../models/user-info-get';

@Injectable({
  providedIn: 'root'
})
export class BackendApiService {

  private _stankinUrl = 'https://rinh-api.kovalev.team/';
  private _localhost = 'http://localhost:5000/api/';
  private _codec = new HttpUrlEncodingCodec();
  private httpHeader = new HttpHeaders();


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

  public loginUserInfo(login: string, password: string): Observable<UserInfoGet> {
    return this._http.get<UserInfoGet>(this._localhost + `UserInfo/${login}/${password}`)
  }

  public getHeadMen(groupName: string): Observable<string> {
    console.log(groupName, groupName.toUpperCase());
    const year: number = parseInt('20' + groupName.toUpperCase().split('-')[1],10);
    const curYear: number = new Date().getFullYear();
    const lvl = curYear - year;
    console.log(year, curYear,lvl);
    const codec = new HttpUrlEncodingCodec();
    const url =  codec.decodeKey(codec.encodeKey(this._localhost + `Excel/HeadMen/${groupName.toUpperCase()}/${lvl}`));
    console.log(url.toString());
    return this._http.get<string>(JSON.stringify(url).toString());
  }


  public getUserInfoById(userId: number): Observable<UserInfoGet> {
    return this._http.get<UserInfoGet>(this._localhost + 'UserInfo/' + userId );
  }

}
