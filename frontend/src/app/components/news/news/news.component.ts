import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/components/auth/auth.service';
import { InewsGet } from 'src/app/shared/models/news-get';
import { BackendApiService } from 'src/app/shared/services/backend-api.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  public isAdmin = this._auth._isAdmin;
  public news: InewsGet[] = [];
  public cachedNews: EventEmitter<InewsGet> = new EventEmitter<InewsGet>();

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
    this._backendApi.getNews().subscribe(news => this.news = news);
    this.cachedNews.subscribe(news => {
      this.news.push(news);
    });
  }

  onSave(): void {
    if (this.form.valid) {
      this._backendApi.saveNews({
        Name: this.form.value.name,
        Discription: this.form.value.description
      });
      this.cachedNews.emit({
        name: this.form.value.name,
        discription: this.form.value.description
      });
      this.form.reset();
    }

  }

}
