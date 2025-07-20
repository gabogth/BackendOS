namespace nest.core.dominio.Contabilidad.CuentaContableEntities
{
    public class CuentaContableCrearDto
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool Activo { get; set; }
        public string ES { get; set; }
        public int CuentaContableTipoId { get; set; }
        public int Nivel { get; set; }
        public int? PadreId { get; set; }
        public bool PermiteMovimiento { get; set; }
    }
}
