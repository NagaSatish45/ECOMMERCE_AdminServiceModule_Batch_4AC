import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder,Validators } from '@angular/forms';
import { SubCategory } from 'src/app/Models/sub-category';
import { AdminActivitiesService } from 'src/app/Services/admin-activities.service';
import { Category } from 'src/app/Models/category';

@Component({
  selector: 'app-add-sub-category-page',
  templateUrl: './add-sub-category-page.component.html',
  styleUrls: ['./add-sub-category-page.component.css']
})
export class AddSubCategoryPageComponent implements OnInit {
  addsubcategoryform:FormGroup;
  submitted=false;
  subcategory:SubCategory;
  clist:Category[];
  constructor(private formbuilder:FormBuilder,private service:AdminActivitiesService) {
    this.service.GetAllCategory().subscribe(res=>{
      this.clist=res;
      console.log(this.clist);
    })
   }

  ngOnInit(){
    this.addsubcategoryform=this.formbuilder.group({
      categoryid:['',Validators.required],
      subcategoryid:['',[Validators.required,Validators.pattern("^[0-9]$")]],
      subcategoryname:['',[Validators.required,Validators.pattern("^[a-z]+$")]],
      GST:['',Validators.required],
      briefdetails:['',Validators.required],
      
    })
  }
  get f() {return this.addsubcategoryform.controls;}
  onSubmit()
  {
    this.submitted= true;
  this.subcategory=new SubCategory();
      this.subcategory.subid=Math.round(Math.random()*1000);
      this.subcategory.cid=Number(this.addsubcategoryform.value["categoryid"]);
      this.subcategory.subname=this.addsubcategoryform.value["subcategoryname"];
      this.subcategory.gst=Number(this.addsubcategoryform.value["GST"]);
      this.subcategory.sdetails=this.addsubcategoryform.value["briefdetails"];
      console.log(this.subcategory);
      this.service.AddSubCategory(this.subcategory).subscribe(res=>
        {
          alert("added Successfully");
          console.log('Added succesfully');
        },err=>{console.log(err)}

  );
  alert("subcategory added..");

}
}