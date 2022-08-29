import { Component } from '@angular/core'
import { EventInfo } from '../Interfaces/event-information.interface'
import { EventFormModel} from '../Models/form.models';
import { FormControl } from '@angular/forms';
import { EventService } from "../Services/event-service";
import { GlobalAppService } from "../Services/global-app-service";
import { Event } from "../Interfaces/event.interface";

@Component({
    selector: 'create-event.component',
    templateUrl: './create-event.component.html',
    styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent {
    public user: any;
    public openDialogWindow: boolean = false;
    public newEvent: Event;
    public additionalInfo: EventInfo[] = []; 

    constructor(public globalService: GlobalAppService,
        public formModel: EventFormModel,
        public eventService: EventService) {

    }

    get createEventFormControl() {
        return this.formModel.model.controls;
    }

    public openDialogWindowCommand() {
        this.openDialogWindow = true;
    }

    public closeDialogWindowCommand(e: boolean) {
        this.openDialogWindow = false;
    }

    public onAddNewInformation(newInfo: EventInfo) {
        this.additionalInfo.push(newInfo);
        this.openDialogWindow = false;
    }

    public onCreate() {
        this.createNewEvent();

        this.eventService.createNewEvent(this.newEvent).subscribe((response) => {
            if (response) {
                alert(response);
            }
        });
    }

    private createNewEvent() {
        this.newEvent = {
            Title: this.formModel.model.value.Title,
            Location: this.formModel.model.value.Location,
            Date: this.getDateTime(this.formModel.model.value.Date, this.formModel.model.value.Time),
            MaxMembers: this.formModel.model.value.MaxMembers,
            AdditionalInfo: this.additionalInfo,
            UserId: this.globalService.userId,
            CurrentMembers: 0
        };

    }

    private getDateAndTimeOfEvent() {

    }

    private getDateTime(date: string, time: string ): Date {
        var newDate = new Date(date);
        newDate.setHours(+time.split(':')[0]);
        newDate.setHours(+time.split(':')[1]);

        return newDate;
    }
}

