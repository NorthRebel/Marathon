namespace Marathon.Core.Models
{
    /// <summary>
    /// A page of the application
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// Main page of system. Any user can show him when application is starts.
        /// </summary>
        Main = 1,

        /// <summary>
        /// If runner didn't take part in competition before, he must sign up in system.
        /// Else he must to sign in to system.
        /// </summary>
        CheckRunner,

        /// <summary>
        /// Runners (which signed up before), Coordinators and Administrators can sign in to system using email and password.
        /// </summary>
        SignIn,

        /// <summary>
        /// Runners, which didn't take part in competition before, must sign up as runner.
        /// This takes them to sign in to system.
        /// He must do this for take part in competition.
        /// </summary>
        SignUpRunner,

        /// <summary>
        /// Runners must signed up in system before sign up to marathon.
        /// They must sign in to system before.
        /// This page provides runner to sign up to take part in competitions. 
        /// </summary>
        RegisterToMarathon,

        /// <summary>
        /// This page provides user to sponsor runner, which sign up to competition.
        /// They can select runner and sponsorship amount via credit card.
        /// </summary>
        SponsorRunner,

        /// <summary>
        /// This page provides sponsor to confirm his sponsorship.
        /// He gives runner name and sponsorship amount.
        /// </summary>
        SponsorshipConfirm,

        /// <summary>
        /// This page provides runner to confirm, what he was signed up.
        /// He gives message that contains: "Coordinators will call him".
        /// </summary>
        RegisterRunnerConfirm,

        /// <summary>
        /// Runners could show this page, when they signed in.
        /// This provides all actions, which runner have access.
        /// </summary>
        RunnerMenu,

        /// <summary>
        /// This page provides access to a lot of information about marathon and related things.
        /// </summary>
        MarathonMenu,

        /// <summary>
        /// This page provides information about current marathon on 2016.
        /// This provides information about race, including interactive map.
        /// </summary>
        AboutMarathon,

        /// <summary>
        /// This is interactive map of marathon. This shows way, used for marathon and all different features of way.
        /// This shows things as: stands of drink, toilets, checkpoints, attractions and etc.
        /// </summary>
        InteractiveMap,

        /// <summary>
        /// This page shows list of charity organizations, which takes part in Marathon Skills 2016.
        /// When runner signing up, he selects charity organization, which supported.
        /// </summary>
        CharityList,

        /// <summary>
        /// This page shows previous race results.
        /// </summary>
        MarathonResults,

        /// <summary>
        /// This is interactive page, which explains how long marathon in terms of distance and time.
        /// </summary>
        HowLongMarathon,

        /// <summary>
        /// This page provides user to edit his profile.
        /// </summary>
        EditRunnerProfile,

        /// <summary>
        /// This page shows to runner his previous results.
        /// </summary>
        RunnerResults,

        /// <summary>
        /// This page shows to runner his sponsorship, if he is signed up to current marathon.
        /// </summary>
        MySponsorship,

        /// <summary>
        /// Coordinators could show this page, when they signed in.
        /// This provides all actions, which coordinator have access.
        /// </summary>
        CoordinatorMenu,

        /// <summary>
        /// Administrators could show this page, when they signed in.
        /// This provides all actions, which administrator have access.
        /// </summary>
        AdministratorMenu,

        /// <summary>
        /// This page shows all sponsorship, which was received for current marathon.
        /// Sponsorship grouped by charity organization, which receives cash.
        /// </summary>
        SponsorsReview,

        /// <summary>
        /// This page shows list of runners, which signed up to current marathon.
        /// Coordinators have access to this page to manage runners. 
        /// </summary>
        RunnersListToManage,

        /// <summary>
        /// This page provides coordinator to manage information about runner.
        /// </summary>
        RunnerInfoManage,

        /// <summary>
        /// This page provides to manage runner profile.
        /// </summary>
        ManageRunnerProfile,

        /// <summary>
        /// This page shows runner certificate preview. 
        /// </summary>
        ShowSertificate,

        /// <summary>
        /// This page provides administrator to edit list of charity organizations.
        /// </summary>
        CharitiesListToManage,

        /// <summary>
        /// This page provides administrator to add new charity organization 
        /// </summary>
        AddCharity,

        /// <summary>
        /// This page provides administrator to edit details of charity organization 
        /// </summary>
        EditCharity,

        /// <summary>
        /// This page shows list of all volunteers, which take a part in competition.
        /// Administrators load volunteers to system and use this page for show of loaded.
        /// </summary>
        VolunteersListToManage,

        /// <summary>
        /// This page uses by Administrator for load volunteers from third-party source.
        /// </summary>
        LoadVolunteers,

        /// <summary>
        /// This page shows list of all users.
        /// Administrators uses this page to manage users.
        /// </summary>
        UsersListToManage,

        /// <summary>
        /// This page provides administrator to edit details of current user.
        /// </summary>
        EditUser,

        /// <summary>
        /// This page provides administrator to add new user.
        /// </summary>
        AddUser,

        /// <summary>
        /// This pages provides unsigned users to calculate body mass index (BMI).
        /// </summary>
        BMICalculator,

        /// <summary>
        /// This pages provides unsigned users to calculate basal metabolic rate (BMR).       
        /// </summary>
        BMRCalculator,

        /// <summary>
        /// This page shows list of remaining items of kits
        /// </summary>
        Inventory,

        /// <summary>
        /// This page provides to registration of receipt inventory items to stock 
        /// </summary>
        InventoryArrive
    }
}
