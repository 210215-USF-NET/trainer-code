import { superpower } from "./superpower";

export interface hero
{
    heroName: string,
    hp: number,
    elementType: element,
    superPower : superpower
}
export enum element
{
    Air = 3, Earth = 2, Water = 1, Fire = 4, Unknown = 0
}