using System.IO;
using ClockApp.Events;

namespace ClockApp.Views
{
    public class LogClockToFile
    {
        public void Subscribe(Clock clock)
        {
            clock.clockTick += new Clock.clockTickHandler(WriteToFile);
        }

        public void WriteToFile(object clock, TimeInfoEventArgs timeInfo)
        {
            string outputString = "Time: " + timeInfo.hour + ":" + timeInfo.minute + ":" + timeInfo.second;
            using (FileStream stream = File.Open("C://text//LogFileStream.txt", FileMode.Append))
            {
                byte[] bytes = new System.Text.UTF8Encoding(true).GetBytes(outputString + "\n");
                stream.Write(bytes, 0, bytes.Length);
            }

            using (StreamWriter writer = new StreamWriter("C://text//LogStreamWriter.txt", true))
            {
                writer.WriteLine(outputString);
            }
        }
    }
}