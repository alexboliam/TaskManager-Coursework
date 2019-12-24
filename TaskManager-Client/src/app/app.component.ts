import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'Task Manager';

  public selectedProjectId: string;

  constructor(httpClient: HttpClient,
              private router: Router,
              private route: ActivatedRoute) {

  }

  public onSelect(projectId: string) {
      this.selectedProjectId = projectId;
  }
}
