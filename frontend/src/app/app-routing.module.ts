import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProblemComponent } from './components/problem/problem.component';
import { ReferenceComponent } from './components/reference/reference.component';
import { TeacherComponent } from './components/teacher/teacher.component';
import { AuthComponent } from './shared/components/auth/auth.component';

const routes: Routes = [
  {
    path: 'auth',
    component: AuthComponent
  },
  {
    path: 'teachers',
    component: TeacherComponent
  },
  {
    path: 'references',
    component: ReferenceComponent
  },
  {
    path: 'problems',
    component: ProblemComponent
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
