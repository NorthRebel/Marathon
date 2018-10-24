using System;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;
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
        /// The secured password string of the user
        /// </summary>
        EntryViewModel<IHavePassword> Password { get; set; }

        /// <summary>
        /// The secured password string of the user to confirm this
        /// </summary>
        EntryViewModel<IHavePassword> ConfirmPassword { get; set; }

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
        EntryViewModel<string> Gender { get; set; }

        /// <summary>
        /// Path to photo of the user
        /// </summary>
        EntryViewModel<string> Photo { get; set; }

        /// <summary>
        /// The date of birth of the user
        /// </summary>
        EntryViewModel<DateTime> BirthDay { get; set; }

        /// <summary>
        /// Country name of the user
        /// </summary>
        EntryViewModel<string> Country { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Discard edited changes
        /// </summary>
        ICommand CancelCommand { get; set; }

        /// <summary>
        /// Change <see cref="Photo"/> of a runner profile
        /// </summary>
        ICommand ChangePhotoCommand { get; set; }

        #endregion
    }
}
