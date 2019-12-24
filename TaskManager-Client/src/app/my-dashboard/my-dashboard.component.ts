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
  public myProjects: Project[];
  public otherProjects: Project[];
  public projectsList: Project[];
  public showMode: number;
  public newProject: Project = {
    projectId: "",
    name: "",
    dateCreation: new Date(),
    deadline: new Date(),
    createdByLogin: "test_login",
    status: 0
  }

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
    this.showMode = 0;
    this.LoadInfo();
    this.ResetNewProject();
  }
  private ResetNewProject(){
    this.newProject.projectId = "";
    this.newProject.name = "";
    this.newProject.dateCreation = new Date();
    this.newProject.deadline = new Date();
    this.newProject.deadline.setDate(this.newProject.deadline.getDate()+1);
    this.newProject.createdByLogin = "test_login";
    this.newProject.status = 0;
  }
  public LoadInfo(){
    this.httpClient.get<Project[]>('api/projects/test_login')
            .subscribe(projectsList => {
                this.projectsList = projectsList;
                console.log("1----------------");
                console.log(this.projectsList);
                this.myProjects = projectsList.filter(x=>x.createdByLogin=='test_login');
                this.otherProjects = projectsList.filter(x=>x.createdByLogin!='test_login')
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
    this.ResetNewProject()
    this.showMode = 1;
  }

  public onProjCreate() {
    this.newProject.createdByLogin = 'test_login';
    this.newProject.dateCreation = new Date();
    this.newProject.status = 0;

    this.httpClient.post('api/projects', this.newProject)
        .subscribe( success=> {
          this.LoadInfo();
        }, err=>{
          if(err.status+""=="500")
          {
            console.log("Internal server error.");
            this.LoadInfo();
          }

          if(err.status+""=="201")
          {
            console.log("Project created.");
            this.LoadInfo();
          }
        });
        this.LoadInfo();
        this.onHideClick();
  }
  public onFormClick(event: MouseEvent) {
    event.stopPropagation();
  }
  public onHideClick() {
    this.showMode = 0;
    this.LoadInfo();
  }
}
