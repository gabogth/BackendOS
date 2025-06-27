namespace nest.core.dominio.Ventas.ClienteEntities
{
    public class Cliente
    {
        public int Id { get; set; }
        public byte DocumentoIdentidadTipoVentaId { get; set; }
        public string DocumentoIdentidadVentaNumero { get; set; }
        public string RazonSocial { get; set; }

    }
}
