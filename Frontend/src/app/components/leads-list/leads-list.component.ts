import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeadService } from '../../services/lead.service';
import { Lead } from '../../models/lead.model';

@Component({
  selector: 'app-leads-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './leads-list.component.html',
  styleUrls: ['./leads-list.component.scss'],
})
export class LeadsListComponent implements OnInit {
  @Input() status: number = 0;
  leads: Lead[] = [];

  constructor(private leadService: LeadService) {}

  ngOnInit(): void {
    this.fetchLeads();
  }

  fetchLeads(): void {
    this.leadService.getLeadsByStatus(this.status).subscribe({
      next: (response) => {
        console.log('Leads recebidos:', response);
        this.leads = response.data ?? [];
      },
      error: (err) => {
        console.error('Erro ao buscar leads:', err);
      }
    });
  }

  accept(id: number): void {
    this.leadService.acceptLead(id).subscribe({
      next: () => this.fetchLeads(),
      error: (err) => console.error('Erro ao aceitar lead:', err)
    });
  }

  decline(id: number): void {
    this.leadService.declineLead(id).subscribe({
      next: () => this.fetchLeads(),
      error: (err) => console.error('Erro ao recusar lead:', err)
    });
  }
}
