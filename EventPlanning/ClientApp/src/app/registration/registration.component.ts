import { Component } from '@angular/core'
import { GlobalAppService } from '../Services/global-app-service'

@Component({
    selector: 'registration.component',
    templateUrl: './registration.component.html'
})
export class RegistrationComponent {
    public user: any;

    constructor(public globalService: GlobalAppService) {}

    public getTemplateFile() {
        let link = document.createElement("a");
        link.download = "template";
        link.href = this.globalService.templatePath;
        link.click();
    }
}