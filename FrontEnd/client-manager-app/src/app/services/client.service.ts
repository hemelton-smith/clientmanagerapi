import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IClient } from 'src/interfaces/Iclient';
import { IAddress } from 'src/interfaces/Iaddress';
import { IAddClientRequest } from 'src/interfaces/IaddClientRequest';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  readonly baseUrl=environment.baseUrl;

  constructor(private http:HttpClient) { }

  getAllClients():Observable<IClient[]>{
    return this.http.get<IClient[]>(`${this.baseUrl}/getallclients`);
  }

  AddClient(clients:IAddClientRequest){
    return this.http.post(`${this.baseUrl}/client`, clients);
  }

  InserAddress(val:IAddress[]){
    return this.http.post(`${this.baseUrl}/insertAddress`, val);
  }

  UpdateClient(val:IAddClientRequest){
    return this.http.put(`${this.baseUrl}/updateclient`, val);
  }

  DeleteClient(val:any){
    return this.http.delete(`${this.baseUrl}/deleterecord?clientId=`+val);
  }

  ExportClientInformation(){
    return this.http.get(`${this.baseUrl}/export`);
  }

  ClientAddress(clientId:String):Observable<IAddress[]>{
      return this.http.get<IAddress[]>(`${this.baseUrl}/clientaddresses?clientId=`+clientId);
  }
}
