using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Core.Interfaces;

namespace ConsoleApp
{
    public class TweetProcessor
    {
        private ITweet m_tweet;
        public TweetProcessor(ITweet tweet)
        {
            m_tweet = tweet;
        }

        public void Process()
        {
            if (!Eligible())
                return;

            Console.WriteLine(m_tweet.Text);
        }

        private bool Eligible()
        {
            return m_tweet.Language == Tweetinvi.Core.Enum.Language.English;
        }
    }
}
