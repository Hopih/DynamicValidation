using System;
using System.Collections;
using ControlWork1_Student2;

class Program
{
    static void Main(string[] args)
    {
        TaskItem item1 = new TaskItem();
        item1.Deadline = new DateTime();
        item1.Priority = 15;
        item1.Title = "Абоба";
        
        TaskItem item2 = new TaskItem();
        item2.Deadline = new DateTime();
        item2.Priority = 20;
        item2.Title = "Мэээ";
        
        TaskItem item3 = new TaskItem();
        item3.Deadline = new DateTime();
        item3.Priority = 30;
        item3.Title = "Амирчик";
        TaskItem item4 = new TaskItem();
        item4.Deadline = new DateTime();
        item4.Priority = 40;
        item4.Title = "ВВВ";
        
        TaskItem item5 = new TaskItem();
        item5.Deadline = new DateTime();
        item5.Priority = 50;
        item5.Title = "ы";
        
        List<TaskItem> items = new List<TaskItem>() { item1, item2, item3, item4, item5 };
        items.Sort(new TaskDeadlineComparer());
        foreach (TaskItem item in items)
        {
            Console.WriteLine(item.Title);
        }
    }
}