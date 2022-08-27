import { Component, OnInit } from '@angular/core';
import { GlobalAppService } from '../Services/global-app-service';
import { LoginService } from '../Services/login-service';
import { FileRestrictions, FileInfo, SelectEvent, FileState } from '@progress/kendo-angular-upload';
//import { File } from '../Interfaces/file.interface';
import { User } from '../Interfaces/user.interface';
import { UserRegistrationFormModel } from '../Models/form.models';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'registration.component',
    templateUrl: './registration.component.html'
})
export class RegistrationComponent implements OnInit {
    public uploadSaveUrl: any;
    public uploadRemoveUrl: any;
    public selectedFile: File;


    constructor(public globalService: GlobalAppService, public formModel: UserRegistrationFormModel, public loginService: LoginService, private router: Router) { }

    ngOnInit(): void {
        this.uploadRemoveUrl = "removeUrl";
        this.uploadSaveUrl = "saveUrl";
    }

    public onUploadEvent(e: SelectEvent) {
        this.getFile(e);
    }

    public onRegister() {
        if (!this.credentialsValid)
            return;

        var newUser: User = {
            Email: this.formModel.model.value.Email,
            Login: this.formModel.model.value.Login,
            Password: this.formModel.model.value.Password,
            PinnedFile: this.selectedFile
        };

        this.loginService.createNewUser(newUser).subscribe((addedId) => {
            if (addedId) {
                this.globalService.isUserAuthenticated = true;
                this.globalService.userId = addedId;
                alert("Welcome");
                this.router.navigate(['/user-events']);
            }
        });
    }

    public getTemplateFile() {
        let link = document.createElement("a");
        link.download = "template";
        link.href = this.globalService.templatePath;
        link.click();
    }

    private getFile(e: SelectEvent) {
        let file = e.files[0];
        if (file.rawFile) {

            
            const reader = new FileReader();


            var tmp = reader.readAsArrayBuffer(file.rawFile);

            var t = 123;
            //reader.onloadend = () => {
            //    this.selectedFile = {
            //        Name: file.name,
            //        Size: file.size,
            //        Src: <string>reader.result,
            //        Uid: file.uid
            //    }
            //};
            //reader.readAsDataURL(file.rawFile);
        }
    }

    private credentialsValid(): boolean {
        if (this.formModel.model.value.Password !== this.formModel.model.value.ConfirmedPassword) {
            alert("Введенные пароли должны совпадать!");
            return false;
        }

        return true;
    }
}