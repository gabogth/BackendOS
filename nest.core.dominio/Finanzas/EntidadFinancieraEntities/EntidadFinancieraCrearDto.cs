namespace nest.core.dominio.Finanzas.EntidadFinancieraEntities
{
    public class EntidadFinancieraCrearDto
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
        public bool EsEfectivo { get; set; }
    }
}
