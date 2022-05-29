import { HttpClient, HttpHeaders, HttpUrlEncodingCodec } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { EmployeeDto } from '../models/employee-dto';
import { Inews } from '../models/news';
import { InewsGet } from '../models/news-get';
import { problem } from '../models/problem';
import { problemGet } from '../models/problem-get';
import { Ireference } from '../models/reference';
import { IreferenceGet } from '../models/reference-get';
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

  public changeUserInfo(userInfo: UserInfo): void {
    this._http.put(this._localhost + 'UserInfo/' + userInfo.UserID,userInfo).subscribe();
  }

  public loginUserInfo(login: string, password: string): Observable<UserInfoGet> {
    return this._http.get<UserInfoGet>(this._localhost + `UserInfo/${login}/${password}`)
  }

  public getHeadMen(groupName: string,id:number) {
    const year: number = parseInt('20' + groupName.toUpperCase().split('-')[1],10);
    const curYear: number = new Date().getFullYear();
    const lvl = curYear - year;
    return this._http.get(this._localhost + `Excel/HeadMen/${id}/${lvl}`, {responseType: 'text'});
  }


  public getUserInfoById(userId: number): Observable<UserInfoGet> {
    return this._http.get<UserInfoGet>(this._localhost + 'UserInfo/' + userId );
  }

  public getUserPerfomance(id: number) {
    return this._http.get(this._localhost + `Excel/Progress/${id}/`, {responseType: 'text'});
  }

  public getUserCuratorById(userId: number) {
    return this._http.get(this._localhost + `Excel/Curator/${userId}/`, {responseType: 'text'});
  }

  public getUserListGroup(userId:number, groupName:string) {
    const year: number = parseInt('20' + groupName.toUpperCase().split('-')[1],10);
    const curYear: number = new Date().getFullYear();
    const lvl = curYear - year;
    return this._http.get(this._localhost + `Excel/ListGroup/${userId}/${lvl}`, {responseType: 'text'});
  }

  public saveProblem(problem: problem) {
    this._http.post(this._localhost + 'Problem', problem).subscribe()
  }

  public getProblems(): Observable<problemGet[]> {
    return this._http.get<problemGet[]>(this._localhost + 'Problem');
  }

  public getReferences(): Observable<IreferenceGet[]> {
    return this._http.get<IreferenceGet[]>(this._localhost + 'Reference');
  }

  public saveReference(reference: Ireference) {
    this._http.post(this._localhost + 'Reference', reference).subscribe()
  }

  public getNews(): Observable<InewsGet[]> {
    return this._http.get<InewsGet[]>(this._localhost + 'News');
  }

  public saveNews(news: Inews) : void {
    this._http.post(this._localhost + 'News', news).subscribe()
  }


}
