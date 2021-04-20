using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_API.Interfaces;
using Demo_API.Models;

namespace Demo_API.Services
{
    public class TweetService : ITweetService
    {

        private readonly List<Tweets> sampleTweets = new List<Tweets>()
        {
            new Tweets { Id = 11001, UserId = 1 ,Username = "himanshulimbasiya", Tweet = "Hello Guys #Love", ReTweets = 0 },
            new Tweets { Id = 11090, UserId = 2 ,Username = "lionelmessi", Tweet = "Final Won!!! #CopaDelRe", ReTweets = 5000000 },
            new Tweets { Id = 11082, UserId = 1 ,Username = "himanshulimbasiya", Tweet = "Congratulations Barca!!", ReTweets = 500 },
            new Tweets { Id = 11078, UserId = 3 ,Username = "christianoronaldo", Tweet = "Well Deserved Win #Barca #CopaDelRe", ReTweets = 3000000 },
            new Tweets { Id = 11099, UserId = 4 ,Username = "neymarJr", Tweet = "We Will Win CL #PSG #UEFA", ReTweets = 600000 }
        };

        public IEnumerable<Tweets> GetAll()
        {
            return sampleTweets;
        }

        public IEnumerable<Tweets> GetOne(string userName)
        {
            return sampleTweets.Where(x => x.Username == userName);
        }
    }
}
