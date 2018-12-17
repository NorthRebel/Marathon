using System;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;
using Marathon.Core.ViewModel.RunnersListToManage.Models;
using Marathon.Core.ViewModel.RunnersListToManage.RunnersList;

namespace Marathon.Core.ViewModel.RunnersListToManage
{
    /// <summary>
    /// The view model for a runners list to manage page
    /// </summary>
    public class RunnersListToManageViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of runner sign up status
        /// </summary>
        public ItemsEntryViewModel<string> Statuses { get; set; }

        /// <summary>
        /// List of distances of marathon
        /// </summary>
        public ItemsEntryViewModel<string> Distances { get; set; }

        /// <summary>
        /// Attributes of runners list for <see cref="SortCommand"/>
        /// </summary>
        public ItemsEntryViewModel<string> AttributesToSort { get; set; }

        /// <inheritdoc cref="ManageRunnersCondition"/>
        public ManageRunnersCondition RunnersCondition { get; set; }

        /// <inheritdoc cref="RunnersListViewModel"/>
        public RunnersListViewModel Runners { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Sort runners by selected attribute
        /// </summary>
        public ICommand SortCommand { get; set; }

        /// <summary>
        /// Find runners by condition of runners properties
        /// </summary>
        public ICommand FindCommand { get; set; }

        /// <summary>
        /// Clear runners results condition
        /// </summary>
        public ICommand ClearCommand { get; set; }

        /// <summary>
        /// Exports detailed info about signed up runners
        /// </summary>
        public ICommand ExportDetailedInfoCommand { get; set; }

        /// <summary>
        /// Exports list of runners email
        /// </summary>
        public ICommand ExportEmailCommand { get; set; }

        #endregion

        #region Constructor

        public RunnersListToManageViewModel()
        {
            PageCaption = new PageCaptionViewModel("Управление бегунами");

            Statuses = new ItemsEntryViewModel<string>("Статус");
            Distances = new ItemsEntryViewModel<string>("Дистанция");
            AttributesToSort = new ItemsEntryViewModel<string>("Сортировать");

            RunnersCondition = new ManageRunnersCondition();
            Runners = new RunnersListViewModel();

            FindCommand = new RelayCommand(SortRunners);
            SortCommand = new RelayCommand(FindRunners);
            ClearCommand = new RelayCommand(ClearRunnersFindCondition);
        }

        #endregion

        #region Command Helpers

        private void SortRunners(object obj)
        {
            throw new NotImplementedException();
        }

        private void FindRunners(object obj)
        {
            throw new NotImplementedException();
        }

        private void ClearRunnersFindCondition(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
