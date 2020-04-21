using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entity
{
    [Table("MovieCrew")]
   public class MovieCrew
    {
     [Key]
     [Column(Order =0)]
     public int MovieId { get; set; }
    [Key]
    [Column(Order =1)]
    public int CrewId { get; set; }
    [Key]
    [Column(Order =2)]
    public string Department { get; set; }
    [Key]
    [Column(Order =3)]
    public string Job { get; set; }

    public Movie Movie { get; set; }

     public Crew Crew { get; set; }
    }
}
