using BCP_BL.AdminService.Interface;
using BCP_BL.Models;
using BCP_BL.Shared;
using Microsoft.AspNetCore.Components;

namespace BCP_Frontend.Components.Pages.Admin_Portal
{
    public partial class AllCenters
    {
        [Inject]
        private IAdminServices adminServices { get; set; }
        private List<GetAllBloodCentersResponse> allCenters = new();
        private List<GetAllBloodCentersResponse> filteredCenters = new();
        private GetAllBloodCentersResponse selectedCenter = null;

        // UI State
        private bool isLoading = true;
        private string errorMessage = "";
        private string searchTerm = "";
        private string selectedProvince = "";
        private string selectedTier = "";
        private BloodCenterStatus selectedStatus = BloodCenterStatus.Pending;
        private string adminRemarks = "";
        private string freezeReason = "SaaS Subscription Payment Overdue";

        // Modal state
        private bool isManageModalOpen = false;
        private bool isFreezeModalOpen = false;

        // Pagination
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 1;

        private int totalCenters => allCenters.Count;
        private int approvedCenters => allCenters.Count(c => c.IsActive == true);
        private int suspendedCenters => allCenters.Count(c => c.Status == BloodCenterStatus.Suspended || c.Status == BloodCenterStatus.Freeze);

        protected override async Task OnInitializedAsync()
        {
            await LoadCenters();
        }

        private async Task LoadCenters()
        {
            isLoading = true;
            errorMessage = "";

            try
            {
                var response = await adminServices.GetAll();

                if (response.IsSuccess && response.Data != null)
                {
                    // Only get centers where IsActive is true
                    allCenters = response.Data.Where(c => c.IsActive == true).ToList();
                    ApplyFilters();
                }
                else
                {
                    errorMessage = response.ErrorMessage ?? "Failed to load centers.";
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Error: {ex.Message}";
            }
            finally
            {
                isLoading = false;
            }
        }

        private void ApplyFilters()
        {
            var query = allCenters.AsEnumerable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                    c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.RegistrationNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.Address.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Apply status filter
            if (selectedStatus != BloodCenterStatus.Pending)
            {
                query = query.Where(c => c.Status == selectedStatus);
            }

            filteredCenters = query.ToList();
            UpdatePagination();
        }

        private void UpdatePagination()
        {
            totalPages = (int)Math.Ceiling((double)filteredCenters.Count / pageSize);
            if (currentPage > totalPages) currentPage = 1;
        }

        private void ResetFilters()
        {
            searchTerm = "";
            selectedProvince = "";
            selectedTier = "";
            selectedStatus = BloodCenterStatus.Pending;
            currentPage = 1;
            ApplyFilters();
        }

        // Pagination methods
        private void PreviousPage()
        {
            if (currentPage > 1)
            {
                currentPage--;
                ApplyFilters();
            }
        }

        private void NextPage()
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ApplyFilters();
            }
        }

        private void GoToPage(int page)
        {
            if (page >= 1 && page <= totalPages)
            {
                currentPage = page;
                ApplyFilters();
            }
        }

        // Modal handlers
        private void OpenManageModal(GetAllBloodCentersResponse center)
        {
            selectedCenter = center;
            selectedStatus = center.Status;
            adminRemarks = "";
            isManageModalOpen = true;
            isFreezeModalOpen = false;
        }

        private void OpenFreezeModal(GetAllBloodCentersResponse center)
        {
            selectedCenter = center;
            freezeReason = "SaaS Subscription Payment Overdue";
            isFreezeModalOpen = true;
            isManageModalOpen = false;
        }

        private async Task UpdateCenter()
        {
            if (selectedCenter == null) return;

            // TODO: Implement API call to update center
            CloseModals();
            await LoadCenters();
        }

        private async Task FreezeCenter()
        {
            if (selectedCenter == null) 
                return;

            var request = new UpdateBloodCenterRequest
            {
                Id = selectedCenter.Id,
                Name = selectedCenter.Name,
                RegistrationNumber = selectedCenter.RegistrationNumber,
                CityId = selectedCenter.CityId,
                Address = selectedCenter.Address,
                ContactPhone = selectedCenter.ContactPhone,
                EmergencyPhone = selectedCenter.EmergencyPhone,
                Status = BloodCenterStatus.Freeze,
                IsVerified = selectedCenter.IsVerified,
                IsActive = selectedCenter.IsActive
            };

            var response = await adminServices.UpdateStatus(request);

            if (response.IsSuccess)
            {
                CloseModals();
                await LoadCenters(); 
            }
            else
            {
                errorMessage = response.ErrorMessage ?? "Failed to freeze center";
            }
        }

        private async Task UnfreezeCenter(Guid centerId)
        {
            var center = allCenters.FirstOrDefault(c => c.Id == centerId);
            if (center == null) 
                return;

            var request = new UpdateBloodCenterRequest
            {
                Id = center.Id,
                Name = center.Name,
                RegistrationNumber = center.RegistrationNumber,
                CityId = center.CityId,
                Address = center.Address,
                ContactPhone = center.ContactPhone,
                EmergencyPhone = center.EmergencyPhone,
                Status = BloodCenterStatus.UnFreeze,
                IsVerified = center.IsVerified,
                IsActive = center.IsActive
            };

            var response = await adminServices.UpdateStatus(request);

            if (response.IsSuccess)
            {
                await LoadCenters();
            }
            else
            {
                errorMessage = response.ErrorMessage ?? "Failed to unfreeze center";
            }
        }
        private void CloseModals()
        {
            isManageModalOpen = false;
            isFreezeModalOpen = false;
            selectedCenter = null;
        }
    }
}