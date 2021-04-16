import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';
import { IClient } from 'src/interfaces/Iclient';

@Component({
  selector: 'app-show-client',
  templateUrl: './show-client.component.html',
  styleUrls: ['./show-client.component.css']
})
export class ShowClientComponent implements OnInit {

  constructor(private service: ClientService) { }

  clientList: IClient[] = [];
  ModalTitle:string;
  ActivateAddEditClientComp:boolean=false;
  client:IClient;

  ngOnInit(): void {
    this.getAndInitialiseClients();
  }

   addClick(){
    this.client={
      id:"",
      firstName:"",
      lastName:"",
      gender:"Male",
      cellNumber:"",
      workNumber:""
    }
    this.ModalTitle="Add client";
    this.ActivateAddEditClientComp=true;
   }

  editClick(item){
    this.client=item;
    this.ModalTitle="Edit client";
    this.ActivateAddEditClientComp=true;
  }

  deleteClick(item){

    if(confirm("Are you sure you want to delete this client?")){
      this.service.DeleteClient(item.id).subscribe(data=>{
       this.getAndInitialiseClients();
      })
    }

  }

  closeClick(){
    this.ActivateAddEditClientComp=false;
    this.getAndInitialiseClients();
  }

  getAndInitialiseClients() {
    //async
    this.service.getAllClients().subscribe(data => {
    this.clientList = data;

    });
  }

  exportClick(){
    this.service.ExportClientInformation().subscribe();
    alert("Clients exported to designated location.");
  }

}
