using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_blazor_maui.Pages
{
    public partial class Index
    {
        public int? WordLength { get; set; } = null;
        public int? IncorrectAttempts { get; set; } = null;

        [Inject]
        private NavigationManager navManager { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        public Index()
        {
        }

        public async void StartNewGame()
        {
            if(WordLength == null || WordLength < 3 || WordLength > 12)
            {
                await JSRuntime.InvokeAsync<string>("alert", "Word length needs to be between 3 and 12");
                return;
            }
            if (IncorrectAttempts == null || IncorrectAttempts < 1 || IncorrectAttempts > 12)
            {
                await JSRuntime.InvokeAsync<string>("alert", "Incorrect attempts need to be between 1 and 12");
                return;
            }
            navManager.NavigateTo($"/start/{WordLength}/{IncorrectAttempts}", true, false );
        }
 
        public void ValidateResult()
        {
            if(WordLength != null)
            {

            }
        }
    }
}
