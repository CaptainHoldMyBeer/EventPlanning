import { Component, OnInit } from '@angular/core'
import { MatTableDataSource } from '@angular/material';
import { Event } from "../Interfaces/event.interface";
import { EventInfo } from '../Interfaces/event-information.interface';
import { EventService } from "../Services/event-service";

@Component({
    selector: 'join-event.component',
    templateUrl: './join-event.component.html'
})
export class JoinEventComponent implements OnInit {
    allEvents: Event[] = [];


    constructor(public eventService: EventService) { }

    ngOnInit(): void {
        this.eventService.GetEvents().subscribe((events) => {
            if (events) {
                this.allEvents = events;
            }
        })
    }
}

