using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Bookfiend.BlazorUI;
using Bookfiend.BlazorUI.Shared;
using Bookfiend.BlazorUI.Contracts;
using Bookfiend.BlazorUI.Models.Authors;

namespace Bookfiend.BlazorUI.Pages.Authors
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthorService AuthorService { get; set; }
        public List<AuthorVM> Authors { get; set; }
        public string Message { get; set; } = string.Empty;
        protected void CreateAuthor()
        {
            NavigationManager.NavigateTo("/authors/create/");
        }
        protected void UpdateAuthor(int id)
        {
            NavigationManager.NavigateTo($"/authors/edit/{id}");

        }
        protected void AuthorDetails(int id)
        {
            NavigationManager.NavigateTo($"/authors/details/{id}");

        }
        protected async Task DeleteAuthor(int id)
        {
            var response = await AuthorService.DeleteAuthor(id);
            if(response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }

        }
        protected override async Task OnInitializedAsync()
        {
           Authors = await AuthorService.GetAllAuthors();
        }

    }
}