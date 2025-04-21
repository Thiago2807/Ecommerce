import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserLoginModel } from '../models/userLogin.model';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  imports:[
    FormsModule,
  ],
})
export class LoginComponent {
  authService = inject(AuthService);
  user: UserLoginModel = new UserLoginModel();

  async onLogin(cred: Event) {
    cred.preventDefault();
    await this.authService.login(this.user)
  }
}