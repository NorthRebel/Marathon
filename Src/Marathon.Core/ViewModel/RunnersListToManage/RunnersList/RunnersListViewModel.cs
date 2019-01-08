﻿using System.Collections.Generic;
using System.Windows.Input;
using Marathon.Core.ViewModel.Base;

namespace Marathon.Core.ViewModel.RunnersListToManage.RunnersList
{
    /// <summary>
    /// The view model for runners list
    /// </summary>
    public class RunnersListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of signed up runners
        /// </summary>
        public IEnumerable<RunnersListItemViewModel> Items { get; set; }

        /// <summary>
        /// Count of <see cref="Items"/>
        /// </summary>
        public long ItemsCount { get; set; }

        /// <summary>
        /// Edit selected runner from <see cref="Items"/>
        /// </summary>
        public ICommand EditRunnerCommand { get; set; }
    }
}
