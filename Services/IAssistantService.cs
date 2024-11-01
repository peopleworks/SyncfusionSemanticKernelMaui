using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using SyncfusionSemanticKernelMaui.Models;

namespace SyncfusionSemanticKernelMaui.Services;

public interface IAssistantService
{
    Task<ChatMessageContent?> SendMessageAsync(string userMessage);

    public void Build(KernelService service,string endpoint = "");
}