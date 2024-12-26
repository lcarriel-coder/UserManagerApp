import { Component } from '@angular/core';

@Component({
  selector: 'app-people',
  standalone:false,
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent {
  people = [
    { name: 'John', age: 30 },
    { name: 'Jane', age: 25 }
  ];
}
