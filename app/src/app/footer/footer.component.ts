import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  name: string;
  email: string;
  message: string;

  constructor(public http: HttpClient) { }

  ngOnInit(): void {
  }

  send() {
    Swal.fire({
      title: 'Thank you for your feedback🤍',
      icon: 'success',
      iconColor: '#E16F26',
      position: 'center',
      showConfirmButton: false,
      timer: 3000
    })
  }
}
