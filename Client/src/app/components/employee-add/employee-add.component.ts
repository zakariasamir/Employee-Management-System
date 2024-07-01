import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MatCardModule, MatInputModule, MatFormFieldModule, MatButtonModule]
})
export class EmployeeAddComponent {
  employee = {
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    position: '',
    department: ''
  };

  constructor(private employeeService: EmployeeService, private router: Router) {}

  onSubmit(): void {
    this.employeeService.addEmployee(this.employee).subscribe(() => {
      this.router.navigate(['/employees']);
    });
  }
}
