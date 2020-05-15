import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder,Validators} from '@angular/forms';
import { Category } from 'src/app/Models/category';
import { AdminActivitiesService } from 'src/app/Services/admin-activities.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category-page',
  templateUrl: './add-category-page.component.html',
  styleUrls: ['./add-category-page.component.css']
})
export class AddCategoryPageComponent implements OnInit {
  addcategoryform:FormGroup;
  submitted=false;
  category:Category;
  constructor(private formbuilder:FormBuilder,private service:AdminActivitiesService,private route:Router) { }

  ngOnInit(){
    this.addcategoryform=this.formbuilder.group({
   
      categoryname:['',Validators.required],
      briefdetails:['',Validators.required],
      
  });
  }
  get f() {return this.addcategoryform.controls;}
  onSubmit()
  {
    this.submitted= true;
    if(this.addcategoryform.valid){
        
        alert("Success")
        this.category=new Category();
          this.category.cid=Math.round(Math.random()*1000);
          this.category.cname=this.addcategoryform.value["categoryname"],
          this.category.cdetails=this.addcategoryform.value["briefdetails"]
          this.service.AddCategory(this.category).subscribe(res=>
            {
              console.log('Added succesfully');
            },err=>{console.log(err)}
      
            )
            alert("Category added successfully");
          
        
     
    }

  }
 

}