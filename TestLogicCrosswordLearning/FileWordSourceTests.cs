using LogicCrosswordLearning;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LogicCrosswordLearningData.Tests
{
    [TestClass()]
    public class FileWordSourceTests
    {
        [TestMethod()]
        public void FileWordSourceTest()
        {
            string filename = @"C:\_users\ama\LearningCrossword\code\testdata\testwords.txt";
            //string filename = @"D:\Projects\GitHub\CrosswordLearning\ResourceFile\testwords.txt";
            var fileWordSource = new FileWordSource(filename);

            Assert.IsNotNull(value: fileWordSource);
        }

        [TestMethod()]
        public void GetWordsTest()
        {
            string filename = @"C:\_users\ama\LearningCrossword\code\testdata\testwords.txt";
            //string filename = @"D:\Projects\GitHub\CrosswordLearning\ResourceFile\testwords.txt";
            var fileWordSource = new FileWordSource(filename);
            var words = fileWordSource.GetWords(1);
            
            Assert.AreEqual(words.Count(), 1);
        }
    }
}