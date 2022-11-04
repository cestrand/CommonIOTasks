using System;
using CommonIOTasks.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonIOTasks.FileTests;

[TestClass]
public class CreateTextFile : EnsureFileNotExists
{
    public CreateTextFile() : base("file1.txt") { }
 

    [TestMethod]
    public void TestCreation()
    {
        Assert.IsFalse(File.Exists(Path!));

        StreamWriter writer = File.CreateText(Path!);
        writer.WriteLine("Hello world!");
        writer.Close();

        Assert.IsTrue(File.Exists(Path!));
    }

    [TestMethod]
    public void TestParallel()
    {
        Assert.IsFalse(File.Exists(Path!));

        StreamWriter writer = File.CreateText(Path!);
        writer.WriteLine("Hello world!");
        writer.Close();

        Assert.IsTrue(File.Exists(Path!));
    }

}