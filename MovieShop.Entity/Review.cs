﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entity
{
    [Table("Review")]
   public class Review
    {
        [Key]
        [Column(Order =0)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order =1)]
        public int UserId { get; set; }

        public decimal Rating { get; set; }

        public string ReviewText { get; set; }

        public User User { get; set; }

        public Movie Movie { get; set; }


    }
}
