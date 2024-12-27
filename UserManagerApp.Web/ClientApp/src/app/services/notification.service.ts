import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private notificationSource = new BehaviorSubject<string | null>(null);
  notification$ = this.notificationSource.asObservable();

  constructor() {}

  showNotification(message: string) {
    this.notificationSource.next(message);
    setTimeout(() => this.notificationSource.next(null), 5000); // Opcional: ocultar la notificación después de 5 segundos
  }
}
