using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    public class MasterMindGameStep
    {
        [Key]
        public int Id { get; set; }
        public int CurrentGameIndex { get; set; }
        public string PlayerName { get; set; }
        public int StepNumber { get; set; }
        public string Value { get; set; }
        public string Score { get; set; }

    }
}
