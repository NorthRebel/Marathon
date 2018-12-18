using System;
using System.Windows.Input;
using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.Models
{
    /// <summary>
    /// List of attributes about runner credentials for sign up, edit profile, etc...
    /// </summary>
    public interface IRunnerProfile
    {
        #region Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        EntryViewModel<string> Email { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        EntryViewModel<string> FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        EntryViewModel<string> LastName { get; set; }

        /// <summary>
        /// Gender of the user
        /// </summary>
        ItemsEntryViewModel<string> Gender { get; set; }

        /// <summary>
        /// Path to photo of the user
        /// </summary>
        EntryViewModel<string> PhotoPath { get; set; }

        /// <summary>
        /// Photo of the user
        /// </summary>
        byte[] Photo { get; set; }

        /// <summary>
        /// The date of birth of the user
        /// </summary>
        EntryViewModel<DateTime?> BirthDay { get; set; }

        /// <summary>
        /// Country name of the user
        /// </summary>
        ItemsEntryViewModel<string> Country { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Discard edited changes
        /// </summary>
        ICommand CancelCommand { get; set; }

        /// <summary>
        /// Change <see cref="PhotoPath"/> of a runner profile
        /// </summary>
        ICommand ChangePhotoCommand { get; set; }

        #endregion
    }
}
