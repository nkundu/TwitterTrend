using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Credentials;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ini = new Ini.IniFile(@"C:\twitter.ini");

            // Set up your credentials
            Auth.SetCredentials(new TwitterCredentials
            {
                AccessToken = ini.IniReadValue("Config", "Access_Token"),
                AccessTokenSecret = ini.IniReadValue("Config", "Access_Secret"),
                ConsumerKey = ini.IniReadValue("Config", "Consumer_Key"),
                ConsumerSecret = ini.IniReadValue("Config", "Consumer_Secret")
            });

            var stream = Tweetinvi.Stream.CreateSampleStream();
            stream.TweetReceived += (sender, a) =>
            {
                var tp = new TweetProcessor(a.Tweet);

                tp.Process();
            };
            stream.StartStream();
        }
    }
}
