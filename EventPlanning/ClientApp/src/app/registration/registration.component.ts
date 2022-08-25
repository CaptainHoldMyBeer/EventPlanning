import { Component, OnInit } from '@angular/core';
import { GlobalAppService } from '../Services/global-app-service';
import { FileRestrictions, FileInfo, SelectEvent, FileState } from '@progress/kendo-angular-upload';
import { File } from '../Interfaces/file.interface';

@Component({
    selector: 'registration.component',
    templateUrl: './registration.component.html'
})
export class RegistrationComponent implements OnInit {
    public user: any;
    public uploadSaveUrl: any;
    public uploadRemoveUrl: any;
    public selectedFile: File;

    constructor(public globalService: GlobalAppService) {}
    ngOnInit(): void {
        this.uploadRemoveUrl = "removeUrl";
        this.uploadSaveUrl = "saveUrl";
    }

    public getTemplateFile() {

        console.log(this.uploadRemoveUrl);
        console.log(this.uploadSaveUrl);
        //let link = document.createElement("a");
        //link.download = "template";
        //link.href = this.globalService.templatePath;
        //link.click();
    }

    public onUploadEvent(e: SelectEvent) {
        var file = this.getFile(e);
    }


    private getFile(e: SelectEvent) {
        let file = e.files[0];
        if (file.rawFile) {
            const reader = new FileReader();

            reader.onloadend = () => {
                this.selectedFile = {
                    Name: file.name,
                    Size: file.size,
                    Src: <string>reader.result,
                    Uid: file.uid
                }
            };
            reader.readAsDataURL(file.rawFile);
            
        }

    }
}