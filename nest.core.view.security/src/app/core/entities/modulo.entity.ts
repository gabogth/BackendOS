export interface ModuloEntity {
  id: number;
  nombre: string;
  nombreCorto: string;
  descripcion: string;
  rutaImagen: string;
  action: string;
  controlador: string;
  estado: boolean;
}

export interface ModuloCreatePayload {
  nombre: string;
  nombreCorto: string;
  descripcion: string;
  rutaImagen: string;
  action: string;
  controlador: string;
  estado: boolean;
}

export interface ModuloUpdatePayload extends ModuloCreatePayload {
  id: number;
}
