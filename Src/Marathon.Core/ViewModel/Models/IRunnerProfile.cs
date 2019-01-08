using System;
using Marathon.API.Models;
using System.Windows.Input;
using System.Collections.Generic;

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
        string Email { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Confirmation of <see cref="Password"/>
        /// </summary>
        string ConfirmPassword { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gender of the user
        /// </summary>
        char GenderId { get; set; }

        /// <summary>
        /// List of gender to select
        /// </summary>
        IEnumerable<Gender> Genders { get; set; }

        /// <summary>
        /// Path to photo of the user
        /// </summary>
        string PhotoPath { get; set; }

        /// <summary>
        /// Photo of the user
        /// </summary>
        byte[] Photo { get; set; }

        /// <summary>
        /// The date of birth of the user
        /// </summary>
        DateTime? BirthDay { get; set; }

        /// <summary>
        /// Country name of the user
        /// </summary>
        string CountryId { get; set; }

        /// <summary>
        /// List of countries to select
        /// </summary>
        IEnumerable<Country> Countries { get; set; }

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
