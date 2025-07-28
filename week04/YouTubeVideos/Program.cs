using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create comments for video 1
        var comments1 = new List<Comment>
        {
            new Comment("Jacob", "Great explanation! Learned a lot."),
            new Comment("Robert", "Thanks for making this video."),
            new Comment("Oscar", "Could you make more like this? It would be great")
        };

        // Create video 1
        var video1 = new Video("Intro to C#", "Joseph Carroll", 995, comments1);

        // Create comments for video 2
        var comments2 = new List<Comment>
        {
            new Comment("John", "Very informative."),
            new Comment("Rachel", "Helped me with my homework."),
            new Comment("Michael", "Please do a part 2!")
        };

        // Create video 2
        var video2 = new Video("Abstraction in OOP", "Agnes Bird", 480, comments2);

        // Create comments for video 3
        var comments3 = new List<Comment>
        {
            new Comment("Tarah", "Amazing explanation!"),
            new Comment("jennifer", "I finally understand abstraction."),
            new Comment("Jack", "Can you explain polymorphism next?"),
            new Comment("Michelle", "What a great channel.")
        };

        // Create video 3
        var video3 = new Video("Understanding Inheritance", "Miles Bruckner", 640, comments3);

        // Create a list of videos
        var videos = new List<Video> { video1, video2, video3 };

        // Display video info and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); // blank line for spacing
        }
    }
}