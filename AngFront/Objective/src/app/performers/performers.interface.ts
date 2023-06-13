import { Objective } from "../objectives/objective.interface";

export interface Performers{
    performerId: number,
    email: string,
    name: string | undefined,
    objectives: Objective[] | undefined
}
