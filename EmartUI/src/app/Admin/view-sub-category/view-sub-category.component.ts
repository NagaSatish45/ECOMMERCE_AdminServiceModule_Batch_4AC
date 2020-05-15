import { Component, OnInit } from '@angular/core';
import { AdminActivitiesService } from 'src/app/Services/admin-activities.service';
import { SubCategory } from 'src/app/Models/sub-category';

@Component({
  selector: 'app-view-sub-category',
  templateUrl: './view-sub-category.component.html',
  styleUrls: ['./view-sub-category.component.css']
})
export class ViewSubCategoryComponent implements OnInit {
subcategory:SubCategory[];
  constructor(private service:AdminActivitiesService) {
    this.service.GetAllSubCategories().subscribe(res=>{
      this.subcategory=res;
      console.log(this.subcategory);
    }, err=>{
      console.log(err);
    }
    )
   }

  ngOnInit(): void {
  }
  deletecategory(subcid:any)
  {
    this.service.DeleteSubCategory(subcid).subscribe(res=>{
      console.log('record deleted');
 
  },err=>{
     console.log(err);
  });
  alert("category deleted...")
  

  }

}
