using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Infrastructure.DataModels
{
    public partial class TbCompra
    {
        public int Idcompra { get; set; }
        public int? Idproduto { get; set; }
        public int? Idpessoa { get; set; }
        public DateOnly? Data { get; set; }

        public virtual TbPessoa? IdpessoaNavigation { get; set; }
        public virtual TbProduto? IdprodutoNavigation { get; set; }
    }
}
