using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds, List<Comment> comments)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = comments;
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}