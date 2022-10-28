namespace CommonIOTasks
{
    [TestClass]
    public class CommonFileTasks
    {
        public StreamWriter CreateTextFile_File(string path)
        {
            StreamWriter streamWriter;
            try
            {
                streamWriter = File.CreateText(path);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"\nUnauthorizedAccessException: {ex}");
                throw;
            }
            // Somehow this is not being catched when using very long file name.
            // Instead System.IO.IOException is being thrown.
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"\nPathTooLongException {ex}");
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"\nDirectoryNotFoundException {ex}");
                throw;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"\nIOException: {ex}");
                throw;
            }
            return streamWriter;
        }

        [TestMethod]
        public void CreateTextFile_File()
        {
            StreamWriter streamWriter = CreateTextFile_File("file1.txt");
        }

        [TestMethod]
        public void CreateTextFile_File_DirectoryNotFoundException()
        {
            Assert.ThrowsException<DirectoryNotFoundException>(() =>
            {
                StreamWriter streamWriter = CreateTextFile_File("notexistingdir/file1.txt");
            });
        }

        [TestMethod]
        public void CreateTextFile_File_LongPath()
        {
            Assert.ThrowsException<IOException>(() =>
            {
                StreamWriter streamWriter = CreateTextFile_File("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.txt");
            });
        }
    }
}