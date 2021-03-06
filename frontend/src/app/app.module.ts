import { NgDompurifySanitizer } from "@tinkoff/ng-dompurify";
import { TuiRootModule, TuiDialogModule, TuiAlertModule, TUI_SANITIZER } from "@taiga-ui/core";
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { TeacherComponent } from './components/teacher/teacher.component';
import { HttpClientModule } from '@angular/common/http';
import { ReferenceComponent } from './components/reference/reference.component';
import { ProblemComponent } from './components/problem/problem.component';
import { HeadmenComponent } from './components/headmen/headmen.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AcademicPerfomanceComponent } from './components/academic-perfomance/academic-perfomance.component';
import { CuratorComponent } from './components/curator/curator.component';
import { ListGroupComponent } from './components/list-group/list-group.component';
import { TeacherDetailComponent } from './components/teacher/teacher-detail/teacher-detail.component';
import { NewsItemComponent } from './components/news/news-item/news-item.component';
import { NewsComponent } from './components/news/news/news.component';
import { MapsComponent } from './components/maps/maps.component';

@NgModule({
  declarations: [
    AppComponent,
    TeacherComponent,
    ReferenceComponent,
    ProblemComponent,
    HeadmenComponent,
    ProfileComponent,
    AcademicPerfomanceComponent,
    CuratorComponent,
    ListGroupComponent,
    TeacherDetailComponent,
    NewsItemComponent,
    NewsComponent,
    MapsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    HttpClientModule,
    TuiRootModule,
    TuiDialogModule,
    TuiAlertModule
],
  providers: [{provide: TUI_SANITIZER, useClass: NgDompurifySanitizer}],
  bootstrap: [AppComponent]
})
export class AppModule { }
