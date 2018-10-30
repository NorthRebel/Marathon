using System.Collections.Generic;
using Marathon.Core.ViewModel.Input;

namespace Marathon.Core.ViewModel.ImportVolunteers.Design
{
    /// <summary>
    /// The design-time data for a <see cref="ImportVolunteersViewModel"/>
    /// </summary>
    public class ImportVolunteersDesignModel : ImportVolunteersViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ImportVolunteersDesignModel Instance => new ImportVolunteersDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ImportVolunteersDesignModel()
        {
            var attributesRequirements = new List<EntryViewModel<string>>();

            for (int i = 1; i <= 5; i++)
                attributesRequirements.Add(new EntryViewModel<string>($"Поле {i}") {Value = "Описание поля"});

            RequiredFields = attributesRequirements;

            ImportProgress.MaxValue = 98;
            ImportProgress.CurrentValue = 63;
            ImportProgress.CalculatePercentage();
        }

        #endregion
    }
}
