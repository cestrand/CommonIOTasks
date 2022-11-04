using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonIOTasks.Helpers;

namespace CommonIOTasks.FileTests;

[TestClass]
public class DeleteTextFile : WithTextFile
{
    public DeleteTextFile() : base("todelete.txt") {}

    [TestMethod]
    public void TestDelete()
    {
        Assert.IsTrue(File.Exists(Path!));

        File.Delete(Path!);

        Assert.IsFalse(File.Exists(Path!));
    }

    [TestMethod]
    public void TestDeleteParallel()
    {
        Assert.IsTrue(File.Exists(Path!));

        File.Delete(Path!);

        Assert.IsFalse(File.Exists(Path!));
    }
}
