import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-reference',
  templateUrl: './reference.component.html',
  styleUrls: ['./reference.component.scss']
})
export class ReferenceComponent implements OnInit {

  public displayedColumns: string[] = ['type', 'department', 'room', 'phone'];
  public dataSource  = [
    {type: 'Справка с места обучения',department: 'управление персоналом', room: 'каб. 0609', phone: '+7(499)972-95-13'},
    {type: 'Справка о периоде обучения',department: 'Единый деканат', room: 'ауд. 233', phone: '+7(499)973-38-34'},
    {type: 'Справка для военкомата',department: 'второй отдел', room: 'каб. 0605', phone: '+7(499)972-94-24'},
    {type: 'Справка о размере и наличии стипендии',department: 'Бухгалтерия', room: 'фауд. 0732', phone: '+7(499)-972-94-55'},
  ];

  constructor() {

   }

  ngOnInit(): void {
  }

}
