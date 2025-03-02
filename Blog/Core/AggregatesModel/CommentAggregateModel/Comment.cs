namespace Blog.Core.AggregatesModel.CommentAggregateModel;

public class Comment
{
    public int Id { get; set; }
    
    public int PostId { get; set; }
    
    public int UserId { get; set; }

    public string Content { get; set; } = null!;
    
    public DateTime CreatedDate { get; set; }
}