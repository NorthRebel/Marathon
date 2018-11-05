using System.Windows.Input;
using Marathon.Core.Models;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.Menus
{
    /// <summary>
    /// The view model for a administrator page
    /// </summary>
    public class AdministratorMenuViewModel : SignedInViewModel
    {
        #region Commands

        /// <summary>
        /// Go to users management page
        /// </summary>
        public ICommand ManageUsersCommand { get; set; }

        /// <summary>
        /// Go to volunteers management page
        /// </summary>
        public ICommand ManageVolunteersCommand { get; set; }

        /// <summary>
        /// Go to charities management page
        /// </summary>
        public ICommand ManageCharitiesCommand { get; set; }

        /// <summary>
        /// Go to inventory management page
        /// </summary>
        public ICommand ManageInventoryCommand { get; set; }

        #endregion

        #region Constructor

        public AdministratorMenuViewModel()
        {
            PageCaption = new PageCaptionViewModel("Меню администратора");

            ManageInventoryCommand = new RelayCommand(x => GoToPage(ApplicationPage.Inventory));
            ManageUsersCommand = new RelayCommand(x => GoToPage(ApplicationPage.UsersListToManage));
            ManageCharitiesCommand = new RelayCommand(x => GoToPage(ApplicationPage.CharitiesListToManage));
            ManageVolunteersCommand = new RelayCommand(x => GoToPage(ApplicationPage.VolunteersListToManage));
        }

        #endregion

        #region Command Helpers

        
        
        #endregion
    }
}
