import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProblemComponent } from './components/problem/problem.component';
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
    path: '**',
    redirectTo: 'auth'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
