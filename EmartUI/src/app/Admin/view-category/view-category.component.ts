import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/Models/category';
import { AdminActivitiesService } from 'src/app/Services/admin-activities.service';

@Component({
  selector: 'app-view-category',
  templateUrl: './view-category.component.html',
  styleUrls: ['./view-category.component.css']
})
export class ViewCategoryComponent implements OnInit {
category:Category[];
  constructor(private service:AdminActivitiesService) { 
    this.service.GetAllCategory().subscribe(res=>{
      this.category=res;
      console.log(this.category);
    }, err=>{
      console.log(err);
    }
    )
  }

  ngOnInit(): void {
  }
  deletecategory(cid:any)
  {
    this.service.DeleteCategory(cid).subscribe(res=>{
      console.log('record deleted');
 
  },err=>{
     console.log(err);
  });
  alert("category deleted...")
  

  }
 }

