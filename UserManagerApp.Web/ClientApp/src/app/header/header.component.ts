import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  standalone:false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  userName: string | null = null;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.userName = this.authService.getUserName(); // Obtener el nombre del usuario
  }

  logout() {
    this.authService.logout(); // Cerrar sesión
    this.userName = null; // Limpiar el nombre del usuario en el header
  }
}
