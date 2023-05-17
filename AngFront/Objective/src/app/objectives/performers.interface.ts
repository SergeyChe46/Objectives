import { Objective } from "./objective.interface";

export interface Performers{
    performerId: number,
    email: string,
    name: string | undefined,
    objectives: Objective[] | undefined
}