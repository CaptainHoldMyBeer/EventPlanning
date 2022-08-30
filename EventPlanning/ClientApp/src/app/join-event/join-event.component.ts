import { Component, OnInit } from '@angular/core'
import { Event } from "../Interfaces/event.interface";
import { EventInfo } from '../Interfaces/event-information.interface';
import { EventService } from "../Services/event-service";
import { GlobalAppService } from '../Services/global-app-service';

@Component({
    selector: 'join-event.component',
    templateUrl: './join-event.component.html'
})
export class JoinEventComponent implements OnInit {

    public allEvents: Event[] = [];
    public additionalInfo: EventInfo[] = [];
    public selectedKey: number;

    constructor(public eventService: EventService, public globalService: GlobalAppService) { }

    ngOnInit(): void {
        this.eventService.GetEvents(this.globalService.userId).subscribe((events) => {
            if (events) {
                this.allEvents = events;
            }
        });
    }

    public selectionChange(e: any) {
        let selectedRow = e.selectedRows[0].dataItem;

        this.additionalInfo = selectedRow.additionalInfo;

        this.selectedKey = selectedRow.id;
    }

    public joinEvent() {
        if (!this.selectedKey) {
            alert("need to chose event!")
            return;
        }
        this.eventService.JoinEvent(this.globalService.userId, this.selectedKey).subscribe((response) => {
            if (response) {
                alert("you have joined the event");
            }
            else {
                alert("you can't join this event");
            }
        });
    }
}

