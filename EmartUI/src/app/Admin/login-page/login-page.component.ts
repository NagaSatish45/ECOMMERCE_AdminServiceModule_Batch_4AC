import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validators} from '@angular/forms'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
loginform:FormGroup;
submitted=false;
uname:string;
password:string;
  constructor(private formbuilder:FormBuilder,private route:Router) { 
    
  }

  ngOnInit() {
    this.loginform=this.formbuilder.group({
      uname:['',Validators.required],
      password:['',Validators.required]
    })
  }
  Login(){
    this.submitted=true;
    if(this.loginform.invalid)
    {
      alert("invalid");
    }
    else
    {

    let username=this.loginform.value['uname'];
    let password=this.loginform.value['password'];
    if(username=="admin" && password=="admin")
    {
          this.route.navigateByUrl("landingpage");
     }
      
    
  }

  }
  get f() {return this.loginform.controls};
}
