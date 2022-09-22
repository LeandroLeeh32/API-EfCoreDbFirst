using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Infrastructure.DataModels
{
    public partial class TbProduto
    {
        public TbProduto()
        {
            TbCompras = new HashSet<TbCompra>();
        }

        public int Idproduto { get; set; }
        public string? Descricao { get; set; }
        public string? Codigo { get; set; }
        public decimal? Preco { get; set; }

        public virtual ICollection<TbCompra> TbCompras { get; set; }
    }
}
