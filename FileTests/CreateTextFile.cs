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
        StreamWriter writer = File.CreateText(Path!);
        writer.WriteLine("Hello world!");
        writer.Close();
    }

    [TestMethod]
    public void TestParallel()
    {
        StreamWriter writer = File.CreateText(Path!);
        writer.WriteLine("Hello world!");
        writer.Close();
    }

}