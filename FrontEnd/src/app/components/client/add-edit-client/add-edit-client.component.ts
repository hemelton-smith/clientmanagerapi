import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { IClient } from 'src/interfaces/Iclient';
import { IAddress } from 'src/interfaces/Iaddress';
import { ClientService } from 'src/app/services/client.service';
import { Guid } from "guid-typescript";
import { IAddClientRequest } from 'src/interfaces/IaddClientRequest';
import { ViewChild } from '@angular/core';
import { element } from 'protractor';

@Component({
  selector: 'app-add-edit-client',
  templateUrl: './add-edit-client.component.html',
  styleUrls: ['./add-edit-client.component.css'],
  
})

export class AddEditClientComponent implements OnInit {
  @ViewChild('myModalClose') modalClose: ElementRef;

  constructor(private service:ClientService) { }

  //since we are passing client object as input to the show component, we need to capture the same on this component
  clientRequest:IAddClientRequest; 
  @Input() client:IClient;
  
   id:String;
   firstName:String;
   lastName:String;
   gender:String;
   cellNumber:String;
   workNumber:String;

   address:IAddress;
   residentialId:String;
   streetAddress:string;
   town:string;
   code:string;
   addressType:number;

   workId:String;
   WstreetAddress:string;
   Wtown:string;
   Wcode:string;
   WaddressType:number;

   postalId:String;
   PstreetAddress:string;
   Ptown:string;
   Pcode:string;
   PaddressType:number;

   residential:number=0;
   work:number=1;
   postal:number=2;

   ActivateAddSuccess:boolean=false;
   ActivateUpdateSuccess:boolean=false;
   statusVisible:boolean=false;

   clientAddresses:IAddress[]=[];

  ngOnInit(): void {
    this.id = this.client.id;
    this.firstName = this.client.firstName;
    this.lastName = this.client.lastName;
    this.gender = this.client.gender;
    this.cellNumber = this.client.cellNumber;
    this.workNumber = this.client.workNumber;

    this.service.ClientAddress(this.client.id).subscribe(res=>{
            res.forEach((element) =>{
              if(element.type == 0){
                this.residentialId = element.id;
                this.streetAddress = element.street;               
                this.town = element.town;
                this.code = element.code;
              }

              if(element.type == 1){
                this.workId = element.id;
                this.WstreetAddress = element.street;
                this.Wtown = element.town;
                this.Wcode = element.code;
              }

              if(element.type == 2){
                this.postalId = element.id;
                this.PstreetAddress = element.street;
                this.Ptown = element.town;
                this.Pcode = element.code;
              }
            })
           
    });
  }

   addClient(){
     const clientId = Guid.create().toString(); 
   
     var client = {id: clientId,
                   firstName:this.firstName,
                   lastName:this.lastName,
                   gender:this.gender,
                   cellNumber:this.cellNumber,
                   workNumber:this.workNumber
              }

      var address:IAddress[] = [{ id: Guid.create().toString(),
                      clientId:clientId,
                      street : this.streetAddress,
                      town: this.town,
                      code: this.code,
                      type: this.residential
                    }, 
                    {id: Guid.create().toString(),
                    clientId:clientId,
                    street : this.WstreetAddress,
                    town: this.Wtown,
                    code: this.Wcode,
                    type: this.work},
                    {
                      id: Guid.create().toString(),
                      clientId:clientId,
                      street : this.PstreetAddress,
                      town: this.Ptown,
                      code: this.Pcode,
                      type: this.postal
                    }]

                    this.clientRequest = {client:client, addresses:address};
                debugger
                this.service.AddClient(this.clientRequest).subscribe(res=>{
                 
                   alert(res.toString());
                   
                });

                this.service.InserAddress(address).subscribe(res=>{
                  
                  console.log(res.toString());                 
                })
              debugger
              this.ActivateAddSuccess=true;
              this.statusVisible=true;

   }

      updateClient(){       
        var client = {
        id:this.id,
        firstName:this.firstName,
        lastName:this.lastName,
        gender:this.gender,
        cellNumber:this.cellNumber,
        workNumber:this.workNumber
     }

     var address:IAddress[] = [{ id: this.residentialId,
      clientId:this.id,
      street : this.streetAddress,
      town: this.town,
      code: this.code,
      type: this.residential
    }, 
    {id:this.workId,
    clientId:this.id,
    street : this.WstreetAddress,
    town: this.Wtown,
    code: this.Wcode,
    type: this.work},
    {
      id: this.postalId,
      clientId:this.id,
      street : this.PstreetAddress,
      town: this.Ptown,
      code: this.Pcode,
      type: this.postal
    }]
     this.clientRequest = {client:client, addresses:address};
     this.service.UpdateClient(this.clientRequest).subscribe(res=>{
      alert(res.toString());
     })

     this.ActivateUpdateSuccess=true;
     this.statusVisible=true;
     
   }

   refreshClients(){
    window.location.reload();
   }

}
