using DataDashboard.Client.Contracts;
using DataDashboard.Client.Models;
using DataDashboard.Client.Shared;
using DataDashboard.Client.Static;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDashboard.Client.Pages.Customers 
{
    public partial class CustomerListBase
    {
        [Parameter]
        public IList<CustomerModel> Customers { get; set; }

        [Parameter]
        public EventCallback<int> OnDelete { get; set; }

        [Inject]
        public ICustomerRepository CustomerRepo { get; set; }

        private Confirmation _confirmation;
        private int _customerToDelete;
        

        //protected override async Task OnInitializedAsync()
        //{
        //    await base.OnInitializedAsync();
        //    await LoadCustomers(1, 10);
        //    StateHasChanged();
        //}

        private void CallConfirmationModal(int id)
        {
            _customerToDelete = id;
            _confirmation.Show();
        }

        private async Task LoadCustomers(int page, int pageSize)
        {
            await CustomerRepo.GetAll(Endpoints.CustomersEndpoint + $"?page={page}&pageSize={pageSize}");  
        }

        private async Task DeleteCustomer()
        {
            _confirmation.Hide();
            await OnDelete.InvokeAsync(_customerToDelete);
            await CustomerRepo.Delete(Endpoints.CustomersEndpoint, _customerToDelete);
            await LoadCustomers(1, 10);
        }

    }
}
