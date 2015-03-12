using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data
{
    /// <summary>
    /// Returns a file's content implicitly.
    /// </summary>
    public class FileObject
    {
        string content;

        public FileObject(string uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (!File.Exists(uri))
            {
                throw new FileNotFoundException("The file " + uri + " could not be found");
            }

            using (StreamReader r = new StreamReader(uri))
            {
                content = r.ReadToEnd();
            }
        }

        public static implicit operator string(FileObject fo)
        {
            return fo.content;
        }
    }
}
