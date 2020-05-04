using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Trade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Tid { get; set; }
        [Required]
        public long Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Type { get; set; }
        public override string ToString()
        {
            return $"TradeID: {Tid}, Amount: {Amount}, Date: {Date}, Price: {Price}, Type: {Type}";
        }
    }
}
