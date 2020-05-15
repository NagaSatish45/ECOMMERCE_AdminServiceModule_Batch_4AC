import { Component, OnInit } from '@angular/core';
import { Users } from 'src/app/Models/users';
import { AdminActivitiesService } from 'src/app/Services/admin-activities.service';

@Component({
  selector: 'app-buyer-block-unblock-page',
  templateUrl: './buyer-block-unblock-page.component.html',
  styleUrls: ['./buyer-block-unblock-page.component.css']
})
export class BuyerBlockUnblockPageComponent implements OnInit {
users:Users[];

  constructor(private service:AdminActivitiesService) {
    this.service.GetAllUsers().subscribe(res=>{
      this.users=res;
      console.log(this.users);
    }, err=>{
      console.log(err);
    }
    )
   }

  ngOnInit(): void {
  
  }

}
