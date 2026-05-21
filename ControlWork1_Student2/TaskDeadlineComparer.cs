namespace ControlWork1_Student2;

public class TaskDeadlineComparer : IComparer<TaskItem>
{
    public int Compare(TaskItem x, TaskItem y)
    {
        if (x.Deadline.CompareTo(y.Deadline) == 0)
        {
            if (x.Priority.CompareTo(y.Priority) == 0)
            {
                return x.Title.CompareTo(y.Title);
            }
            else
            {
                return x.Priority.CompareTo(y.Priority)*-1;
            }
        }
        else
        {
            return x.Deadline.CompareTo(y.Deadline);
        }
    }
}