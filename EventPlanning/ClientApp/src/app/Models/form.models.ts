import { Injectable } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

@Injectable()
export class UserRegistrationFormModel {
    public model: FormGroup;
    public formBuilder: FormBuilder = new FormBuilder();

    constructor() {
        this.createForm();
    }

    createForm() {
        this.model = this.formBuilder.group({
            Login: ['', [Validators.required]],
            Email: ['', [Validators.required, Validators.email]],
            Password: ['', [Validators.required, Validators.minLength(8)]],
            ConfirmedPassword: ['', [Validators.required, Validators.minLength(8)]],
            Name: ['', [Validators.required]],
            Surname: ['', [Validators.required]],
            Age: [null, [Validators.required]],
            Location: ['', [Validators.required]]
        });
    }
}

@Injectable()
export class UserLoginFormModel {
    public model: FormGroup;
    public formBuilder: FormBuilder = new FormBuilder();

    constructor() {
        this.createForm();
    }

    createForm() {
        this.model = this.formBuilder.group({
            Login: ['', [Validators.required]],
            Password: ['', [Validators.required, Validators.minLength(8)]]
        });
    }
}

@Injectable()
export class EventFormModel {
    public model: FormGroup;
    public formBuilder: FormBuilder = new FormBuilder();

    constructor() {
        this.createForm();
    }

    createForm() {
        this.model = this.formBuilder.group({
            Title: ['', [Validators.required]],
            Location: ['', [Validators.required]],
            Date: ['', [Validators.required]],
            Time: ['', [Validators.required]],
            MaxMembers: [0,[Validators.required]]
        });
    }
}