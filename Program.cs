using Tweetinvi;
using Tweetinvi.Models;


class Program
{
    static async Task Main(string[] args)
    {
        var userClient = new TwitterClient(
            args[0], args[1], args[2], args[3]
        );
        var user = await userClient.Users.GetAuthenticatedUserAsync();
        Console.WriteLine(user);
        var tweet = await userClient.Tweets.PublishTweetAsync("Pears");
        Console.WriteLine("You published the tweet : " + tweet);

    }
}

