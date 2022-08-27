import { EventInfo } from "./event-information.interface";

export interface Event {
    Title: string;
    Id?: number;
    Location: string;
    Date: Date;
    Author?: string;
    Time: string;
    MaxMembers: number;
    AdditionalInfo?: Array<EventInfo>;
    UserId: number;
}