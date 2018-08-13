using ConferenceSchedule.Interface;
using ConferenceSchedule.Interface.Implement;
using ConferenceSchedule.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConferenceSchedule
{
    internal static class Program
    {
        private static readonly IConferenceConverter _conferenceConverter;
        private static readonly IScheduleService _scheduleService;

        static Program()
        {
            _conferenceConverter = new ConferenceConverter();
            _scheduleService = new ScheduleService();
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("TestDataPath is empty!");
                return;
            }
            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                Console.WriteLine("TestDataFile does not exist!");
            }

            var textLines = File.ReadLines(filePath);
            var conferences = new List<Conference>();

            foreach (var line in textLines)
            {
                conferences.Add(_conferenceConverter.Convert(line));
            }

            foreach (var session in _scheduleService.Schedule(conferences))
            {
                Console.WriteLine(session);
            }

        }
    }
}
