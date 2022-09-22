using System;
using System.Collections.Generic;

namespace EfCoreDbFirst.Infrastructure.DataModels
{
    public partial class TbPessoa
    {
        public TbPessoa()
        {
            TbCompras = new HashSet<TbCompra>();
            TbPessoaFisicas = new HashSet<TbPessoaFisica>();
            TbPessoaJuridicas = new HashSet<TbPessoaJuridica>();
        }

        public int Idpessoa { get; set; }
        public string? Nome { get; set; }
        public string? Celular { get; set; }

        public virtual ICollection<TbCompra> TbCompras { get; set; }
        public virtual ICollection<TbPessoaFisica> TbPessoaFisicas { get; set; }
        public virtual ICollection<TbPessoaJuridica> TbPessoaJuridicas { get; set; }
    }
}
