import { Injectable } from '@angular/core';
import { Contact } from '../model/contact.inteface';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
    public contact: Contact | null = null;
}