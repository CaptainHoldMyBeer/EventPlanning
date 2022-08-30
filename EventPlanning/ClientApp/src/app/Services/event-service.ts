import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GlobalAppService } from '../Services/global-app-service';
import { Event } from '../Interfaces/event.interface';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class EventService {
    private controllerPrefix: string = "event/";

    constructor(private client: HttpClient, private appService: GlobalAppService) { }

    public createNewEvent(newEvent: Event ): Observable<boolean> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
        const options = { headers: headers };

        return this.client.post<boolean>(this.appService.api + this.controllerPrefix + "createEvent", newEvent, options);
    }

    public GetEvents(userId: number): Observable<Event[]> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
        const options = { headers: headers };

        return this.client.get<Event[]>(this.appService.api + this.controllerPrefix + "getAllEvents?userId=" + userId, options);
    }

    public GetEventsForUser(userId: number): Observable<Event[]> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
        const options = { headers: headers };

        return this.client.get<Event[]>(this.appService.api + this.controllerPrefix + "getEventsForUser?userId=" + userId, options);
    }

    public JoinEvent(userId: number, eventId: number): Observable<Event[]> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
        const options = { headers: headers };

        return this.client.get<Event[]>(this.appService.api + this.controllerPrefix + "joinEvent?userId=" + userId + "&eventId=" + eventId, options);
    }
}