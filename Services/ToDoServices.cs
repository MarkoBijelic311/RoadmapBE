using System.IO;
using System.Text.Json;

public class ToDoService
{
    private readonly string _filePath = "tasks.json";
    private List<ToDoTask> _tasks;

    public ToDoService()
    {
        _tasks = Load();
    }

    private List<ToDoTask> Load()
    {
        if (!File.Exists(Path.GetFullPath(_filePath)))
            return new List<ToDoTask>();

        var json = File.ReadAllText(Path.GetFullPath(_filePath));

        return string.IsNullOrWhiteSpace(json)
            ? new List<ToDoTask>()
            : JsonSerializer.Deserialize<List<ToDoTask>>(json) ?? new List<ToDoTask>();
    }

    private void Save()
    {
        File.WriteAllText(Path.GetFullPath(_filePath),
            JsonSerializer.Serialize(_tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
    }

    public void Add(string task)
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _tasks = string.IsNullOrWhiteSpace(json)
                ? new List<ToDoTask>()
                : JsonSerializer.Deserialize<List<ToDoTask>>(json) ?? new List<ToDoTask>();
        }
        else
        {
            _tasks = new List<ToDoTask>();
        }

        var newTask = new ToDoTask
        {
            Id = Guid.NewGuid(),
            Description = task,
            Status = ToDoStatus.ToDo,
            CreatedAt = DateTime.Now,
            UpdatedAt = null
        };

        _tasks.Add(newTask);
        Save();
    }

    public string GetAll()
    {
        return string.Join("\n", _tasks.Select(t =>
            $"{t.Description} - {t.Status}"
        ));
    }

    public void Remove(string taskDescription)
    {
        _tasks.RemoveAll(t => t.Description == taskDescription);
        Save();
    }

    public void Update(string oldTask, string newTask)
    {
        if (File.Exists(_filePath))
        {
            var index = _tasks.FindIndex(t => t.Description == oldTask);
            if (index != -1)
            {
                _tasks[index] = new ToDoTask
                {
                    Id = _tasks[index].Id,
                    Description = newTask,
                    Status = _tasks[index].Status,
                    CreatedAt = _tasks[index].CreatedAt,
                    UpdatedAt = DateTime.Now
                };
                Save();
            }
        }
    }

    public void MarkInProgress(string taskDescription)
    {
        if (File.Exists(_filePath))
        {
            var task = _tasks.FirstOrDefault(t => t.Description == taskDescription);
            if (task != null)
            {
                task.Status = ToDoStatus.Pending;
                task.UpdatedAt = DateTime.Now;
                Save();
            }
        }
    }

    public void MarkDone(string taskDescription)
    {
        if (File.Exists(_filePath))
        {
            var task = _tasks.FirstOrDefault(t => t.Description == taskDescription);
            if (task != null)
            {
                task.Status = ToDoStatus.Completed;
                task.UpdatedAt = DateTime.Now;
                Save();
            }
        }
    }

    public void MarkPending(string taskDescription)
    {
        if (File.Exists(_filePath))
        {
            var task = _tasks.FirstOrDefault(t => t.Description == taskDescription);
            if (task != null)
            {
                task.Status = ToDoStatus.Pending;
                task.UpdatedAt = DateTime.Now;
                Save();
            }
        }
    }
}