using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    [Table("refresh_tokens")]
    public class RefreshToken : BaseModel
    {
        [Column("token")]
        [StringLength(255)]
        public string Token { get; set; }

        [Column("expira_em")]
        [DataType(DataType.DateTime)]
        public DateTime ExpiraEm { get; set; }
    }
}
