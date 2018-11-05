namespace Marathon.Core.ViewModel.PageCaption.Design
{
    /// <summary>
    /// The design-time data for a <see cref="PageCaptionViewModel"/>
    /// </summary>
    public class PageCaptionDesignModel : PageCaptionViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static PageCaptionDesignModel Instance => new PageCaptionDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageCaptionDesignModel() : base("Заголовок страницы", "Краткое описание страницы")
        {

        }

        #endregion
    }
}
