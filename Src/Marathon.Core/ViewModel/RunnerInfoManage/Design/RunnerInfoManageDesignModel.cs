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
            Email = "brian_urban@gmail.com";
            FirstName = "Brian";
            LastName = "Urban";
            Gender = "Man";
            DateOfBirth = new DateTime(1972, 10, 03);
            CountryName = "Bulgaria";
            CharityOrganization = "PRO Sport LTD";
            SponsorshipAmount = 16842m;
            SelectedRaceKit = "Вариант B($20): вариант A +бейсболка + бутылка воды.";
            SelectedDistance = "5km Малая дистанция ($20)";

            Statuses = new SignUpStatusListDesignModel();
        }

        #endregion
    }
}
