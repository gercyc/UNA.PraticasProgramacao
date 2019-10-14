using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UNA.PraticasProgramacao.Core.Entidades.Entidades.Identity
{
    public class ApplicationUser : IdentityUserLogin
    {
        [Key]
        public string Id { get; set; }
    }
}
