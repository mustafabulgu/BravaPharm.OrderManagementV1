using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.App.Contracts;
using BravaPharm.OrderManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BravaPharm.OrderManagement.App.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService  CategoryDataService { get; set; }

        public List<CategorySimpleViewModel> Categories { get; set; } = new List<CategorySimpleViewModel>();

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategories();
        }
    }
}
