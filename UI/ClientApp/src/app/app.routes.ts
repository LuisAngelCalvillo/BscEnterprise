import { Routes } from '@angular/router';
import { LoginComponent } from './business/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { AdminComponent } from './business/admin/admin.component';
import { StaffComponent } from './business/staff/staff.component';
import { SellerComponent } from './business/seller/seller.component';
import { EmptyComponent } from './business/empty/empty.component';

export const routes: Routes = [
    {
        path:'validate',
        canActivate: [AuthGuard],
        component: EmptyComponent
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'admin',
        component: AdminComponent
    },
    {
        path: 'staff',
        component: StaffComponent
    },
    {
        path: 'seller',
        component: SellerComponent
    },
    {
        path: '**',
        redirectTo: 'validate'
    }
];
