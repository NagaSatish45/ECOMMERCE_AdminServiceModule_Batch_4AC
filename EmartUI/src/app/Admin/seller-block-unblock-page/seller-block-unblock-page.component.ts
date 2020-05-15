import { Component, OnInit } from '@angular/core';
import { Seller } from 'src/app/Models/seller';
import { AdminActivitiesService } from 'src/app/Services/admin-activities.service';

@Component({
  selector: 'app-seller-block-unblock-page',
  templateUrl: './seller-block-unblock-page.component.html',
  styleUrls: ['./seller-block-unblock-page.component.css']
})
export class SellerBlockUnblockPageComponent implements OnInit {
seller:Seller[];
  constructor(private service:AdminActivitiesService) {
    this.service.GetAllSellers().subscribe(res=>{
      this.seller=res;
      console.log(this.seller);
    }, err=>{
      console.log(err);
    }
    )
   }

  ngOnInit(): void {
  }

}
