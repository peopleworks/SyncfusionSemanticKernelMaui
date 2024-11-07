using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SyncfusionSemanticKernelMaui.Models;

namespace SyncfusionSemanticKernelMaui.Services;

public class AssistantService:IAssistantService
{
    private readonly AISettings _aiSettings;
    private readonly IConfiguration _configuration;
    private  IChatCompletionService _chatCompletion;
    private  ChatHistory _chatHistory;
    private  Kernel _kernel;
    private  OpenAIPromptExecutionSettings _executionSettings;
    
    public AssistantService(IConfiguration configuration,AISettings aiSettings)
    {
        _aiSettings = aiSettings;
        _configuration = configuration;
    }

   public void Build(KernelService service,string endpoint = "")
    {
        _chatHistory = new ChatHistory();

        // Define settings for AI behavior
        
        _executionSettings = new OpenAIPromptExecutionSettings
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
            ChatSystemPrompt = "You are a helpful assistant.Always respond in proper HTML format, but do not include <html>, <head>, or <body> tags.",
            Temperature = 0.5,
            MaxTokens = null
        };

        // Initialize Kernel and Services
        _kernel = CreateKernel(service,endpoint);
        _kernel.ImportPluginFromType<MobilePlugin>();
        _chatCompletion = _kernel.GetRequiredService<IChatCompletionService>();
 
    }
    public async Task<ChatMessageContent?> SendMessageAsync(string userMessage)
    {
        if (string.IsNullOrEmpty(userMessage))
            return null;

        _chatHistory.AddUserMessage(userMessage);
        var response = await _chatCompletion.GetChatMessageContentAsync(_chatHistory, _executionSettings, _kernel);

        return response;
    }

    private Kernel CreateKernel(KernelService service,string endpoint = "")
    {
        var builder = Kernel.CreateBuilder();
        HttpClient httpClient = new(new CustomDelegatingHandler(endpoint));
        switch (service)
        {
            case KernelService.AzureOpenAI:
                return builder.AddAzureOpenAIChatCompletion( 
                        _aiSettings.AzureOpenAI.Model,
                    _aiSettings.AzureOpenAI.ServiceId,
                    _aiSettings.AzureOpenAI.ApiKey,
                        serviceId: _aiSettings.AzureOpenAI.Name)
                    .Build();

            case KernelService.OpenAI:
                return builder.AddOpenAIChatCompletion(_aiSettings.OpenAI.Model,_aiSettings.OpenAI.ApiKey)
                    .Build();

            case KernelService.GoogleGemini:
                #pragma warning disable SKEXP0070
                return builder.AddGoogleAIGeminiChatCompletion(
                        _aiSettings.Google.Model,
                        _aiSettings.Google.ApiKey)
                    .Build();
            
            case KernelService.Ollama:
                return builder.AddOllamaChatCompletion(
                        _aiSettings.Ollama.Model,
                    new Uri(   _aiSettings.Ollama.Endpoint))
                    .Build();

            case KernelService.Groq:
      

                return builder.AddOpenAIChatCompletion(
                    _aiSettings.Groq.Model,
                    _aiSettings.Groq.ApiKey,
                    httpClient: httpClient)
                    .Build();

            default:
                throw new ArgumentException("Invalid service selected", nameof(service));
        }
    }
    
}

public class CustomDelegatingHandler : DelegatingHandler
{
    private readonly string _uri;
    public CustomDelegatingHandler(string uri) : base(new HttpClientHandler())
    {
        _uri = uri;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(_uri))
        {
            request.RequestUri = new Uri(request.RequestUri.ToString().Replace("https://api.openai.com/v1", _uri));

        }
        return await base.SendAsync(request, cancellationToken);
    }
}