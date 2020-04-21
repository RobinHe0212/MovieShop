﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entity
{
    [Table("MovieCast")]
    public class MovieCast

    {

        [Key]
        [Column(Order = 0)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CastId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(450)]
        public string Character { get; set; }

        public Cast Cast { get; set; }

        public Movie Movie { get; set; }

    }
}
