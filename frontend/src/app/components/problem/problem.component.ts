import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss']
})
export class ProblemComponent implements OnInit {

  public displayedColumns: string[] = ['type', 'department', 'room', 'phone'];
  public dataSource  = [
    {type: 'Утеря пропуска',department: 'Единый деканат', room: 'ауд. 233', phone: '+7(499)973-38-34'},
    {type: 'Проблема с модульным журналом',department: 'Единый деканат', room: 'ауд. 233', phone: '+7(499)973-38-34'},
    {type: 'Проблема с ЭОС',department: '-', room: 'ТП 3-9', phone: '-'},
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
