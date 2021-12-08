import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Contact } from './model/contact.inteface';
import { ContactService } from './service/contact.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html'
})
export class ContactListComponent {
  public contacts: Contact[] = [];
  private http: HttpClient;
  private baseUrl: string;
  private contactService: ContactService;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, contactService: ContactService, private router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.contactService = contactService;

    this.loadAllContacts();
  }

  delete(contact: Contact) {
    const contactId = contact.contactId;
    let httpParams = new HttpParams().set('contactId', contactId);

    this.http.delete<void>(this.baseUrl + 'contact', { params: httpParams }).subscribe(() => {
       this.loadAllContacts();
    }, error => console.error(error));
}

edit(contact: Contact) {
  this.contactService.contact = contact;
  this.router.navigateByUrl('/edit-contact');
}

loadAllContacts() {
  this.http.get<Contact[]>(this.baseUrl + 'contact').subscribe(result => {
    this.contacts = result;
  }, error => console.error(error));
 }
}

