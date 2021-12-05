import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html'
})
export class ContactListComponent {
  public contacts: Contact[] = [];
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

    this.loadAllContacts();
  }

  delete(contact: Contact) {
    const contactId = contact.contactId;
    let httpParams = new HttpParams().set('contactId', contactId);

    this.http.delete<void>(this.baseUrl + 'contact', { params: httpParams }).subscribe(() => {
       this.loadAllContacts();
    }, error => console.error(error));
  }

loadAllContacts() {
  this.http.get<Contact[]>(this.baseUrl + 'contact').subscribe(result => {
    this.contacts = result;
  }, error => console.error(error));
 }
}

interface Contact {
  contactId: number;
  name: string;
  surname: string;
  email: string;
  password: string;
  category: number;
  categoryOther: string;
  phoneNumber: string;
  birthDate: Date;
}
