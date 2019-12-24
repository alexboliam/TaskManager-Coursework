import { EmployeeTask } from './employee';

export interface Task {
    taskId: string,
    name: string,
    description: string,
    status: number,
    loginOfCreatedBy: string,
    deadline: Date,
    employeesOnTask: EmployeeTask[]
}