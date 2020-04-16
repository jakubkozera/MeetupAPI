using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetupAPI.Entities;

namespace MeetupAPI.Identity
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User user);
    }
}
