using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.ClientModel;

// Microsoft.Extensions.Configuration, Microsoft.Extensions.SecretManager.Tools
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var credential = new ApiKeyCredential(config["OpenAI:Token"] ?? throw new InvalidOperationException("Missing configuration: OpenAI:Token."));

// Microsoft.Extensions.AI.OpenAI(preview), System.ClientModel
// var openAIOptions = new OpenAIClientOptions()
// {
//     Endpoint = new Uri("https://api.openai.com/v1/models")
// }
var modelsClient = new OpenAIClient(credential);
IChatClient chatClient = modelsClient.GetChatClient("gpt-4o-mini").AsIChatClient; //preview
IEmbeddingGenerator embeddingGenerator = modelsClient.GetEmbeddingClient("text-embedding-3-small").AsIEmbeddingGenerator; //preview

// Microsoft.Extensions.AI
var request = new ChatMessage(ChatRole.User, "화성의 노을은 어떤 색일까?");
List<ChatMessage> messages = new();
var responseText = new TextContent("");
ChatMessage? currentResponseMessage = new ChatMessage(ChatRole.Assistant, [responseText]);
await foreach (var update in chatClient.GetStreamingResponseAsync([.. messages]))
{
    messages.AddMessages(update, filter: c => c is not TextContent);
    responseText.Text += update.Text;
    Console.Write(update.Text);
}
messages.Add(currentResponseMessage!);
currentResponseMessage = null;

// Program ends here.
Console.WriteLine("============================================================");
Console.WriteLine(responseText.Text);