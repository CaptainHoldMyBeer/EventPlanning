import { Component, OnInit } from '@angular/core'
import { Event } from "../Interfaces/event.interface";
import { EventInfo } from '../Interfaces/event-information.interface';
import { EventService } from "../Services/event-service";
import { GlobalAppService } from '../Services/global-app-service';

@Component({
    selector: 'user-events.component',
    templateUrl: './user-events.component.html'
})

export class UserEventsComponent implements OnInit {

    public allEvents: Event[] = [];
    public additionalInfo: EventInfo[] = [];

    constructor(public eventService: EventService, public globalService: GlobalAppService) { }

    ngOnInit(): void {
        this.eventService.GetEventsForUser(this.globalService.userId).subscribe((events) => {
            if (events) {
                this.allEvents = events;
            }
        });
    }

    public selectionChange(e: any) {
        let selectedRow = e.selectedRows[0].dataItem;

        this.additionalInfo = selectedRow.additionalInfo;
    }
}