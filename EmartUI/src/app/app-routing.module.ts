import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from './Admin/login-page/login-page.component';
import { AddCategoryPageComponent } from './Admin/add-category-page/add-category-page.component';
import { AddSubCategoryPageComponent } from './Admin/add-sub-category-page/add-sub-category-page.component';
import { BuyerBlockUnblockPageComponent } from './Admin/buyer-block-unblock-page/buyer-block-unblock-page.component';
import { SellerBlockUnblockPageComponent } from './Admin/seller-block-unblock-page/seller-block-unblock-page.component';
import { LandingpageComponent } from './Admin/landingpage/landingpage.component';
import { ViewCategoryComponent } from './Admin/view-category/view-category.component';
import { ViewSubCategoryComponent } from './Admin/view-sub-category/view-sub-category.component';


const routes: Routes = [
  {path:'login-page',component:LoginPageComponent},
  {path:'',redirectTo:'login-page',pathMatch:'full'},
  {path:'landingpage',component:LandingpageComponent,children:[
  {path:'add-category-page',component:AddCategoryPageComponent},
  {path:'view-category',component:ViewCategoryComponent},
  {path:'view-sub-category',component:ViewSubCategoryComponent},
  {path:'add-sub-category-page',component:AddSubCategoryPageComponent},
  {path:'buyer-block-unblock-page',component:BuyerBlockUnblockPageComponent},
  {path:'seller-block-unblock-page',component:SellerBlockUnblockPageComponent}
]},
 
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
