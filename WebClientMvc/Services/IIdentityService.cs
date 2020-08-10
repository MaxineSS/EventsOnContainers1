using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WebClientMvc.Services
{
    public interface IIdentityService<T>
    {
        // get current user
        T Get(IPrincipal principal);
    }
}
