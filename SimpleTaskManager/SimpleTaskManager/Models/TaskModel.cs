using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Models
{
    public enum TaskStatus : byte
    {
        Open = 0,
        InProgress = 1,
        Done = 2
    }

    public class TaskModel : IHasIdentity, ICloneable
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        public TaskStatus Status { get; set; }

        public object Clone()
        {
            return new TaskModel()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Status = Status,
                CreationDate = CreationDate
            };
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
