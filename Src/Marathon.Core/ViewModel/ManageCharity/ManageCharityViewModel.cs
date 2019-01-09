﻿using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.ManageCharity
{
    /// <summary>
    /// The view model for a manage charity view model
    /// </summary>
    public class ManageCharityViewModel : SignedInViewModel
    {
        #region Public Properties

        /// <summary>
        /// Name of charity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Logo of charity
        /// </summary>
        public byte[] Logo { get; set; }

        /// <summary>
        /// Description of charity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// File name of selected logo
        /// </summary>
        public string LogoFileName { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Discard edited changes
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Change <see cref="Logo"/> of a charity organization
        /// </summary>
        public ICommand ChangeLogoCommand { get; set; }

        /// <summary>
        /// Adds new charity or save edited changes if exists
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        public ManageCharityViewModel()
        {
            // TODO: Add manage type selection
            PageCaption = new PageCaptionViewModel("Добавление/Редактирование благотворительных организаций");

            CancelCommand = new RelayCommand(x => Cancel());
        }

        #endregion

        #region Command Helpers

        /// <summary>
        /// Go to previous page
        /// </summary>
        private void Cancel()
        {
            IoC.IoC.Get<ApplicationViewModel>().GoToPreviousPage();
        }

        #endregion
    }
}
