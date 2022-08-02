using Tweetinvi;
using Tweetinvi.Models;

using System;

class Program
{
    static async Task Main(string[] args)
    {
        var userClient = new TwitterClient(
            args[0], args[1], args[2], args[3]
        );
        var user = await userClient.Users.GetAuthenticatedUserAsync();

        var timelineTweets = new List<ITweet>();
        //var timelineIterator = userClient.Timelines.GetHomeTimelineIterator();
        var timelineIterator = await userClient.Timelines.GetHomeTimelineAsync();

        int total_tweets = 10;
        int i = 0;
        while (!timelineIterator.Completed && i != total_tweets)
        {
            var page = await timelineIterator.NextPageAsync(); 
            timelineTweets.AddRange(page);  
            i++;
        }   

        Console.WriteLine(timelineTweets[0]);
       //var tweetinviUser = await userClient.Users.GetUserAsync("POTUS");
       //var userTimelineTweets = await userClient.Timelines.GetUserTimelineAsync("POTUS");

        
        //var tweet = await userClient.Tweets.PublishTweetAsync("Pears");
        //Console.WriteLine("You published the tweet : " + tweet);

    }
}



