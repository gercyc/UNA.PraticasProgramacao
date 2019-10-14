using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiMenu.Data
{
    [Table("ITS_MENU")]
    public class ItsMenu
    {
        public ItsMenu()
        {

        }

        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdMenu { get; set; }
        [StringLength(300)]
        public string NomeMenu { get; set; }
        public int? MenuPai { get; set; }
        public bool Status { get; set; }
        [StringLength(500)]
        public string MenuText { get; set; }
        [StringLength(50)]
        public string MenuType { get; set; }
        public string ControllerClass { get; set; }
        public string ActionController { get; set; }
    }
}
