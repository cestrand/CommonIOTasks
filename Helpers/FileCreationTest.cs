using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonIOTasks.Helpers;
public abstract class FileCreationTest
{
    public string Path
    {
        get; set;
    }

    public FileCreationTest(string path)
    {
        Path = path;
    }

    [ClassInitialize]
    public void EnsureFileNotExists()
    {
        var fileInfo = new FileInfo(Path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
    }

    [ClassCleanup]
    public void DeleteFile()
    {
        var fileInfo = new FileInfo(Path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
    }
}
