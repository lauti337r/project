import {Country} from "./country.model";

export interface  Project {
  id: number;
  projectName: string;
  countryId: number;
  country: Country;
}
