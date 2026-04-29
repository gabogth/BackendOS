export interface FormularioEntity {
  id: number;
  parentId: number | null;
  moduloId: number;
  nombre: string;
  nombreCorto: string;
  descripcion: string;
  controlador: string;
  action: string;
  icono: string;
  claimType: string;
  orden: number;
  estado: boolean;
}

export type FormularioCreatePayload = Omit<FormularioEntity, 'id'>;
export type FormularioUpdatePayload = FormularioEntity;
