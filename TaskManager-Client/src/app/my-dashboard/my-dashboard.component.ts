import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from '../model/project';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-my-dashboard',
  templateUrl: './my-dashboard.component.html',
  styleUrls: ['./my-dashboard.component.css']
})
export class MyDashboardComponent implements OnInit {

  private httpClient: HttpClient;
  public myProjectsList: Project[];
  public projectsList: Project[];

  public status(value: number):string {
    switch(value){
      case 0: return "Created";
      case 1: return "In progress";
      case 2: return "Done";
      case 3: return "Overdue";
    }
  }

  constructor(httpClient:HttpClient,
    private router: Router,
    private route: ActivatedRoute) {
      this.httpClient = httpClient;
  }

  ngOnInit() {
    this.httpClient.get<Project[]>('api/projects/test_login')
            .subscribe(projectsList => {
                this.projectsList = projectsList;
                console.log(this.projectsList);
            }, err => {
                if (err.status === 401) {
                    alert('Log in!');
                }
            });
  }
  public goToProject(projectId: string){
      this.router.navigate(['/myprojects/'+ projectId]);
  }
  public createProject(){
    console.log("someone wants to create project!");
  }
}
