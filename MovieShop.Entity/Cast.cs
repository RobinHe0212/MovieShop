using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entity
{
    [Table("Cast")]
   public class Cast
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }
        public String Gender { get; set; }
        public String TmdbUrl { get; set; }

        [StringLength(2084)]
        public String ProfilePath { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
