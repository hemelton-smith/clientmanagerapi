import { IAddress } from "./Iaddress";
import { IClient } from "./Iclient";

export interface IAddClientRequest
{
    client:IClient;
    addresses: IAddress[];
}