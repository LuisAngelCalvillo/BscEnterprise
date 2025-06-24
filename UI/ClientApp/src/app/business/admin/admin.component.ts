import { Component, OnInit } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { SelectModule } from 'primeng/select';
import { RoleDto } from '../../shared/interfaces/role.models';
import { RoleService } from '../../shared/services/role.service';
import { User } from '../../shared/interfaces/user.models';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-admin',
  imports: [ButtonModule,FormsModule, InputTextModule, PasswordModule, ReactiveFormsModule, CommonModule, HttpClientModule, SelectModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss'
})
export class AdminComponent implements OnInit {
  registerForm: FormGroup;
  roles:RoleDto[] = []

  constructor(
    private fb: FormBuilder,
    private roleService: RoleService,
    private userService: UserService
  ){
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      name: ['', [Validators.required, Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', [
        Validators.required,
        Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)
      ]],
      roleId: [0, [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.roleService.getRoles().subscribe((response) => {
      if(response.completed){
        this.roles = response.data;
      } else {
        console.error('Error obteniendo roles:', response.message);
      }
    })
  }

  registerUser(){
    const user: User = {
      email: this.registerForm.value.email,
      name: this.registerForm.value.name,
      lastName: this.registerForm.value.lastName,
      password: this.registerForm.value.password,
      roleId: this.registerForm.value.roleId.idRole
    }
    this.userService.createUser(user).subscribe({
      next: (response) => {
        if (response.completed) {
          alert(response.message)
          this.registerForm.reset();
        } else {
          console.error('Error obteniendo productos:', response.message);
        }
      }
    })
  }

  get email() { return this.registerForm.get('email'); }
  get name() { return this.registerForm.get('name'); }
  get lastName() { return this.registerForm.get('lastName'); }
  get password() { return this.registerForm.get('password'); }
  get roleId() { return this.registerForm.get('roleId'); }
}
