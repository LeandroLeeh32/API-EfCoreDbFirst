using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Infrastructure.DataModels
{
    public partial class TbPessoaFisica
    {
        public int Idpessoafisica { get; set; }
        public int? Idpessoa { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }

        public virtual TbPessoa? IdpessoaNavigation { get; set; }
    }
}
