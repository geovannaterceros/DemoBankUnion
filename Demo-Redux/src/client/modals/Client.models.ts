export interface Client {
  clientId?: string;
  firstName?: string;
  middleName?: string;
  lastName?: string;
  documentType?: string;
  identityDocument?: string;
  birthDate: Date;
  gender?: string;
}
