import { element } from "./element";
import { superpower } from "./superpower";
export interface hero {
    heroName: string,
    hp: number,
    elementType: element,
    superPower: superpower
}