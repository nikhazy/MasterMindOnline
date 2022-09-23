using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int CurrentGameIndex { get; set; }
        public int Score { get; set; }
        public Player()
        {

        }
    }
}
