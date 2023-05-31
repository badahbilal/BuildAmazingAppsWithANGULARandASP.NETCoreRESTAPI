import { Address } from "./address.model";
import { Gender } from "./gender.model";

export interface Student { 
    id: string, 
    firstName : string, 
    lastName : string, 
    dateOfBirth : string, 
    Email : string, 
    Mobile : string, 
    ProfileImageUrl : string,
    genderId : string,
    gender : Gender,
    address : Address 
}