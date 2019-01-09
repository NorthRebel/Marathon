using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.API.Models.Marathon;

namespace Marathon.API.Services
{
    public interface IMarathonService : IService
    {
        Task<IEnumerable<EventType>> GetEventTypes();

        Task<int> SignUp(MarathonSignUp signUpCredentials);

        Task<StartupDate> GetStartupDate();
    }
}
