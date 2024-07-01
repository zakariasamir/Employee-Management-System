import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, MatCardModule, MatInputModule, MatFormFieldModule, MatButtonModule]
})
export class EmployeeEditComponent implements OnInit {
  employee: Employee = {
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    position: '',
    department: ''
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')!;
    this.employeeService.getEmployeeById(id).subscribe(data => {
      this.employee = data;
    });
  }

  onSubmit(): void {
    this.employeeService.updateEmployee(this.employee).subscribe({
      next: () => {
        console.log('Employee updated successfully');
        this.router.navigate(['/employees']).then(success => {
          if (success) {
            console.log('Navigation successful');
          } else {
            console.error('Navigation failed');
          }
        });
      },
      error: (err) => {
        console.error('Update failed', err);
      }
    });
  }
}
