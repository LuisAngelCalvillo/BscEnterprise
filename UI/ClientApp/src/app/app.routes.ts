import { Routes } from '@angular/router';
import { LoginComponent } from './business/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { AdminComponent } from './business/admin/admin.component';
import { StaffComponent } from './business/staff/staff.component';
import { SellerComponent } from './business/seller/seller.component';
import { ValidateComponent } from './business/validate/validate.component';

export const routes: Routes = [
    {
        path:'validate',
        component: ValidateComponent
    },
    {
        path: 'login',
        component: LoginComponent,
    },
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: { roles: ['Administrador'] }
    },
    {
        path: 'staff',
        component: StaffComponent,
        canActivate: [AuthGuard],
        data: { roles: ['Personal'] }
    },
    {
        path: 'seller',
        component: SellerComponent,
        canActivate: [AuthGuard],
        data: { roles: ['Vendedor'] }
    },
    {
        path: '**',
        redirectTo: 'login'
    }
];
