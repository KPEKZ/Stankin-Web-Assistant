import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeadmenComponent } from './components/headmen/headmen.component';
import { ProblemComponent } from './components/problem/problem.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ReferenceComponent } from './components/reference/reference.component';
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
    component: TeacherComponent,
    canActivate: [AuthGuard]
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
    // canActivate: [AuthGuard]
  },
  {
    path: 'profile',
    component: ProfileComponent,
    // canActivate: [AuthGuard]
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
