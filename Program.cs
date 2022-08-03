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

        try
        {
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            //***************************** publish a tweet *****************************************//
            var tweet = await userClient.Tweets.PublishTweetAsync("test #1");
           

            //************************** read a tweet ************************//
            var publishedTweet = await userClient.Tweets.GetTweetAsync(tweet.Id);
            
            //*********************** Delete a tweet **********************//
            await userClient.Tweets.DestroyTweetAsync(tweet);

            // Get the tweets available on the user's home page
            //var homeTimeline = await userClient.Timelines.GetHomeTimelineAsync();  
            //Console.WriteLine(homeTimeline[0]);

            // Get tweets from a specific user
            var userTimelineTweets = await userClient.Timelines.GetUserTimelineAsync("POTUS");
            Console.WriteLine(userTimelineTweets[0]);

            // publish a retweet
            var retweet = await userClient.Tweets.PublishRetweetAsync(userTimelineTweets[0]);

            /*var timelineTweets = new List<ITweet>();
            var homeTimelineTweets = await userClient.Timelines.GetHomeTimelineAsync();
            var timelineIterator = userClient.Timelines.GetHomeTimelineIterator();

            int total_tweets = 10;
            int i = 0;
            while (!timelineIterator.Completed && i != total_tweets)
            {
                var page = await timelineIterator.NextPageAsync(); 
                timelineTweets.AddRange(page);  
                i++;
            }   */

           // Console.WriteLine(timelineTweets[0]);
        //var tweetinviUser = await userClient.Users.GetUserAsync("POTUS");
        //var userTimelineTweets = await userClient.Timelines.GetUserTimelineAsync("POTUS");

            
            //var tweet = await userClient.Tweets.PublishTweetAsync("Pears");
            //Console.WriteLine("You published the tweet : " + tweet);
        }
        catch (Exception e) 
        {    
            Console.WriteLine(e);
            Console.WriteLine("Rate limits allowance have been exhausted - do your custom handling");

        }

    }
}



