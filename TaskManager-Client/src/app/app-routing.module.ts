import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyDashboardComponent } from './my-dashboard/my-dashboard.component';
import { ProjectBoardComponent } from './project-board/project-board.component';
import { AuthPageComponent } from './auth-page/auth-page.component';


const routes: Routes = [
    { path: 'myprojects', component: MyDashboardComponent },
    { path: 'myprojects/:id', component: ProjectBoardComponent },
    { path: '', redirectTo:'/myprojects', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
