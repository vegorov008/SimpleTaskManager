using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Models
{
    public interface IHasIdentity
    {
        Guid Id { get; set; }
    }
}
