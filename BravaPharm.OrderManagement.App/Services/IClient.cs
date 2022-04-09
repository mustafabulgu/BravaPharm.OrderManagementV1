using System.Net.Http;

namespace BravaPharm.OrderManagement.App.Services
{
    public partial interface IClient
    {
        HttpClient HttpClient { get; }
    }
}
