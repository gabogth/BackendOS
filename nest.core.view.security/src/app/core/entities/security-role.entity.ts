export interface SecurityRoleEntity {
  id: string;
  name: string;
  normalizedName: string;
  concurrencyStamp: string;
  empresaId: number;
}

export interface SecurityRoleCreatePayload {
  empresaId: number;
  name: string;
}

export interface SecurityRoleUpdatePayload {
  id: string;
  name: string;
}
