﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieReviewModel
    {
        public MovieGenreViewModel MGenre { get; set; }
        public MovieDetailModel MReviewDetail { get; set; }
    }
}
