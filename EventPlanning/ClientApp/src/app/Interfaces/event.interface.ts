import { EventInfo } from "./event-information.interface";

export interface Event {
    Title: string;
    Id?: number;
    Location: string;
    Date: Date;
    Author?: string;
    MaxMembers: number;
    CurrentMembers: number;
    AdditionalInfo?: Array<EventInfo>;
    UserId: number;
}