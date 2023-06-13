import { Performers } from "../performers/performers.interface";

export interface Objective {
    objectiveId: number,
    title: string,
    description: string,
    priority: string,
    performers: Performers[]
}
