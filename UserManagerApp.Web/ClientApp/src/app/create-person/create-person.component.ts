import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonService } from '../services/person.service';
import { NotificationService } from '../services/notification.service'; // Inyectar servicio de notificaciones
import { passwordStrengthValidator } from '../utils/passwordStrengthValidator';

@Component({
  selector: 'app-create-person',
  standalone: false,
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {
  public personForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private personService: PersonService,
    private notificationService: NotificationService // Inyectar servicio de notificaciones
  ) {}

  ngOnInit(): void {
    this.personForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.minLength(3)]],
      identificationType: ['', Validators.required],
      identification: ['', [Validators.required, Validators.minLength(10)]],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required, Validators.minLength(3)]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          passwordStrengthValidator(),
        ],
      ],
    });
  }

  getFieldError(field: string): string | null {
    if (!this.personForm.controls[field]) return null;

    const errors = this.personForm.controls[field].errors || {};

    for (const key of Object.keys(errors)) {
      switch (key) {
        case 'required':
          return 'Este campo es requerido';
        case 'minlength':
          return `Mínimo ${errors['minlength'].requiredLength} caracteres.`;
        case 'email':
          return 'Ingrese un correo válido';
        case 'passwordStrength':
          return 'La contraseña debe contener al menos una letra mayúscula, una letra minúscula y un carácter no alfanumérico.';
      }
    }

    return null;
  }

  isValidField(field: string): boolean | null {
    return (
      this.personForm.controls[field].errors &&
      this.personForm.controls[field].touched
    );
  }

  onSubmit(): void {
    if (this.personForm.invalid) {
      this.personForm.markAllAsTouched();
      return;
    }

    // Llamar al servicio para crear la persona
    this.personService.createPerson(this.personForm.value).subscribe({
      next: (response) => {
        console.log('Respuesta del servidor:', response);
        this.personForm.reset();

        // Mostrar notificación de éxito
        this.notificationService.showNotification('¡Persona creada con éxito!');
      },
      error: (error) => {
        console.error('Error al enviar el formulario:', error);

        // Mostrar notificación de error
        this.notificationService.showNotification('Hubo un error al crear la persona. Intenta nuevamente.');
      },
    });
  }
}
