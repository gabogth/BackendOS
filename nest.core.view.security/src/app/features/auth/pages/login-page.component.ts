import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../../../core/services/auth.service';
import { InputErrorComponent } from '@app/shared/components/inputError/inputError.component';

@Component({
  selector: 'app-login-page',
  imports: [ReactiveFormsModule, InputErrorComponent],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginPageComponent {
  private readonly formBuilder = inject(FormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  protected readonly isSubmitting = signal(false);
  protected readonly hasError = signal(false);
  protected readonly errorMessage = signal<string | null>(null);

  protected readonly loginForm = this.formBuilder.nonNullable.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });

  protected submit(): void {
    if (this.loginForm.invalid || this.isSubmitting()) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.hasError.set(false);
    this.isSubmitting.set(true);

    this.authService.login(this.loginForm.getRawValue())
      .subscribe({
        next: (isValid) => {
          this.isSubmitting.set(false);
          if (!isValid) {
            this.hasError.set(true);
            return;
          }
          void this.router.navigate(['/']);
        },
        error: (error) => {
          this.isSubmitting.set(false);
          this.hasError.set(true);
          this.errorMessage.set(error?.error?.detail ?? 'Sucedio un error durante el inicio de sesión');
        }
      });
  }

  protected showError(controlName: 'email' | 'password'): boolean {
    const control = this.loginForm.controls[controlName];
    return control.invalid && (control.touched || control.dirty);
  }
}
