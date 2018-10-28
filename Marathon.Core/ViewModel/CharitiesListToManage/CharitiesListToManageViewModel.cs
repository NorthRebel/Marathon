using System;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.CharitiesListToManage.CharitiesList;

namespace Marathon.Core.ViewModel.CharitiesListToManage
{
    /// <summary>
    /// The view model for a charities list to manage page
    /// </summary>
    public class CharitiesListToManageViewModel : PageViewModel
    {
        #region Public Properties

        /// <inheritdoc cref="CharitiesListViewModel"/>
        public CharitiesListViewModel Charities { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Adds new charity organization
        /// </summary>
        public ICommand AddNewCharityCommand { get; set; }

        #endregion

        #region Constructor

        public CharitiesListToManageViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Управление благотворительными организациями",
            };

            Charities = new CharitiesListViewModel();

            AddNewCharityCommand = new RelayCommand(AddNewCharity);
        }

        #endregion

        #region Command Helpers

        private void AddNewCharity(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
