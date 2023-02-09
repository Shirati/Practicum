import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserServiceService } from 'src/services/user-service.service';

@Component({
  selector: 'app-guidance',
  templateUrl: './guidance.component.html',
  styleUrls: ['./guidance.component.scss']
})
export class GuidanceComponent implements OnInit {
  fullname = null;
  sub: Subscription;
  constructor(public userService: UserServiceService) { }
  ngOnDestroy(): void {
    this.sub.unsubscribe();

  }

  ngOnInit(): void {
    this.sub = this.userService.currentFullname.subscribe(succ => {
      this.fullname = succ?.fname + succ?.lname;
    })
  }
  logOut() {

    this.userService.removeFromStorage()
    this.userService.currentFullname.next(null);

  }
}
