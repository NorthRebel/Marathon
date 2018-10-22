using System.Collections.Generic;
using Marathon.Core.ViewModel.Base;
using Marathon.Core.ViewModel.PageCaption;

namespace Marathon.Core.ViewModel.CharityList
{
    /// <summary>
    /// The view model for a charity list page 
    /// </summary>
    public class CharityListViewModel : PageViewModel
    {
        #region Public Properties

        /// <summary>
        /// Items of list
        /// </summary>
        public IEnumerable<CharityListItemViewModel> Items { get; set; }

        #endregion

        #region Constructor

        public CharityListViewModel()
        {
            PageCaption = new PageCaptionViewModel
            {
                Caption = "Список благотворительных организаций",
                Description = "Это - список всех благотворительных учреждений, которые поддерживаются в Marathon Skills 2016. " +
                              "Спасибо за помощь вы поддерживаете их, спонсируя бегунов!"
            };
        }

        #endregion
    }
}