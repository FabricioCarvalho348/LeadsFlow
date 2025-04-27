export interface Lead {
  id: number;
  contactFirstName: string;
  contactLastName: string;
  contactPhone: string;
  contactEmail: string;
  dateCreated: string;
  suburb: string;
  category: String;
  description: string;
  price: number;
  status: LeadStatus;
}

export enum LeadStatus {
  New = 'New',
  Accepted = 'Accepted',
  Declined = 'Declined'
}
