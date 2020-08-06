using System.IO;
using System.IO.Compression;

namespace ZipUtility
{
    /// <summary>
    /// Class to  Zip and UnZip files
    /// </summary>
    public class ZipUtility
    {
        /// <summary>
        /// This is the directory location of the file to unzip
        /// </summary>
        private string Location { get; }

        /// <summary>
        /// This is the filename to unzip
        /// </summary>
        private string Filename { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipUtility"/> class.
        /// This is a manager to Unzip files.
        /// </summary>
        /// <param name="filename"> This is the filename to unzip.
        /// This filename can include the location, if you only specify the filename will assume the current directory.
        /// </param>
        public ZipUtility(string filename)
        {
            var directoryName = Path.GetDirectoryName(filename);
            Location = directoryName == string.Empty ? Directory.GetCurrentDirectory() : directoryName;
            Filename = Path.GetFileName(filename);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipUtility"/> class.
        /// This is a manager to Unzip files.
        /// </summary>
        /// <param name="location">This is the directory location of the file to unzip</param>
        /// <param name="filename">This is the filename to unzip</param>
        public ZipUtility(string location, string filename)
        {
            Location = location;
            Filename = filename;
        }

        /// <summary>
        /// This will unzip the file to the given location
        /// </summary>
        /// <param name="destination">This is the fileName you wish to send the unzipped file to</param>
        public void Unzip(string destination)
        {
            var zipFile = Path.Combine(Location, Filename);
            ZipFile.ExtractToDirectory(zipFile, destination);
        }

        /// <summary>
        /// Create a zip file from a directory
        /// </summary>
        /// <param name="fileName">name of the zip file to be created</param>
        public void CreateZipFile(string fileName)
        {
            var zipFile = Path.Combine(Location, Filename);
            ZipFile.CreateFromDirectory(zipFile, fileName);
        }

        /// <summary>
        /// Create a zip file from a directory
        /// </summary>
        /// <param name="filePath">path for the file directory to be updated</param>
        /// <param name="zipPath">path for the zip directory to be updated</param>
        public void CreateZipFile(string filePath, string zipPath)
        {
            ZipFile.CreateFromDirectory(filePath, zipPath, CompressionLevel.Optimal, true);
        }

        /// <summary>
        /// Method to add an existing file to a zip directory
        /// </summary>
        /// <param name="zipPath">path for the zip directory to be updated</param>
        /// <param name="fileToAdd">file that is to be added to the zip directory</param>
        /// <param name="fileName">file name of the file to be added to the zip directory</param>
        public void AddFileToZip(string zipPath, string fileToAdd, string fileName)
        {
            using var modifyFile = ZipFile.Open(zipPath, ZipArchiveMode.Update);
            modifyFile.CreateEntryFromFile(fileToAdd, fileName);
        }
    }
}