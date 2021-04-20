using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_API.Models
{
    public class Tweets
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public string Tweet { get; set; }

        public int ReTweets { get; set; }
    }
}
