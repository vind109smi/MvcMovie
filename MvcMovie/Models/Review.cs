using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Review
    {
        public int ID { get; set; }

        public int movieID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

    }
}
