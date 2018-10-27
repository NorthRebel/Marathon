using System;
using Marathon.Core.ViewModel.RunnerInfoManage.SignUpStatus.Design;

namespace Marathon.Core.ViewModel.RunnerInfoManage.Design
{
    /// <summary>
    /// The design-time data for a <see cref="RunnerInfoManageViewModel"/>
    /// </summary>
    public class RunnerInfoManageDesignModel : RunnerInfoManageViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static RunnerInfoManageDesignModel Instance => new RunnerInfoManageDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RunnerInfoManageDesignModel()
        {
            Email.Value = "brian_urban@gmail.com";
            FirstName.Value = "Brian";
            LastName.Value = "Urban";
            Gender.Value = "Man";
            DateOfBirth.Value = new DateTime(1972, 10, 03);
            CountryName.Value = "Bulgaria";
            CharityOrganization.Value = "PRO Sport LTD";
            SponsorshipAmount.Value = 16842m;
            SelectedRaceKit.Value = "Вариант B($20): вариант A +бейсболка + бутылка воды.";
            SelectedDistance.Value = "5km Малая дистанция ($20)";

            Statuses = new SignUpStatusListDesignModel();
        }

        #endregion
    }
}
