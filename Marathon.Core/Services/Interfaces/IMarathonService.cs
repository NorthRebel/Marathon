using System.Threading.Tasks;
using System.Collections.Generic;
using Marathon.Core.Models.Marathon;

namespace Marathon.Core.Services.Interfaces
{
    public interface IMarathonService : IService
    {
        Task<IEnumerable<EventType>> GetEventTypes();

        Task<int> SignUp(MarathonSignUp signUpCredentials);
    }
}
