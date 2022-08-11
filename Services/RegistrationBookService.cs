using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetwork.Domain.Models;
using WaterNetwork.WPF.Services.Utils;

namespace WaterNetworkProject.Services
{
    public class RegistrationBookService
    {
        public PathHelper PathHelper { get; set; }
        public RegistrationsBook RegistrationBook { get; set; }

        public RegistrationBookService()
        {
            PathHelper = new PathHelper();
            RegistrationBook = new RegistrationsBook();
        }

        public Registration FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(",");
            Consumer consumer = new Consumer();

            int id = (int)Convert.ToInt64(values[0]);

            //ToDo: Add exception
            if (VerifyConsumer(id))
            {
                consumer.Id = id;
                consumer.FirstName = values[1];
                consumer.LastName = values[2];

                var counterLecture = (int)Convert.ToInt64(values[3]);
                var dateLecutre = Convert.ToDateTime(values[4]);

                return new Registration(consumer.Id, consumer.GetFullName(), counterLecture, dateLecutre);
            }
            return null;
        }

        public bool VerifyConsumer(int consumerId)
        {
            foreach (var consumer in RegistrationBook.Consumers)
            {
                if (consumer.Id == consumerId)
                    return true;
            }

            return false;
        }

        public Consumer GetConsumerById(int consumerId)
        {
            foreach (var consumer in RegistrationBook.Consumers)
            {
                if (consumer.Id == consumerId)
                    return consumer;
            }

            return null;
        }     

        public List<string> GetContent()
        {
            string headers = "Id,First Name,Last Name,Counter Lecture,Date Lecture";
            List<string> content = new List<string>();
            content.Add(headers);

            foreach (var registration in RegistrationBook.Registrations)
            {
                Consumer consumer = RegistrationBook.Consumers.FirstOrDefault(c => c.Id == registration.ConsumerId);

                content.Add(registration.ConsumerId + "," + consumer.FirstName + "," + consumer.LastName + "," + registration.CounterLecture + "," + registration.ConsumationDate.ToString());
            }
            return content;
        }

        public void SaveRegistrationsLocally()
        {
            if (File.Exists(PathHelper.RegistrationsFilePath))
                File.Delete(PathHelper.RegistrationsFilePath);

            List<string> content = GetContent();

            File.WriteAllLines(PathHelper.RegistrationsFilePath, content, Encoding.UTF8);
        }

    }
}
