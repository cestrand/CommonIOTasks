using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonIOTasks.Helpers;
public abstract class WithTextFile
{
    public string Path
    {
        get; set;
    }

    public WithTextFile(string path)
    {
        Path = path;
    }

    [TestInitialize]
    public void CreateFile()
    {
        var fileInfo = new FileInfo(Path);
        if (!fileInfo.Exists)
        {
            var streamWriter = fileInfo.CreateText();
            streamWriter.Write(".");
            streamWriter.Close();
        }
    }

    [TestCleanup]
    public void DeleteFile()
    {
        var fileInfo = new FileInfo(Path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
    }
}
