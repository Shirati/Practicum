import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import Child from 'src/Models/Child';

//import { ChildServiceService } from 'src/services/child-service.service';

@Component({
  selector: 'add-child',
  templateUrl: './add-child.component.html',
  styleUrls: ['./add-child.component.scss']
})
export class AddChildComponent implements OnInit {
  @Output()
  newItemEvent = new EventEmitter<Child>();

  empty: Child = new Child(null, null, null, new Date(), null);


  constructor(){}//public myActive: ActivatedRoute, public childService: ChildServiceService, public action: Router) {
  //}

  ngOnInit(): void {
  }

  // public async add() {
  //   var c = (await this.childService.AddChilde(this.empty)).subscribe((success) => {
  //     console.log("suc:" + success);
  //     // this.user.Children.push(this.empty);
  //     this.action.navigate(["User"]);
  //   },
  //     (error) => {
  //       alert("שגיאה בהכנסת הילד");
  //       console.log(error);
  //     });
  // }

  addNewItem() {
    if (this.empty.FullName !== '' && this.empty.DateOfBirth < new Date() && this.empty.IdChild?.length === 9) {
      this.newItemEvent.emit(this.empty);
      this.empty = new Child(null, null, null, new Date(), null);
    }
  }
}
