import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import Child from 'src/Models/Child';
import User from 'src/Models/User';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(public http: HttpClient) { }

  baseRouteUrlR = `${environment.baseUrl}/User`;
  currentFullname = new BehaviorSubject<{ fname: string, lname: string }>(null);
   currentUser:User=  new User(null, null, null, null, null, null, null, []);
 
  GetAll() {
    ~(`${this.baseRouteUrlR}/Get`);
    return this.http.get<User[]>(`${this.baseRouteUrlR}/Get`);
  }

  AddUser(user: User) {
    ~(`${this.baseRouteUrlR}/post`);
    return this.http.post<User>(this.baseRouteUrlR, user);
  }

  saveInStorage(fullname) {
    localStorage.setItem("currentFullname", JSON.stringify(fullname));
  }

  getFromStorage() {
    let u = localStorage.getItem("currentFullname");
    if (!u)
      return null;
    return JSON.parse(u);
  }
  removeFromStorage() {
    localStorage.removeItem("currentFullname");
  }
}


