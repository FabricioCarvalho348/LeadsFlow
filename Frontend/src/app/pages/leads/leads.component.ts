import { Component, OnInit } from '@angular/core';
import { Lead, LeadStatus } from '../../models/lead.model';
import { LeadService } from '../../services/lead.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-leads',
  imports: [CommonModule],
  templateUrl: './leads.component.html',
  styleUrls: ['./leads.component.scss']
})
export class LeadsComponent implements OnInit {
  leadStatus = LeadStatus;
  status: LeadStatus = LeadStatus.New;
  invitedLeads: Lead[] = [];
  acceptedLeads: Lead[] = [];

  constructor(private leadService: LeadService) {}

  ngOnInit(): void {
    this.loadLeads();
  }

  loadLeads(): void {
    if (this.status === LeadStatus.New) {
      this.leadService.getLeadsByStatus(0).subscribe((response) => {
        this.invitedLeads = response.data || [];
      });
    } else {
      this.leadService.getLeadsByStatus(1).subscribe((response) => {
        this.acceptedLeads = response.data || [];
      });
    }
  }

  changeStatus(newStatus: LeadStatus): void {
    this.status = newStatus;
    this.loadLeads();
  }

  accept(leadId: number): void {
    this.leadService.acceptLead(leadId).subscribe(() => {
      this.invitedLeads = this.invitedLeads.filter(lead => lead.id !== leadId);
      const acceptedLead = this.invitedLeads.find(lead => lead.id === leadId);
      if (acceptedLead) {
        this.acceptedLeads.push(acceptedLead);
      }
    });
  }

  decline(leadId: number): void {
    this.leadService.declineLead(leadId).subscribe(() => {
      this.invitedLeads = this.invitedLeads.filter(lead => lead.id !== leadId);
    });
  }
}
