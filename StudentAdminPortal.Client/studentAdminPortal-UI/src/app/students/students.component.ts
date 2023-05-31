import { Component, OnInit } from '@angular/core';
import { StudentsService } from './students.service';
import { Student } from '../Models/ui-models/student.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students : Student[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'dateOfBirth', 'email', 'mobile' , 'gender'];
  dataSource : MatTableDataSource<Student> = new MatTableDataSource<Student>();


  constructor(private studentsService : StudentsService){}

  ngOnInit(): void {
    // Fetch all students

    this.studentsService.getStudents()
        .subscribe(
          (successResponse)=>{
            this.students = successResponse;
            this.dataSource = new MatTableDataSource<Student>(this.students);
          },
          (errorResponse)=>{
            console.log(errorResponse);
          }
        );
  }
  
}
