using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterNetworkProject.Services;

namespace WaterNetworkProject.Models
{
    public class RegistrationsBook
    {
        public PathHelper PathHelper { get; set; }
        public List<Registration> Registrations;
       public List<Consumer> Consumers;


        public RegistrationsBook()
        {
            Registrations = new List<Registration>();
            Consumers = new List<Consumer>();
            PathHelper = new PathHelper();
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

                return new Registration(consumer, counterLecture, dateLecutre);
            }
            return null;
        }

        public bool VerifyConsumer(int consumerId)
        {
            foreach (var consumer in Consumers)
            {
                if (consumer.Id == consumerId)
                    return true;
            }

            return false;
        }

        public Consumer GetConsumerById(int consumerId)
        {
            foreach (var consumer in Consumers)
            {
                if (consumer.Id == consumerId)
                    return consumer;
            }

            return null;
        }

        public List<Registration> GetAllRegistrations()
        {
            return Registrations;
        }

        public void AddConsumer(Consumer consumer)
        {
            Consumers.Add(consumer);
        }

        public void MakeRegestration(Registration registration)
        {
            foreach (var _registration in Registrations)
            {
                if (registration.Consumer.Id == _registration.Consumer.Id &&
                    registration.ConsumationDate.Month == _registration.ConsumationDate.Month)
                {
                    _registration.CounterLecture = registration.CounterLecture;
                    _registration.ConsumationDate = registration.ConsumationDate;
                    return;
                }
            }
            Registrations.Add(registration);
        }

        public void SaveRegistrationsLocally()
        {
            string headers = "Id,First Name,Last Name,Counter Lecture,Date Lecture";

            if (File.Exists(PathHelper.RegistrationsFilePath))
                File.Delete(PathHelper.RegistrationsFilePath);

            List<string> content = new List<string>();

            content.Add(headers);

            //ToDo: correct append and encoding
            foreach (var registration in Registrations)
            {
                content.Add(registration.toCsv());
            }

            File.WriteAllLines(PathHelper.RegistrationsFilePath,content,Encoding.UTF8);
        }
    }
}
