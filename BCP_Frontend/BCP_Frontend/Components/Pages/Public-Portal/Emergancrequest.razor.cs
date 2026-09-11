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
        private IProvinceService ProvinceService { get; set; } = default!;

        [Inject]
        private ICityService CityService { get; set; } = default!;
           

        private Guid? ProvinceID { get; set; }

        private Guid? CityId { get; set; }
        [Inject]
        public IEmergencyBroadcastService broadcastService { get; set; }
        private EmergencyBroadcastRequest requestModel = new();
        private List<GetAllProvinceResponse> Provinces = new();
        private List<GetAllCityResponse> AvailableCities = new();
        private bool isSubmitting = false;
        private bool isSubmittedSuccessfully = false;
        protected override async Task OnInitializedAsync()
        {
            Provinces = await ProvinceService.GetAllAsync();
        }


        private async Task OnProvinceChanged(Guid? provinceId)
        {
            ProvinceID = provinceId;

            CityId = null;
            AvailableCities.Clear();

            if (provinceId.HasValue)
            {
                AvailableCities =await CityService.GetByProvinceIdAsync(provinceId.Value);
            }
        }

        private async Task HandleEmergencyBroadcast()
        {
            try
            {
                isSubmitting = true;

                requestModel.ProvinceId = ProvinceID ?? Guid.Empty;
                requestModel.CityId = CityId ?? Guid.Empty;

                await broadcastService.SendBroadcastAsync(requestModel);

                isSubmittedSuccessfully = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isSubmitting = false;
            }
        }

        private void ResetForm()
        {
            requestModel = new EmergencyBroadcastRequest();
            isSubmittedSuccessfully = false;
        }
 
    }
}
