using System.Collections.Generic;

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
            var attributesRequirements = new List<KeyValuePair<string, string>>();

            for (int i = 1; i <= 5; i++)
                attributesRequirements.Add(new KeyValuePair<string, string>($"Поле {i}", "Описание поля"));

            RequiredFields = attributesRequirements;

            ImportProgress.IsBusy = true;
            ImportProgress.MaxValue = 98;
            ImportProgress.CurrentValue = 63;
            ImportProgress.CalculatePercentage();
        }

        #endregion
    }
}
