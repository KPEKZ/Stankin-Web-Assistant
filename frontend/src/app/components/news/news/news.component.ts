import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  public isAdmin = this._auth._isAdmin;

  public form: FormGroup = new FormGroup({
    name: new FormControl(null, Validators.required),
    description: new FormControl(null, Validators.required)
  });

  constructor(
    private readonly _backendApi: BackendApiService,
    private readonly _auth: AuthService
    ) { }

  ngOnInit(): void {
    this._auth.userAdmin.subscribe(isAdmin => this.isAdmin = isAdmin);

  }

  onSave(): void {
    if (this.form.valid) {
      this._backendApi.saveNews({
        Name: this.form.value.name,
        Description: this.form.value.description
      })
    }

  }

}
