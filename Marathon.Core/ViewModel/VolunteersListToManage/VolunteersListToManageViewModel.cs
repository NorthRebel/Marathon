using System;
using Marathon.Core.Models;
using System.Windows.Input;
using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.VolunteersListToManage.Models;
using Marathon.Core.ViewModel.VolunteersListToManage.VolunteersList;

namespace Marathon.Core.ViewModel.VolunteersListToManage
{
    /// <summary>
    /// The view model for a volunteers list to manage page
    /// </summary>
    public class VolunteersListToManageViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of countries which volunteers from
        /// </summary>
        public EntryViewModel<IEnumerable<string>> Countries { get; set; }

        /// <summary>
        /// List of volunteers gender
        /// </summary>
        public EntryViewModel<IEnumerable<string>> Genders { get; set; }

        /// <summary>
        /// Attributes of runners list for <see cref="SortCommand"/>
        /// </summary>
        public EntryViewModel<IEnumerable<string>> AttributesToSort { get; set; }

        /// <inheritdoc cref="ManageVolunteersCondition"/>
        public ManageVolunteersCondition VolunteersCondition { get; set; }

        /// <inheritdoc cref="VolunteersListViewModel"/>
        public VolunteersListViewModel Volunteers { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Sort volunteers by selected attribute
        /// </summary>
        public ICommand SortCommand { get; set; }

        /// <summary>
        /// Find volunteers by condition of volunteer properties
        /// </summary>
        public ICommand FindCommand { get; set; }

        /// <summary>
        /// Clear volunteers condition
        /// </summary>
        public ICommand ClearCommand { get; set; }

        /// <summary>
        /// Imports volunteers from third-party source
        /// </summary>
        public ICommand ImportVolunteersCommand { get; set; }

        #endregion

        #region Constructor

        public VolunteersListToManageViewModel()
        {
            PageCaption = new PageCaptionViewModel("Управление волонтерами");

            Countries = new EntryViewModel<IEnumerable<string>>("Страна");
            Genders = new EntryViewModel<IEnumerable<string>>("Пол");
            AttributesToSort = new EntryViewModel<IEnumerable<string>>("Сортировать");

            VolunteersCondition = new ManageVolunteersCondition();
            Volunteers = new VolunteersListViewModel();

            FindCommand = new RelayCommand(SortVolunteers);
            SortCommand = new RelayCommand(FindVolunteers);
            ClearCommand = new RelayCommand(ClearVolunteersFindCondition);
            ImportVolunteersCommand = new RelayCommand(x => GoToPage(ApplicationPage.ImportVolunteers));
        }

        #endregion

        #region Command Helpers

        private void SortVolunteers(object obj)
        {
            throw new NotImplementedException();
        }

        private void FindVolunteers(object obj)
        {
            throw new NotImplementedException();
        }

        private void ClearVolunteersFindCondition(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
