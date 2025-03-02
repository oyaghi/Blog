using Blog.Core.AggregatesModel.InteractionAggregateModel;

namespace Blog.Core.AggregatesModel.UserAggregateModel;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public List<Interaction>? Interactions { get; set; } = [];
}