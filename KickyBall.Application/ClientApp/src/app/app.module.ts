import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PlayComponent } from './play/play.component';
import { AdminComponent } from './admin/admin.component';
import { Controllers } from 'src/controllers/controllers';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './helpers/auth.guard';
import { RegisterComponent } from './register/register.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { UserGameStatsModal } from './admin/userGameStatsModal/user-game-stats.modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { AuthenticatedUser } from 'src/models/authenticatedUser.model';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PlayComponent,
    AdminComponent,
    UserGameStatsModal,
    LoginComponent,
    RegisterComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: WelcomeComponent, canActivate: [AuthGuard] },
      { path: 'play', component: PlayComponent, canActivate: [AuthGuard] },
      { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ]),
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [
    Controllers,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
