using System.ComponentModel;
using System.Windows.Controls;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Desktop.Controls
{
    public class BaseControl : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseControl()
        {
            // Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
        }
    }

    public class BaseControl<VM> : BaseControl where VM : BaseViewModel, new()
    {
        #region Private Member

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => mViewModel;
            set
            {
                // If nothing has changed, return
                if (mViewModel == value)
                    return;

                // Update the value
                mViewModel = value;

                // Set the data context for this page
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseControl() : base()
        {
            // Create a default view model
            ViewModel = new VM();
        }

        #endregion
    }
}
