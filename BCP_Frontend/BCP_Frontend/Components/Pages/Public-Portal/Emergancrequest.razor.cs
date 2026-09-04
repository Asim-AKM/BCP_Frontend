using BCP_BL.Models;
using BCP_BL.PublicServices.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace BCP_Frontend.Components.Pages.Public_Portal
{
    public partial class Emergancrequest
    {
        [Inject]
        public IEmergencyBroadcastService broadcastService { get; set; }
        private EmergencyBroadcastRequest requestModel = new();
        private bool isSubmitting = false;
        private bool isSubmittedSuccessfully = false;

        private async Task HandleEmergencyBroadcast()
        {
            isSubmitting = true;
           await broadcastService.SendBroadcastAsync(requestModel);
            isSubmitting = false;
            isSubmittedSuccessfully = true;
        }

        private void ResetForm()
        {
            requestModel = new EmergencyBroadcastRequest();
            isSubmittedSuccessfully = false;
        }
 
    }
}
