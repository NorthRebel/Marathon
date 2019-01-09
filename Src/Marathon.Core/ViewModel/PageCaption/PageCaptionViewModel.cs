using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.PageCaption
{
    /// <summary>
    /// The view model for a page caption control
    /// </summary>
    public class PageCaptionViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Caption of a page
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Description, which explains information about page content 
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Caption is necessary
        /// </summary>
        /// <param name="caption"><inheritdoc cref="Caption"/></param>
        public PageCaptionViewModel(string caption)
        {
            Caption = caption;
        }

        /// <summary>
        /// Fill all properties
        /// </summary>
        /// <param name="caption"><inheritdoc cref="Caption"/></param>
        /// <param name="description"><inheritdoc cref="Description"/></param>
        public PageCaptionViewModel(string caption, string description) : this(caption)
        {
            Description = description;
        }

        #endregion
    }
}
