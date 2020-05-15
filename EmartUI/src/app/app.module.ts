import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {ReactiveFormsModule} from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './Admin/login-page/login-page.component';
import { AddCategoryPageComponent } from './Admin/add-category-page/add-category-page.component';
import { AddSubCategoryPageComponent } from './Admin/add-sub-category-page/add-sub-category-page.component';
import { HttpClientModule} from '@angular/common/http'
import { BuyerBlockUnblockPageComponent } from './Admin/buyer-block-unblock-page/buyer-block-unblock-page.component';
import { SellerBlockUnblockPageComponent } from './Admin/seller-block-unblock-page/seller-block-unblock-page.component';
import { LandingpageComponent } from './Admin/landingpage/landingpage.component';
import { ViewCategoryComponent } from './Admin/view-category/view-category.component';
import { ViewSubCategoryComponent } from './Admin/view-sub-category/view-sub-category.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    AddCategoryPageComponent,
    AddSubCategoryPageComponent,
    BuyerBlockUnblockPageComponent,
    SellerBlockUnblockPageComponent,
    LandingpageComponent,
    ViewCategoryComponent,
    ViewSubCategoryComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
    
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
