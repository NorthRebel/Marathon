using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.Input;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.ImportVolunteers
{
    /// <summary>
    /// The view model for a import volunteers page
    /// </summary>
    public class ImportVolunteersViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// Selected file name to import
        /// </summary>
        public EntryViewModel<string> FileToImport { get; set; }

        /// <summary>
        /// List of required fields which <see cref="FileToImport"/> must contain
        /// </summary>
        public IEnumerable<EntryViewModel<string>> RequiredFields { get; set; }

        /// <summary>
        /// Shows process of importing from <see cref="FileToImport"/>
        /// </summary>
        public ProgressViewModel ImportProgress { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Selects file with volunteers info to import 
        /// </summary>
        public ICommand SelectFileCommand { get; set; }

        /// <summary>
        /// Starts importing volunteers from file process
        /// </summary>
        public ICommand ImportCommand { get; set; }

        /// <summary>
        /// Cancel import preparation (goes to previous page)
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public ImportVolunteersViewModel()
        {
            PageCaption = new PageCaptionViewModel("Загрузка волонтеров");

            FileToImport = new EntryViewModel<string>("CSV файл волонтеров");
            ImportProgress = new ProgressViewModel();

            SelectFileCommand = new RelayCommand(SelectFileToImport);
            ImportCommand = new RelayCommand(ImportVolunteersFromFile);
            CancelCommand = new RelayCommand(x => IoC.IoC.Application.GoToPreviousPage());
        }

        #endregion

        #region Command Helpers

        private void ImportVolunteersFromFile(object obj)
        {
            throw new System.NotImplementedException();
        }

        private void SelectFileToImport(object obj)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
