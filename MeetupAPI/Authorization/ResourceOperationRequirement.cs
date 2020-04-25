using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MeetupAPI.Authorization
{
    public enum OperationType
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperationRequirement(OperationType operationType)
        {
            OperationType = operationType;
        }
        public OperationType OperationType { get; }
    }
}
