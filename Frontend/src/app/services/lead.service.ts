import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lead } from '../../app/models/lead.model';

@Injectable({
  providedIn: 'root',
})
export class LeadService {
  private readonly apiUrl = 'http://localhost:5015/api/leads';

  constructor(private http: HttpClient) {}

  getAllLeads(): Observable<Lead[]> {
    return this.http.get<Lead[]>(`${this.apiUrl}`);
  }

  getLeadById(id: number): Observable<Lead> {
    return this.http.get<Lead>(`${this.apiUrl}/${id}`);
  }

  createLead(lead: Lead): Observable<Lead> {
    return this.http.post<Lead>(`${this.apiUrl}`, lead);
  }

  updateLead(id: number, lead: Lead): Observable<Lead> {
    return this.http.put<Lead>(`${this.apiUrl}/${id}`, lead);
  }

  deleteLead(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getLeadsByStatus(status: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/status?status=${status}`);
  }

  acceptLead(id: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}/accept`, {});
  }

  declineLead(id: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}/decline`, {});
  }
}
