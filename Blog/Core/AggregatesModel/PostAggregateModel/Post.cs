using Blog.Core.AggregatesModel.CommentAggregateModel;
using Blog.Core.AggregatesModel.PostAggregateModel.Enum;

namespace Blog.Core.AggregatesModel.PostAggregateModel;

public class Post
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Content { get; set; } = null!;
    
    public Category Category { get; set; }
    
    public DateTime PublicationDate { get; set; }
    
    public Tag Tag { get; set; }

    public string UserId { get; set; }
    
    public List<Comment>? Comments { get; set; } = [];
}