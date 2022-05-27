import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BackendApiService } from './services/backend-api.service';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AuthComponent } from './components/auth/auth.component';
import { HeaderComponent } from './components/header/header.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';


@NgModule({
  declarations: [
    NotFoundComponent,
    AuthComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule
  ],
  providers: [BackendApiService],
  exports: [NotFoundComponent, AuthComponent, HeaderComponent,MatSidenavModule,MatToolbarModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule]
})
export class SharedModule { }
