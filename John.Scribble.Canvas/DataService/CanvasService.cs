// -----------------------------------------------------------------------
// <copyright file="CanvasService.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Canvas.DataService
{
    using System.IO;
    using System.Xml.Serialization;
    using John.Scribble.Canvas.Model;

    /// <summary>
    /// CanvasService class
    /// </summary>
    public class CanvasService
    {
        /// <summary>
        /// Method to read and deserialize the data
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>canvas model</returns>
        public CanvasModel Read(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CanvasModel));
            StreamReader reader = new StreamReader(fs);
            CanvasModel canvasModel = (CanvasModel)serializer.Deserialize(reader);
            fs.Close();

            return canvasModel;
        }

        /// <summary>
        /// Method to write the serialized data in the given location
        /// </summary>
        /// <param name="fileName">file Name</param>
        /// <param name="canvasModel">canvas model</param>
        public void Write(string fileName, CanvasModel canvasModel)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(canvasModel.GetType());
            StreamWriter writer = new StreamWriter(fs);
            serializer.Serialize(writer, canvasModel);
            fs.Close();
        }
    }
}
