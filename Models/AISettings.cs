namespace SyncfusionSemanticKernelMaui.Models;

public class AISettings
{
    public string? Service { get; set; }
    public Provider? AzureOpenAI { get; set; }
    public Provider? OpenAI { get; set; }
    public Provider? Google { get; set; }
    public Provider? Ollama { get; set; }
    public Provider? Groq { get; set; }
}