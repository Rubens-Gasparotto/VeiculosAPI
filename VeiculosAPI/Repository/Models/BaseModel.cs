using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    public class BaseModel
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "created_at")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt{ get; set; }

        [Column(name: "updated_at")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        [Column(name: "deleted_at")]
        [DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }

        public dynamic Clone()
        {
            return (dynamic)this.MemberwiseClone();
        }
    }
}
