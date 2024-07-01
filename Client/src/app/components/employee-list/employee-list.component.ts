import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  standalone: true,
  imports: [CommonModule, MatTableModule, MatCardModule, RouterModule],
})
export class EmployeeListComponent implements OnInit {
  employees: any[] = [];
  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'email',
    'phoneNumber',
    'position',
    'department',
    'actions',
  ];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe((data) => {
      this.employees = data;
    });
  }

  deleteEmployee(id: string): void {
    this.employeeService.deleteEmployee(id).subscribe(() => {
      this.employees = this.employees.filter((employee) => employee.id !== id);
    });
  }
}
