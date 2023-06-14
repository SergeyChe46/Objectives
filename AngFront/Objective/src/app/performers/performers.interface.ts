import { Objective } from "../objectives/objective.interface";

export interface Performers{
    performerId: string,
    email: string,
    name: string | undefined,
    objectives: Objective[] | undefined
}
