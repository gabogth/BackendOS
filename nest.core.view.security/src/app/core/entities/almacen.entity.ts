export interface AlmacenEntity {
  id: number;
  empresaId: number;
  nombre: string;
  nombreCorto: string;
  distritoId: number;
  direccion: string;
  latitud: number;
  lonitud: number;
  activo: boolean;
}

export interface AlmacenCreatePayload {
  nombre: string;
  nombreCorto: string;
  distritoId: number;
  direccion: string;
  latitud: number;
  lonitud: number;
  activo: boolean;
}

export interface AlmacenUpdatePayload extends AlmacenCreatePayload {
  id: number;
}
