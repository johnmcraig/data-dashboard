using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataDashboard.Client.Shared
{
    public partial class Confirmation
    {
        private string _modalDisplay;
        private bool _showBackDrop;

        [Parameter]
        public string BodyMessage { get; set; }

        [Parameter]
        public EventCallback OnOKClick { get; set; }

        public void Show()
        {
            _modalDisplay = "block;";
            _showBackDrop = true;
            StateHasChanged();
        }

        public void Hide()
        {
            _modalDisplay = "none;";
            _showBackDrop = false;
            StateHasChanged();
        }

    }
}
