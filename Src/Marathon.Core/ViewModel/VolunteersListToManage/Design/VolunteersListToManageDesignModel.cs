﻿using Marathon.Core.ViewModel.VolunteersListToManage.VolunteersList.Design;

namespace Marathon.Core.ViewModel.VolunteersListToManage.Design
{
    /// <summary>
    /// The design-time data for a <see cref="VolunteersListToManageViewModel"/>
    /// </summary>
    public class VolunteersListToManageDesignModel : VolunteersListToManageViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VolunteersListToManageDesignModel Instance => new VolunteersListToManageDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VolunteersListToManageDesignModel()
        {
            Countries = new[]
            {
                "Japan",
                "Germany"
            };

            Genders = new[]
            {
                "Male",
                "Female"
            };

            AttributesToSort = new[]
            {
                "Имя",
                "Фамилия",
                "Страна",
                "Пол",
            };

            Volunteers = new VolunteersListDesignModel();
        }

        #endregion
    }
}
