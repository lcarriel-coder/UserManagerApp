import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';


export function passwordStrengthValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (!control.value) return null;


    const hasUpperCase = /[A-Z]/.test(control.value);
    const hasLowerCase = /[a-z]/.test(control.value);
    const hasNonAlphanumeric = /[^A-Za-z0-9]/.test(control.value);
    const isValid = hasUpperCase && hasLowerCase && hasNonAlphanumeric;

    return isValid ? null : { passwordStrength: true };
  };
}
