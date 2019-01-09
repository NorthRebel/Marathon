using Marathon.API.Models.Charity;

namespace Marathon.Core.ViewModel.SignUpToMarathon.Design
{
    /// <summary>
    /// The design-time data for a <see cref="CharityDetailViewModel"/>
    /// </summary>
    public class CharityDetailDesignModel : CharityDetailViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static CharityDetailDesignModel Instance => new CharityDetailDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CharityDetailDesignModel()
        {
            Charities = new[]
            {
                new Charity
                {
                    Id = 1,
                    Name = "Фонд А"
                },
                new Charity
                {
                    Id = 2,
                    Name = "Фонд Б"
                },
                new Charity
                {
                    Id = 3,
                    Name = "Фонд В"
                },
            };
        }

        #endregion
    }
}
