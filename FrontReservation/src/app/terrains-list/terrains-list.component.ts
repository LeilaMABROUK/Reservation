import { HttpClientModule, HttpClient } from '@angular/common/http';  
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-terrains-list',
  templateUrl: './terrains-list.component.html',
  styleUrls: ['./terrains-list.component.css']
})
export class TerrainsListComponent implements OnInit {

  constructor(private httpService: HttpClient) { }
 Terrain : string[]; 

  ngOnInit() {
    this.httpService.get('http://localhost:50664/api/Terrain').subscribe(  
      data => {  
       this.Terrain = data as string [];  
       console.log(data)
      }  
    );  
  }

}
