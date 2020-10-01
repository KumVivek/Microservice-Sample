using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Persistance.Api.ViewModels
{
    public class ResultModel
    {
        /// <summary>
        /// Time at which this save in file
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// Input number 1.
        /// </summary>
        public double Number1 { get; set; }
        /// <summary>
        /// Input number 2.
        /// </summary>
        public double Number2 { get; set; }
        /// <summary>
        /// Result of 2 numbers.
        /// </summary>
        public double Result { get; set; }
    }
}
