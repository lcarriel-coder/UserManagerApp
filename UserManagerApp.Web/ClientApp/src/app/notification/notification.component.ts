import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../services/notification.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-notification',
  standalone:false,
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent  implements OnInit {

  notification$: Observable<string | null>;

  constructor(private notificationService: NotificationService) {

    this.notification$ = this.notificationService.notification$;
  }

  ngOnInit(): void {

  }
}
