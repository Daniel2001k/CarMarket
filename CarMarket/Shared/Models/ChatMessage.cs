using System.Text.Json.Serialization;

namespace CarMarket.Shared.Models;

[method: JsonConstructor]
public class ChatMessage(string user, string message)
{
    public string User { get; set; } = user;
    public string Message { get; set; } = message;
}
