import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Controllers } from 'src/controllers/controllers';

@Component({ 
    templateUrl: 'register.component.html',
    styleUrls: ['register.component.scss']
})
export class RegisterComponent implements OnInit {
    registerForm: FormGroup;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private controllers: Controllers
    ) {
        if (this.controllers.authenticationController.currentUserValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            username: ['', Validators.required],
            password: ['', [Validators.required, Validators.minLength(6)]],
            registrationCode: ['', [Validators.required]]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        // this.alertService.clear();

        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
        this.controllers.userController.Register(
            this.registerForm.controls['username'].value, 
            this.registerForm.controls['password'].value, 
            this.registerForm.controls['firstName'].value, 
            this.registerForm.controls['lastName'].value, 
            this.registerForm.controls['registrationCode'].value)
            .pipe(first())
            .subscribe(
                data => {
                    // this.alertService.success('Registration successful', true);
                    this.router.navigate(['/login']);
                },
                error => {
                    // this.alertService.error(error);
                    this.loading = false;
                });
    }
}