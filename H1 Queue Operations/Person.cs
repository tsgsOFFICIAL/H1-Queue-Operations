using System;
using System.Collections.Generic;
using System.Text;

namespace H1_Queue_Operations
{
    public class Person
    {
        #region Fields
        private byte age;
        private string name;
        System.Diagnostics.Stopwatch queueTime = new System.Diagnostics.Stopwatch();
        #endregion

        #region Properties
        public byte Age
        {
            get
            {
                return age;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string QueueTimeInMinutes
        {
            get
            {
                return $"{Math.Round(queueTime.Elapsed.TotalMinutes, 0, MidpointRounding.AwayFromZero)}";
            }
        }

        public string QueueTimeInSeconds
        {
            get
            {
                int seconds = (int)queueTime.Elapsed.TotalSeconds;
                for (int i = 0; i < (int)queueTime.Elapsed.TotalMinutes; i++)
                {
                    seconds -= 60;
                }
                return $"{seconds}";
            }
        }
        #endregion

        /// <summary>
        /// A person needs to have a name and an age
        /// </summary>
        /// <param name="name">The name of the person</param>
        /// <param name="age">The age of the person</param>
        public Person(string name, byte age)
        {
            queueTime.Start();
            this.name = name;
            this.age = age;
        }
    }
}
