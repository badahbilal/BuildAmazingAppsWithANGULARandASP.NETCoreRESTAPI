import { Component, OnInit } from '@angular/core';
import { StudentsService } from './students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  constructor(private studentsService : StudentsService){}

  ngOnInit(): void {
    // Fetch all students

    this.studentsService.getStudents()
        .subscribe(
          (successResponse)=>{
            console.log(successResponse);
          },
          (errorResponse)=>{
            console.log(errorResponse);
          }
        );
  }
  
}
