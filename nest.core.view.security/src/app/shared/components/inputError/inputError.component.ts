import { Component, Input } from "@angular/core";
import { AbstractControl } from "@angular/forms";


@Component({
  selector: 'app-input-error',
  templateUrl: `./inputError.component.html`,
  styleUrl: `./inputError.component.scss`,
  host: {
    'class': 'invalid-feedback'
  }
})
export class InputErrorComponent {
  @Input() control!: AbstractControl | null;

  errorMessage(): string | null {
    if (!this.control || !this.control.errors || !(this.control.touched || this.control.dirty)) {
      return null;
    }
    const errors = this.control.errors;
    if (errors['required']) return 'Este campo es obligatorio';
    if (errors['email']) return 'Correo inválido';
    if (errors['minlength']) return 'Muy corto';
    if (errors['maxlength']) return 'Muy largo';
    if (errors['pattern']) return 'Formato inválido';
    if (errors['min']) return `Valor mínimo es ${errors['min'].min}`;
    if (errors['max']) return `Valor máximo es ${errors['max'].max}`;
    if (errors['customError']) return errors['customError'];
    if (errors['requiredTrue']) return 'Debes aceptar este campo para continuar';

    return 'Campo inválido';
  }
}