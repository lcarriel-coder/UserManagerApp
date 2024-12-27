import { Component, OnInit } from '@angular/core';
import { PersonService } from '../services/person.service';


@Component({
  selector: 'app-people',
  standalone:false,
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {
  people: any[] = [];

  constructor(private personService: PersonService) {}


  ngOnInit(): void {
    this.personService.getAllPersons().subscribe((data) => {
      this.people = data;
    });
  }
}
