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
    return this.http.get<IClient[]>(`${this.baseUrl}/api/getallclients`);
  }

  AddClient(clients:IAddClientRequest){
    return this.http.post(`${this.baseUrl}/api/client`, clients);
  }

  InserAddress(val:IAddress[]){
    return this.http.post(`${this.baseUrl}/api/insertAddress`, val);
  }

  UpdateClient(val:IAddClientRequest){
    return this.http.put(`${this.baseUrl}/api/updateclient`, val);
  }

  DeleteClient(val:any){
    return this.http.delete(`${this.baseUrl}/api/deleterecord?clientId=`+val);
  }

  ExportClientInformation(){
    return this.http.get(`${this.baseUrl}/api/export`);
  }

  ClientAddress(clientId:String):Observable<IAddress[]>{
      return this.http.get<IAddress[]>(`${this.baseUrl}/api/clientaddresses?clientId=`+clientId);
  }
}
