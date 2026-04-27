export interface SecurityUserEntity {
  id: string;
  userName: string;
  normalizedUserName: string;
  email: string;
  normalizedEmail: string;
  emailConfirmed: boolean;
  passwordHash: string;
  password: string;
  securityStamp: string;
  concurrencyStamp: string;
  phoneNumber: string | null;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  lockoutEnd: string | null;
  lockoutEnabled: boolean;
  accessFailedCount: number;
}

export interface SecurityUserCreatePayload {
  email: string;
  password: string;
  phoneNumber: string;
}

export interface SecurityUserUpdatePayload extends SecurityUserCreatePayload {
  id: string;
}

export interface SecurityUserResetPwPayload {
  id: string;
  password: string;
}
