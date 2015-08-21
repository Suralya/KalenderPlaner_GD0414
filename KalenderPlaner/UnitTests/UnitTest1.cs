using System;
using System.Collections.Generic;
using KalenderPlaner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Corecreations
    {

        public readonly List<Member> FinalTestMember = new List<Member>();
        public readonly List<Resource> FinalTestResources = new List<Resource>();
        public readonly List<DateTime> FinalTestUnavailableDateTimes = new List<DateTime>();

        public DateTime StartTime;
        public DateTime EndTime;

        public Corecreations(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            //TestMember
            //Resources
            Resource space10 = new Resource("Volumen10");
            Resource space50 = new Resource("Volumen50");
            Resource thomas = new Resource("Dozent: Thomas");
            Resource bhatty = new Resource("Dozent: Bhatty");
            Resource computer = new Resource("Hat Computer");

            FinalTestResources.Add(space10);
            FinalTestResources.Add(space50);
            FinalTestResources.Add(thomas);
            FinalTestResources.Add(bhatty);
            FinalTestResources.Add(computer);

            //Member
            FinalTestMember.Add(new Member("Raum01", new List<Resource> {space10}, new List<Resource>(),
                new List<DateTime>(), 10));
            FinalTestMember.Add(new Member("Raum02", new List<Resource> {space50}, new List<Resource>(),
                new List<DateTime>(), 8));
            FinalTestMember.Add(new Member("KursA", new List<Resource>(), new List<Resource> {space10, bhatty},
                new List<DateTime>()));
            FinalTestMember.Add(new Member("KursB", new List<Resource>(), new List<Resource> {space50, thomas, computer},
                new List<DateTime>()));
            FinalTestMember.Add(new Member("Bhatty", new List<Resource> {bhatty}, new List<Resource>(),
                new List<DateTime>()));
            FinalTestMember.Add(new Member("Thomas", new List<Resource> {thomas}, new List<Resource>(),
                new List<DateTime>()));



            //Set Data
            FinalTestMember[0].Dates.AddRange(new List<DateTime>
            {
                new DateTime(2015, 1, 1),
                new DateTime(2015, 1, 4),
                new DateTime(2015, 1, 8),
                new DateTime(2015, 1, 12),
                new DateTime(2015, 1, 16),
                new DateTime(2015, 1, 20),
                new DateTime(2015, 1, 24),
                new DateTime(2015, 1, 28),
                new DateTime(2015, 2, 2),
                new DateTime(2015, 2, 6)
            });

            FinalTestMember[1].Dates.AddRange(new List<DateTime>
            {
                new DateTime(2015, 1, 3),
                new DateTime(2015, 1, 6),
                new DateTime(2015, 1, 10),
                new DateTime(2015, 1, 14),
                new DateTime(2015, 1, 18),
                new DateTime(2015, 1, 22),
                new DateTime(2015, 1, 26),
                new DateTime(2015, 1, 30)
            });

            FinalTestMember[2].Dates.AddRange(new List<DateTime>
            {
                new DateTime(2015, 1, 1),
                new DateTime(2015, 1, 4),
                new DateTime(2015, 1, 8),
                new DateTime(2015, 1, 12),
                new DateTime(2015, 1, 16),
                new DateTime(2015, 1, 20),
                new DateTime(2015, 1, 24),
                new DateTime(2015, 1, 28),
                new DateTime(2015, 2, 2),
                new DateTime(2015, 2, 6)
            });

            FinalTestMember[3].Dates.AddRange(new List<DateTime>
            {
                new DateTime(2015, 1, 3),
                new DateTime(2015, 1, 6),
                new DateTime(2015, 1, 10),
                new DateTime(2015, 1, 14),
                new DateTime(2015, 1, 18),
                new DateTime(2015, 1, 22),
                new DateTime(2015, 1, 26),
                new DateTime(2015, 1, 30)
            });

            FinalTestMember[4].Dates.AddRange(new List<DateTime>
            {
                new DateTime(2015, 1, 1),
                new DateTime(2015, 1, 4),
                new DateTime(2015, 1, 8),
                new DateTime(2015, 1, 12),
                new DateTime(2015, 1, 16),
                new DateTime(2015, 1, 20),
                new DateTime(2015, 1, 24),
                new DateTime(2015, 1, 28),
                new DateTime(2015, 2, 2),
                new DateTime(2015, 2, 6)
            });

            FinalTestMember[5].Dates.AddRange(new List<DateTime>
            {
                new DateTime(2015, 1, 3),
                new DateTime(2015, 1, 6),
                new DateTime(2015, 1, 10),
                new DateTime(2015, 1, 14),
                new DateTime(2015, 1, 18),
                new DateTime(2015, 1, 22),
                new DateTime(2015, 1, 26),
                new DateTime(2015, 1, 30)
            });
            // --- END TEST MEMBER CREATION ---

            FinalTestUnavailableDateTimes.AddRange(new List<DateTime>
            {
                new DateTime(2015, 1, 4),
                new DateTime(2015, 1, 6),
                new DateTime(2015, 1, 11),
                new DateTime(2015, 1, 14),
                new DateTime(2015, 1, 18),
                new DateTime(2015, 1, 22),
                new DateTime(2015, 1, 24),
                new DateTime(2015, 1, 29),
                new DateTime(2015, 2, 4),
                new DateTime(2015, 2, 3)
            });
        }
    }

    [TestClass]
    public class StartAndEndtimeTests
    {
        [TestMethod]
        public void StartTimeGreaterThanEndTime()
        {
            Corecreations cc = new Corecreations(new DateTime(2015,06,01), new DateTime(2015,03,30));

        }
        [TestMethod]
        public void StartTimeZero()
        {

        }
        [TestMethod]
        public void EndTimeZero()
        {

        }
        [TestMethod]
        public void StartTimeEqualsEndTime()
        {

        }
    }
    [TestClass]
    public class RessourcesTests
    {
        [TestMethod]
        public void RessourceListEmpty()
        {
        }
    }
    [TestClass]
    public class UnavailableDatesTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
