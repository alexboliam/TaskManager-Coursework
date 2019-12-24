import { Component, OnInit, Input } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import {formatDate} from '@angular/common';
import { Task } from '../model/task';
import { Router, ActivatedRoute } from '@angular/router';
import { TemplateAst } from '@angular/compiler';
import { Team, Employee, EmployeeTeam, EmployeeTask } from '../model/employee';

@Component({
  selector: 'app-project-board',
  templateUrl: './project-board.component.html',
  styleUrls: ['./project-board.component.css']
})
export class ProjectBoardComponent implements OnInit {

  public newTask: Task = {
    taskId: "",
    name: "",
    description: "",
    status: 0,
    loginOfCreatedBy: "",
    deadline: new Date(),
    employeesOnTask: null
  }
  public StatusCheckBox: number;
  public tasks: Task[];
  public Error:string;
  public createdTasks: Task[];
  public progressTasks: Task[];
  public doneTasks: Task[];
  public overduedTasks: Task[];
  public team: Team;
  public teamMembers: EmployeeTeam[];
  public showMode = 0;
  public shownTask: Task;
  public isChecked: boolean;
  private httpClient: HttpClient;
  private currDate: Date;
  public newmemberlogin: string;
  public shownTaskEmployees: EmployeeTask[];
  public addMemberValid: boolean;

  public status(value: number):string {
    switch(value){
      case 0: return "Created";
      case 1: return "In progress";
      case 2: return "Done";
      case 3: return "Overdue";
    }
  }

  constructor(httpClient: HttpClient,
    private router: Router,
    private route: ActivatedRoute) { 
    this.httpClient= httpClient;
  }

