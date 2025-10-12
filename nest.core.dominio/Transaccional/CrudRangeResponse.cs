namespace nest.core.dominio.Transaccional
{
    public class CrudRangeResponse<TEntity, TDto>
    {
        public CrudRangeResponse()
        {
            
        }

        public CrudRangeResponse(TEntity Entity, TDto Dto)
        {
            this.Entity = Entity;
            this.Dto = Dto;
        }
        public TEntity Entity { get; set; }
        public TDto Dto { get; set; }
    }
}
