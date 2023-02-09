import { Component, OnInit } from '@angular/core';


import Child from 'src/Models/Child';
import User from 'src/Models/User';
import { UserServiceService } from 'src/services/user-service.service';

import * as XLSX from 'xlsx';

@Component({
  selector: 'app-form-user',
  templateUrl: './form-user.component.html',
  styleUrls: ['./form-user.component.scss']
})
export class FormUserComponent implements OnInit {
  hasChild = false;
  countf = 0;
  countl = 0;

  fullname = { fname: "", lname: "" };
  empty: User;
  constructor(public userService: UserServiceService) {
    this.empty = userService.currentUser;
  }

  ngOnInit(): void {
  }
  public async addUser() {
    console.log(this.empty);
   
    
    this.empty.Date = new Date(this.empty.Date);
    if (this.empty.Date < new Date()) {
      var c = (await this.userService.AddUser(this.empty)).subscribe((success) => {
        console.log("suc:" + success);
        alert("נרשמת בהצלחה");

      },
        (error) => {
          alert("שגיאה בהכנסת האדם");
          console.log(error);
        });
      this.empty = new User(null, null, null, null, null, null, null, []);

    }
    else
      alert("שגיאה בתאריך");

  }
  addChild() {
    this.hasChild = true;
  }

  addChildToList(child: Child) {
    if(this.empty.Children.find(x=>x.IdChild==child.IdChild))
    alert("הילד שייך לאבא");
    else
    this.empty.Children.push(child);
  }

  deleteChild(index: number) {
    this.empty.Children.splice(index, 1);
  }

  edit(s: string) {

    if (s === 'fname')
      this.countf++;
    else
      this.countl++;

    if (this.countf >= 1 && this.countl >= 1) {
      this.fullname.fname = this.empty.FirstName;
      this.fullname.lname = this.empty.LastName;
      this.userService.saveInStorage(this.fullname);
      this.userService.currentFullname.next(this.fullname);
    }
  }

  exportExcel(): void
  {
    if(this.empty.FirstName!=null){
    /* pass here the table id */
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);
 
    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
 
    /* save to file */  
    XLSX.writeFile(wb, this.empty.IdUser + '.xlsx');
 
  }
}

}