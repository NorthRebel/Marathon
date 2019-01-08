using System.Collections.Generic;
using System.Threading.Tasks;
using Marathon.API.Models.Marathon;

namespace Marathon.API.Services
{
    public interface IMarathonService : IService
    {
        Task<IEnumerable<EventType>> GetEventTypes();

        Task<int> SignUp(MarathonSignUp signUpCredentials);
    }
}
