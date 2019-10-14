using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UNA.PraticasProgramacao.Core.Entidades.Entidades.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        [Key]
        public override string Id { get; set; }
    }
}
