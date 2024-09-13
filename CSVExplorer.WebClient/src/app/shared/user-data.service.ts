import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { environment } from '../../environments/environment.development';
import { UserData } from './user-data.model';
@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  url: string = environment.apiBaseUrl + '/Users';
  list: UserData[] = [];
  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as UserData[]
        },
        error: err => { console.log(err) }
      })
  }

  deleteUserData(id:string){
    return this.http.delete(this.url + '/' + id)
  }
}
