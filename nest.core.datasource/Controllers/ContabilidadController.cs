using HotChocolate.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.datasource.Controllers
{
    [Authorize]
    public class CuentaContableController : ODataController
    {
        private readonly NestDbContext context;
        public CuentaContableController(NestDbContext context)
        {
            this.context = context;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(context.CuentaContable);
        }
        [EnableQuery]
        public IActionResult Get(int key)
        {
            var product = context.CuentaContable.FirstOrDefault(p => p.Id == key);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
