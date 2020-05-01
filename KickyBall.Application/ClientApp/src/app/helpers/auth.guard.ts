import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Controllers } from 'src/controllers/controllers';
import { userInfo } from 'os';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private controllers: Controllers
    ) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.controllers.authenticationController.currentUserValue;
        if (currentUser) {
            let result: boolean = true;
            if(route.url[0].path === 'admin'){
                result = currentUser.isAdmin;
            }
            if(!result){
                this.router.navigate(['/']);
            }
            return result;
        }

        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}