import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AcademicPerfomanceComponent } from './components/academic-perfomance/academic-perfomance.component';
import { CuratorComponent } from './components/curator/curator.component';
import { HeadmenComponent } from './components/headmen/headmen.component';
import { ListGroupComponent } from './components/list-group/list-group.component';
import { ProblemComponent } from './components/problem/problem.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ReferenceComponent } from './components/reference/reference.component';
import { TeacherDetailComponent } from './components/teacher/teacher-detail/teacher-detail.component';
import { TeacherComponent } from './components/teacher/teacher.component';
import { AuthComponent } from './shared/components/auth/auth.component';
import { AuthGuard } from './shared/components/auth/auth.guard';

const routes: Routes = [
  {
    path: 'auth',
    component: AuthComponent
  },
  {
    path: 'teachers',
    canActivate: [AuthGuard],

    children: [
      {
        path: '',
        component: TeacherComponent,
      },

      {
        path: 'detail/:id',
        component: TeacherDetailComponent,

      }
    ]
  },
  {
    path: 'references',
    component: ReferenceComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'problems',
    component: ProblemComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'headmen',
    component: HeadmenComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'curator',
    component: CuratorComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'listGroup',
    component: ListGroupComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'perfomance',
    component: AcademicPerfomanceComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: 'auth'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
