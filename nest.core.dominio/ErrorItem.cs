using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio
{
    public record ErrorItem
    {
        public string Field { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;

        public ErrorItem() { }

        public ErrorItem(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
