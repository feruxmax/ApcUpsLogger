using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApcUpsLogger.DataAccess.Entities
{
    [Table("tlinevoltages")]
    public class LineVoltage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get; set;}

        [Column("value")]
        public double Value {get; set;}

        [Column("date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date {get; set;}
    }
}