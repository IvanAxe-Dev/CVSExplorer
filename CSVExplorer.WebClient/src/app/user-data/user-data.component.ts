import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../shared/user-data.service';
import { UserData } from '../shared/user-data.model';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrl: './user-data.component.css'
})
export class UserDataComponent implements OnInit {

  constructor(public service: UserDataService) {

  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  onDelete(id: string) {
    this.service.deleteUserData(id)
      .subscribe({
        next: res => {
          this.service.list = res as UserData[];
          this.service.refreshList();
      },
        error: err => { console.log(err) }
      })
  }
}
