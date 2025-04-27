import { Lead, LeadStatus } from './lead.model';

describe('Lead Interface', () => {
  it('should have the correct structure for a Lead', () => {
    const lead: Lead = {
      Id: 1,
      ContactFirstName: 'John',
      ContactLastName: 'Doe',
      ContactPhone: '123-456-7890',
      ContactEmail: 'john.doe@example.com',
      DateCreated: '2023-04-01',
      Suburb: 'Yanderra 2574',
      Category: 'Construction',
      Description: 'Need new workers for a project.',
      Price: 5000,
      status: LeadStatus.New
    };

    expect(lead).toBeTruthy();
    expect(lead.Id).toBe(1);
    expect(lead.ContactFirstName).toBe('John');
    expect(lead.ContactLastName).toBe('Doe');
    expect(lead.ContactPhone).toBe('123-456-7890');
    expect(lead.ContactEmail).toBe('john.doe@example.com');
    expect(lead.DateCreated).toBe('2023-04-01');
    expect(lead.Suburb).toBe('Yanderra 2574');
    expect(lead.Category).toBe('Construction');
    expect(lead.Description).toBe('Need new workers for a project.');
    expect(lead.Price).toBe(5000);
    expect(lead.status).toBe(LeadStatus.New);
  });
});
