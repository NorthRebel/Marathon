using System.Collections.Generic;
using Marathon.API.Models.Marathon;

namespace Marathon.API.Repositories.Interfaces
{
    public interface IMarathonRepository
    {
        /// <summary>
        /// Gets all types of marathon events
        /// </summary>
        IEnumerable<EventType> GetAllEventTypes();

        /// <summary>
        /// Signs up runner to marathon events and creates common sign up record
        /// </summary>
        /// <param name="signUpCredentials">Credentials for sign runner to marathon events</param>
        /// <returns>Id of marathon sign up</returns>
        int SignUp(MarathonSignUp signUpCredentials);
    }
}
