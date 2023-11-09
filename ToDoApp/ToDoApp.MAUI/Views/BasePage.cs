using System;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.MAUI.Views
{
	public class BasePage:ContentPage,IQueryAttributable
	{
		public BasePage()
		{
		}

        IDictionary<string, object> _navigationParameters=null;
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query is not null)
                _navigationParameters = query;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is INavigationAware)
            {
                await(BindingContext as INavigationAware).OnNavigatedTo(_navigationParameters);
                _navigationParameters = null;
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext is INavigationAware)
            {
                await(BindingContext as INavigationAware).OnNavigatedFrom(_navigationParameters);
                _navigationParameters = null;
            }
        }
    }
}

