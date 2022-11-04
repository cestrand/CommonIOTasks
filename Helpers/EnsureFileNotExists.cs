using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonIOTasks.Helpers;
public abstract class EnsureFileNotExists
{
    public string Path
    {
        get; set;
    }

    public EnsureFileNotExists(string path)
    {
        Path = path;
    }

    [ClassInitialize]
    public void Initialize()
    {
        var fileInfo = new FileInfo(Path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
    }

    [ClassCleanup]
    public void Cleanup()
    {
        var fileInfo = new FileInfo(Path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
    }
}
