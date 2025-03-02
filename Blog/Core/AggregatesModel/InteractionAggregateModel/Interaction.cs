using Type = Blog.Core.AggregatesModel.InteractionAggregateModel.Enum.Type;

namespace Blog.Core.AggregatesModel.InteractionAggregateModel;

public class Interaction
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int PostId { get; set; } 
    
    public Type Type { get; set; }
}