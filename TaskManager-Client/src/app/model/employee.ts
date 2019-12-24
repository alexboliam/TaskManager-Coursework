import { Task } from './task';

export interface Employee {
    employeeId:string,
    login:string,
}
export interface Team{
    teamId:string,
    name:string,
    teamMembers:EmployeeTeam[]
}
export interface EmployeeTeam{
    employeeId:string,
    employee: Employee,
    teamId:string,
    team:Team
}
export interface EmployeeTask{
    employeeId:string,
    employee: Employee,
    taskId:string,
    task:Task
}