using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.AIAssistView;
using SyncfusionSemanticKernelMaui.Models;
using SyncfusionSemanticKernelMaui.Services;

namespace SyncfusionSemanticKernelMaui.ViewModels;

public class MainViewModel:BaseViewModel
{
    private readonly IAssistantService _assistantService;
    public ObservableCollection<Provider> Providers { get; set; }
    public ObservableCollection<IAssistItem> AssistItems { get; set; }
    public ICommand AssistViewRequestCommand { get; set; }
    public bool ShowBackLayer { get; set; }
    public ICommand SelectedCommand { get; set; }
    public Provider Provider { get; set; }

    public MainViewModel(IAssistantService assistantService,AISettings aiSettings)
    {
        _assistantService = assistantService;
        AssistItems = new ObservableCollection<IAssistItem>()
        {
            new AssistItem() {Text = "Hello, I am your AI assistant. How can I help you?"}
        };
        Providers = new ObservableCollection<Provider>()
        {
            new Provider()
            {
                ApiKey = aiSettings.AzureOpenAI.ApiKey, Endpoint = aiSettings.AzureOpenAI.Endpoint,
                Id = aiSettings.AzureOpenAI.Id, Name = "Azure OpenAI", Model = aiSettings.AzureOpenAI.Model,
                ServiceId = aiSettings.AzureOpenAI.ServiceId,
                Icon = "microsoft_azure_logo"
            },
            new Provider()
            {
                ApiKey = aiSettings.OpenAI.ApiKey, Endpoint = aiSettings.OpenAI.Endpoint, Id = aiSettings.OpenAI.Id,
                Name = "OpenAI", Model = aiSettings.OpenAI.Model, ServiceId = aiSettings.OpenAI.ServiceId,
                Icon = "openia_logo"
            },
            new Provider()
            {
                ApiKey = aiSettings.Google.ApiKey, Endpoint = aiSettings.Google.Endpoint, Id = aiSettings.Google.Id,
                Name = "Google", Model = aiSettings.Google.Model, ServiceId = aiSettings.Google.ServiceId,
                Icon = "gemini_logo"
            },
            new Provider()
            {
                ApiKey = aiSettings.Ollama.ApiKey, Endpoint = aiSettings.Ollama.Endpoint, Id = aiSettings.Ollama.Id,
                Name = "Ollama", Model = aiSettings.Ollama.Model, ServiceId = aiSettings.Ollama.ServiceId,
                Icon = "ollama"
            },
            new Provider()
            {
                ApiKey = aiSettings.Groq.ApiKey, Endpoint = aiSettings.Groq.Endpoint, Id = aiSettings.Groq.Id,
                Name = "Groq", Model = aiSettings.Groq.Model, ServiceId = aiSettings.Groq.ServiceId,
                Icon = "groqai"
            }

        };
        this.AssistViewRequestCommand = new Command<object>( async (p)=> await RunSafe(()=>ExecuteRequestCommand(p)));
        ShowBackLayer = true;
        SelectedCommand = new Command<Provider>(  BuildAI);
        Init();
    }

    public void Init()
    {
        
        try
        {
            BuildAI(Providers.LastOrDefault());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    void BuildAI(Provider provider)
    {
        try
        {
            Provider = provider;
            ShowBackLayer = false;
            _assistantService.Build((KernelService) provider.Id, provider.Endpoint);
            AssistItems = new ObservableCollection<IAssistItem>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
   
        }
    }
    
    private async Task ExecuteRequestCommand(object obj)
    {
        var request = (obj as Syncfusion.Maui.AIAssistView.RequestEventArgs)?.RequestItem;
        await GetResult(request).ConfigureAwait(true);
    }

    private async Task GetResult(IAssistItem? inputQuery)
    {
        if (inputQuery == null)
        {
            return;
        }
        AssistItem request = (AssistItem) inputQuery;

        this.AssistItems.Add(new AssistItem(){IsRequested = true,Text = ""});
        // Generating response from AI
        var response = await _assistantService.SendMessageAsync(request.Text);
        // Creating response item using response received from AI
        AssistItem responseItem = new AssistItem() {Text = response.Content};
        responseItem.RequestItem = inputQuery;
        this.AssistItems.Add(responseItem);

    }

}