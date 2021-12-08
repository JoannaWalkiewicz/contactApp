import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ListViewModel } from '../model/list.viewmodel';
import { ContactViewModel } from '../model/contact.viewmodel';
import { Router } from '@angular/router';
import { ContactService } from '../service/contact.service';


@Component({
  selector: 'app-edit-component',
  templateUrl: './edit.component.html'
})
export class EditComponent {
  private http: HttpClient;
  private baseUrl: string;
  public contactForm: FormGroup;

  categories: ListViewModel[] = [];
  subcategories: ListViewModel[] = [];
  showSubcategory = false;
  showOther = false;
  private contactService: ContactService;
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder, private router: Router, contactService: ContactService) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.contactService = contactService;

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
    
    if(contactService.contact) {
      this.contactForm.patchValue(contactService.contact);
    }

    this.http.get<ListViewModel[]>(this.baseUrl + 'dictionary/categories').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));

    this.http.get<ListViewModel[]>(this.baseUrl + 'dictionary/subcategories').subscribe(result => {
      this.subcategories = result;
    }, error => console.error(error));

   
  }

  categoryChange(categoryValue: string) {
    if (categoryValue == "1") {
      this.showSubcategory = true;
    }
    else if (categoryValue == "3") {
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
      Email: form.email,
      Password: form.password,
      ContactCategoryId: parseInt(form.contactCategoryId),
      ContactSubcategoryId: parseInt(form.contactSubcategoryId),
      CategoryOther: form.categoryOther,
      PhoneNumber: form.phoneNumber,
      BirthDate: form.birthDate
    };

    this.http.put<ContactViewModel>(this.baseUrl + 'contact', submitModel).subscribe(result => {
      alert("Prawidłowo wyedytowano rekord");
      this.router.navigateByUrl('/contact-list');
    }, error => console.error(error));
  }
}
