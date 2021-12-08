import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ListViewModel } from '../model/list.viewmodel';
import { ContactViewModel } from '../model/contact.viewmodel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-component',
  templateUrl: './add.component.html'
})
export class AddComponent {
  private http: HttpClient;
  private baseUrl: string;
  public contactForm: FormGroup;
  
  categories: ListViewModel[] = [];
  subcategories: ListViewModel[] = [];
  showSubcategory = false;
  showOther = false;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder, private router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
    
    this.contactForm = this.formBuilder.group({
      contactId: null,
      name: "",
      surname: "",
      email: "",
      password: "",
      contactCategoryId: 0,
      contactSubcategoryId: 0,
      categoryOther: "",
      phoneNumber: "",
      birthDate: null
    });

    this.http.get<ListViewModel[]>(this.baseUrl + 'dictionary/categories').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));

   this.http.get<ListViewModel[]>(this.baseUrl + 'dictionary/subcategories').subscribe(result => {
      this.subcategories = result;
    }, error => console.error(error));
  }

  categoryChange(categoryValue: string){
    if(categoryValue == "1") {
      this.showSubcategory = true;
    }
    else if(categoryValue == "3") {
      this.showOther = true;
    }
    else {
      this.showSubcategory = false;
      this.showOther = false;
    }
  }

  submit() {
    const form = this.contactForm.getRawValue();
    var submitModel = {
      ContactId: form.contactId,
      Name: form.name,
      Surname: form.surname,
      Email:form.email,
      Password: form.password,
      ContactCategoryId: parseInt(form.contactCategoryId),
      ContactSubcategoryId: parseInt(form.contactSubcategoryId),
      CategoryOther: form.categoryOther,
      PhoneNumber: form.phoneNumber,
      BirthDate: form.birthDate
    }
    
    this.http.post<ContactViewModel>(this.baseUrl + 'contact', submitModel).subscribe(result => {
        alert("Prawidłowo dodany rekord");
        this.router.navigateByUrl('/contact-list');
     }, error => console.error(error));
   }
}
