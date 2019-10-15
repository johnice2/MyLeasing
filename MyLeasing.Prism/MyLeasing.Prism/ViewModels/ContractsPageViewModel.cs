using MyLeasing.Common.Helpers;
using MyLeasing.Common.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyLeasing.Prism.ViewModels
{
    public class ContractsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private PropertyResponse _property;
        private ObservableCollection<ContractItemViewModel> _contracts;

        public ContractsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Contracts";
            Property = JsonConvert.DeserializeObject<PropertyResponse>(Settings.Property);
            if (Property.Contracts != null)
            {
                LoadContracts();
            }
            
        }

        public PropertyResponse Property
        {
            get => _property;
            set => SetProperty(ref _property, value);
        }

        public ObservableCollection<ContractItemViewModel> Contracts
        {
            get => _contracts;
            set => SetProperty(ref _contracts, value);
        }

        

        private void LoadContracts()
        {
           
            Contracts = new ObservableCollection<ContractItemViewModel>(_property.Contracts.Select(c => new ContractItemViewModel(_navigationService)
            {
                EndDate = c.EndDate,
                Id = c.Id,
                IsActive = c.IsActive,
                Lessee = c.Lessee,
                Price = c.Price,
                Remarks = c.Remarks,
                StartDate = c.StartDate
            }).ToList());
        }
    }
}
