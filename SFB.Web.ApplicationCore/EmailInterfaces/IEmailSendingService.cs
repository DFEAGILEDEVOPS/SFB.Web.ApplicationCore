using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.Services
{
    public interface IEmailSendingService
    {
        Task<string> SendDataQueryUserEmailAsync(string toAddress, Dictionary<String, dynamic> placeholders);
        Task<string> SendDataQueryDfEEmailAsync(string toAddress, Dictionary<String, dynamic> placeholders);        
        Task<string> SendContactUsUserEmailAsync(string toAddress, Dictionary<String, dynamic> placeholders);
        Task<string> SendContactUsDfEEmailAsync(string toAddress, Dictionary<String, dynamic> placeholders);
        Task<string> SendGetInvolvedEmailAsync(string toAddress, Dictionary<String, dynamic> placeholders);
    }
}