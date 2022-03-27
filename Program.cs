using Amazon;
using Amazon.PersonalizeRuntime;
using Amazon.PersonalizeRuntime.Model;
using Amazon.PersonalizeEvents;
using Amazon.PersonalizeEvents.Model;
using System.Net;

RegionEndpoint region = RegionEndpoint.USWest2;
const string CAMPAIGN_ARN = "[campaign-arn]";
const string TRACKING_ID = "[tracking-id]";

if (args.Length == 1)
{
    // Get recommendations

    var userId = args[0];

    var client = new AmazonPersonalizeRuntimeClient(region);

    Console.WriteLine($"Getting recommendations for user {userId}...");

    var request = new GetRecommendationsRequest()
    {
        CampaignArn = CAMPAIGN_ARN,
        UserId = userId
    };

    var response = await client.GetRecommendationsAsync(request);

    if (response.HttpStatusCode != HttpStatusCode.OK)
    {
        Console.WriteLine($"Error: AmazonPersonalizeRuntimeClient.GetRecommendationsAsync returned status {response.HttpStatusCode}");
    }
    else
    {
        if (response.ItemList != null && response.ItemList.Count > 0)
        {
            Console.WriteLine($"Recommendations:");
            foreach (var recommendation in response.ItemList)
            {
                Console.WriteLine(recommendation.ItemId);
            }
        }
        else
        {
            Console.WriteLine($"No recommendations");
        }
    }
    Environment.Exit(0);
}

if (args.Length == 2)
{
    // Report watch event

    var userId = args[0];
    var itemId = args[1];
    Console.WriteLine($"Reporting watch event to Amazon Personalize - user {userId} watched item {itemId}");
 
    var eventClient = new AmazonPersonalizeEventsClient(region);
    var eventRequest = new PutEventsRequest()
    {
        EventList = new List<Event>(new Event[]
                {  new Event()
                    {
                        EventId = Guid.NewGuid().ToString(),
                        EventType = "watch",
                        ItemId = itemId,
                        SentAt = DateTime.Now
                    }
                }),
        SessionId = Guid.NewGuid().ToString(),
        TrackingId = TRACKING_ID,
        UserId = userId
    };
    var resp = await eventClient.PutEventsAsync(eventRequest);
    Environment.Exit(0);
}

Console.WriteLine("To report a watch event: dotnet run -- [user-id] [event-id]");
Console.WriteLine("Example:                 dotnet run -- 1 1503");
Console.WriteLine("To get recommendations:  dotnet run -- [user-id]");
Console.WriteLine("Example:                 dotnet run -- 1");