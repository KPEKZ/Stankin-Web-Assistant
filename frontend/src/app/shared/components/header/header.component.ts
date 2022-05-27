import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  private _isToggled = false;

  @Output() public toggleEvent: EventEmitter<boolean> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {}

  onToggle() : void {
    this._isToggled = !this._isToggled;
    this.toggleEvent.emit(this._isToggled);
  }
}
