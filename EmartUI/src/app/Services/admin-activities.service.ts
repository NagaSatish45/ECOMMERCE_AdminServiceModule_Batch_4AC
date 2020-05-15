import { Injectable } from '@angular/core';
import{HttpClient,HttpHeaders} from '@angular/common/http';
import { Category } from '../Models/category';
import { Observable } from 'rxjs';
import { SubCategory } from '../Models/sub-category';
import { Seller } from '../Models/seller';
import { Users } from '../Models/users';
const Requestheaders={headers:new HttpHeaders({
  'content-type':'application/json',
 
})}

@Injectable({
  providedIn: 'root'
})
export class AdminActivitiesService {
  url:string="http://localhost:59011/Admin/"
  constructor(private http:HttpClient) { }
  public AddCategory(category:Category):Observable<any>
  {
    return this.http.post<Category>(this.url+'AddCategory',JSON.stringify(category),Requestheaders);
  }
  public AddSubCategory(subcategory:SubCategory):Observable<any>
  {
    return this.http.post<SubCategory>(this.url+'AddSubCategory',JSON.stringify(subcategory),Requestheaders);
  }
  public getcategory(categoryId:number):Observable<Category>
  {
    return this.http.get<Category>(this.url+'getcategory/'+categoryId,Requestheaders);
  }
  public getsubcategory(subcategoryid:number):Observable<SubCategory>
  {
    return this.http.get<SubCategory>(this.url+'getsubcategory/'+subcategoryid,Requestheaders);
  }
  public updatesubcategory(subcategory:SubCategory):Observable<any>
    {
      return this.http.put<SubCategory>(this.url+'updatesubcategory',JSON.stringify(subcategory));
      
    }
    public updatecategory(category:Category):Observable<Category>
    {
      return this.http.put<Category>(this.url+'updatecategory',JSON.stringify(category));
    }
  public DeleteCategory(categoryid:number):Observable<Category>
  {
    return this.http.delete<Category>(this.url+'DeleteCategory/'+categoryid,Requestheaders);
  }
  public DeleteSubCategory(subcategoryid:number):Observable<SubCategory>
  {
    return this.http.delete<SubCategory>(this.url+'DeleteSubCategory/'+subcategoryid,Requestheaders);
  }
  public GetAllCategory():Observable<Category[]>
  {
    return this.http.get<Category[]>(this.url+'GetAllCategory')
  }
  public GetAllSubCategories():Observable<SubCategory[]>
  {
    return this.http.get<SubCategory[]>(this.url+'GetAllSubCategory')
  }
  public GetAllSellers():Observable<Seller[]>
  {
    return this.http.get<Seller[]>(this.url+'GetAllSellers')
  }
  public GetAllUsers():Observable<Users[]>
  {
    return this.http.get<Users[]>(this.url+'GetAllUsers')
  }
 
}
