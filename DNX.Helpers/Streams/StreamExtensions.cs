using System.Collections.Generic;
using System.IO;

namespace DNX.Helpers.Streams
{
    /// <summary>
    /// Class StreamProcessor.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads the entire stream as text
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>System.String.</returns>
        public static string ReadAllText(this Stream stream)
        {
            if (stream == null)
            {
                return null;
            }

            using (var streamReader = new StreamReader(stream))
            {
                var text = streamReader.ReadToEnd();

                return text;
            }
        }

        /// <summary>
        /// Reads the entire stream as a list of lines
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="estimatedCapacity">The estimated capacity.</param>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public static IList<string> ReadAllLines(this Stream stream, int? estimatedCapacity = null)
        {
            if (stream == null)
            {
                return null;
            }

            var lines = estimatedCapacity.HasValue
                ? new List<string>(estimatedCapacity.Value)
                : new List<string>();

            using (var streamReader = new StreamReader(stream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                return lines;
            }
        }

        /// <summary>
        /// Reads the entire stream as a byte array
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ReadAllBytes(this Stream stream, int bufferSize = 4096)
        {
            if (stream == null)
            {
                return null;
            }

            var buffer = new byte[bufferSize];

            using (var memoryStream = new MemoryStream())
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);
                }

                return memoryStream.ToArray();
            }
        }
    }
}
