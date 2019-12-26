import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { MyDashboardComponent } from './my-dashboard/my-dashboard.component';
import { ProjectBoardComponent } from './project-board/project-board.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatRadioModule, MatCommonModule, 
  MatDatepickerModule, MatFormFieldModule, 
  MatNativeDateModule, MatInputModule, 
  MAT_DATE_LOCALE,
  MAT_DATE_FORMATS,
  DateAdapter} from '@angular/material';
import { MomentDateAdapter, MatMomentDateModule, MAT_MOMENT_DATE_FORMATS, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { JwtModule } from "@auth0/angular-jwt";

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    AuthPageComponent,
    MyDashboardComponent,
    ProjectBoardComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatRadioModule, 
    MatCommonModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    MatMomentDateModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:60359"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [{ provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } } ],
  bootstrap: [AppComponent]
})
export class AppModule { }