  ngOnInit() {
    this.load(this.route.snapshot.paramMap.get('id'));
    this.addMemberValid = true;
    this.currDate = new Date();
  }
  private resetNewTask()
  {
    this.newTask.taskId = "";
    this.newTask.name = "";
    this.newTask.description = "";
    this.newTask.status = 0;
    this.newTask.loginOfCreatedBy = "";
    this.newTask.deadline = new Date();
    this.newTask.employeesOnTask = null;
  }
  private load(projectId: string) {
    this.resetNewTask();
    this.httpClient.get<Task[]>('api/tasks/project/' + projectId)
      .subscribe(tasks => {
        this.tasks = tasks;
        this.tasks.forEach(element => {
          let datestr = element.deadline.toString();
          element.deadline = new Date(datestr);
          if(element.deadline < this.currDate && element.status!=2)
          {
            element.status = 3;
          }
        }); 

        this.createdTasks = this.tasks.filter(x=>x.status==0);
        this.progressTasks = this.tasks.filter(x=>x.status==1);
        this.doneTasks = this.tasks.filter(x=>x.status==2);
        this.overduedTasks = this.tasks.filter(x=>x.status==3);
        
      });
    this.httpClient.get<Team>('api/projects/' + projectId + '/team')
        .subscribe(team=>{
          this.team = team;
          this.teamMembers = team.teamMembers;
        });
  }
  public createTask(){
    this.resetNewTask();
    this.showMode = 2;
  }
  public updateStatus(value:string){
    if(value == "done")
    {
      this.shownTask.status = 2;
    }
    if(value == "progress")
    {
      this.shownTask.status = 1;
    }
  }
  public openTask(taskId:string){
    this.shownTask = Object.assign({}, this.tasks.find(x=>x.taskId==taskId));
    this.showMode = 1;
    this.StatusCheckBox = this.shownTask.status;

    this.httpClient.get<EmployeeTask[]>('api/tasks/' + this.shownTask.taskId + '/workers')
        .subscribe(employeeTasks=>{
          this.shownTaskEmployees = employeeTasks;
        });
  }
  public addTaskMember()
  {
    this.addMemberValid = true;
    let employeetask: EmployeeTask = {
      employeeId: "0",
      taskId: "0",
      employee: null,
      task: null
    }

      var empls = this.team.teamMembers
          .filter(x=> x.employee.login == this.newmemberlogin);
      if(empls.length < 1) {
          this.Error = "Worker with specified login was not found in team."
          this.addMemberValid = false;
          return;
      }
      else{
          var empl = empls.pop().employee;
      }
      if(this.shownTask.employeesOnTask.find(x=>x.employee.login == empl.login))
      {
        this.addMemberValid = false; 
        this.Error = "Worker is already on this task.";
        return;
      }

      employeetask.employee = empl;
      employeetask.employeeId = empl.employeeId;
      employeetask.taskId = this.shownTask.taskId;
      employeetask.task = this.shownTask;

      this.httpClient.post('api/employees/' + empl.employeeId + '/tasks', employeetask)
          .subscribe(success=>{ 
            this.addMemberValid = true;
            this.load(this.route.snapshot.paramMap.get('id'));   
          }, 
            error =>{ 
              if(<HttpErrorResponse>error.status+"" == "201")
              { 
                this.addMemberValid = true; 
                this.showMode = 0;
                this.openTask(this.shownTask.taskId);
                this.newmemberlogin = "";
                return;
              }
              if(<HttpErrorResponse>error.status+"" == "404")
              {
                this.Error = "Current task was not found in database. Please, update the page and try again.";
              }
              if(<HttpErrorResponse>error.status+"" == "500")
              {
                this.Error = "Internal server error. Try again later.";
              }
              this.addMemberValid = false;  
            });
      this.load(this.route.snapshot.paramMap.get('id'));  
  }
  public onOk()
  {
    this.shownTask.status = this.StatusCheckBox;

    this.httpClient.put<Task>('api/tasks/' + this.shownTask.taskId, this.shownTask)
        .subscribe(scss=>{
          this.load(this.route.snapshot.paramMap.get('id'));
        },
        error=>{
          this.load(this.route.snapshot.paramMap.get('id'));
          
        });
    this.httpClient.put<Team>('api/teams/' + this.team.teamId, this.team)
        .subscribe(scss=>{
          this.load(this.route.snapshot.paramMap.get('id'));
        },
        error=>{
          this.load(this.route.snapshot.paramMap.get('id'));
          
        });
        this.showMode = 0; 
        
  }
  public onTaskCreate() {
    this.newTask.status = 0;
    this.newTask.loginOfCreatedBy = "test_login"; // TODO: change to localstorage

    this.httpClient.post<Task>('api/tasks/project/' + this.route.snapshot.paramMap.get('id'), this.newTask)
        .subscribe(scss=>{
          this.load(this.route.snapshot.paramMap.get('id'));
        },
        error=>{
          if(<HttpErrorResponse>error.status+"" == "401"){
            this.Error = "Task was created.";
            this.addMemberValid = false;
          }
          if(<HttpErrorResponse>error.status+"" == "500"){
            console.log(<HttpErrorResponse>error);
            this.Error = "Internal server error.";
            this.addMemberValid = false;
          }
          this.load(this.route.snapshot.paramMap.get('id'));
          
        });
        this.showMode = 0; 
  }
  public onHideClick() {
    this.showMode = 0;
    this.shownTaskEmployees = null;
  }
  public onFormClick(event: MouseEvent) {
    event.stopPropagation();
  }
  public deleteMember(login:string)
  {
    let employeeteam: EmployeeTeam = {
      employeeId: "0",
      teamId: "0",
      employee: null,
      team: null
    }
    this.httpClient.get<Employee>('api/employees/' + login)
        .subscribe(scss=>{
          employeeteam.employee = scss;
          employeeteam.employeeId = scss.employeeId;
          employeeteam.teamId = this.team.teamId;
          employeeteam.team = this.team;

          this.httpClient.request('delete', 'api/employees/team/' + this.team.teamId, {body: employeeteam} )
          .subscribe(success=>{
              this.load(this.route.snapshot.paramMap.get('id'));
          },
                     error=>{
              this.load(this.route.snapshot.paramMap.get('id'));
          });

          this.showMode = 0; 
          this.load(this.route.snapshot.paramMap.get('id'));
        },
        error=>{
          
        });
    
  }
  public deleteTaskMember(login:string){
      let employeetask: EmployeeTask = {
        employeeId: "0",
        taskId: "0",
        employee: null,
        task: null
      }
      let empls = this.shownTaskEmployees
          .filter(x=> x.employee.login == login);
      if(empls.length < 1) {
          this.Error = "Worker with specified login was not found in current task team."
          this.addMemberValid = false;
          return;
      }
      else{
          var empl = empls.pop().employee;
      }

      employeetask.employee = empl;
      employeetask.employeeId = empl.employeeId;
      employeetask.taskId = this.shownTask.taskId;
      employeetask.task = this.shownTask;

      this.httpClient.request('delete', 'api/employees/tasks/' + this.shownTask.taskId, {body: employeetask} )
          .subscribe(
          success=>{
            this.addMemberValid = true; 
            this.showMode = 0;
            this.openTask(this.shownTask.taskId);
            return;
          },
          error=>{
              if(<HttpErrorResponse>error.status+"" == "204")
              {
                this.addMemberValid = true; 
                this.showMode = 0;
                this.openTask(this.shownTask.taskId);
                return;
              }
              if(<HttpErrorResponse>error.status+"" == "404")
              {
                this.Error = "Current worker&task were not found in database. Please, update the page and try again.";
              }
              if(<HttpErrorResponse>error.status+"" == "500")
              {
                this.Error = "Internal server error. Try again later.";
              }
              this.addMemberValid = false; 
              this.load(this.route.snapshot.paramMap.get('id'));
          });

  }
  public addMember()
  {
      let employeeteam: EmployeeTeam = {
      employeeId: "0",
      teamId: "0",
      employee: null,
      team: null
    }
    this.httpClient.get<Employee>('api/employees/' + this.newmemberlogin)
        .subscribe(scss=>{
          employeeteam.employee = scss;
          employeeteam.employeeId = scss.employeeId;
          employeeteam.teamId = this.team.teamId;
          employeeteam.team = this.team;
        
          if(this.team.teamMembers.find(x=>x.employee.login == scss.login))
          {
            this.addMemberValid = false; 
            this.Error = "Worker is already in this team.";
            return;
          }
          this.httpClient.post('api/employees/team',employeeteam)
          .subscribe(success=>{ }, error =>{ });
          this.addMemberValid = true;
          this.load(this.route.snapshot.paramMap.get('id'));
        },
        error =>{
          if(<HttpErrorResponse>error.status+"" == "404")
          {
            this.Error = "Worker was not found. Check input data on mistakes.";
          }
          if(<HttpErrorResponse>error.status+"" == "500")
          {
            this.Error = "Internal server error. Try again later.";
          }
          this.addMemberValid = false;          
        });
        
  }
}
