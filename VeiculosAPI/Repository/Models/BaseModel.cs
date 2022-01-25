using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeiculosAPI.Repository.Models
{
    public class BaseModel
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("created_at"), DataType(DataType.DateTime)]
        public DateTime CreatedAt{ get; set; }

        [Column("updated_at"), DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at"), DataType(DataType.DateTime)]
        public DateTime? DeletedAt { get; set; }
    }
}
