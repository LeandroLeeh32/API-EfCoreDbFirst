using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Infrastructure.DataModels
{
    public partial class TbPessoaJuridica
    {
        public int Idpessoajuridica { get; set; }
        public int? Idpessoa { get; set; }
        public string? Cnpj { get; set; }

        public virtual TbPessoa? IdpessoaNavigation { get; set; }
    }
}
