import { Performers } from "../performers/performers.interface";

export interface Objective {
    objectiveId: string,
    title: string,
    description: string,
    priority: string,
    performers: Performers[]
}
