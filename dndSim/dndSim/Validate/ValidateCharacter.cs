using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dndSim.Models.Heroes;
namespace dndSim.Validate
{
    public class ValidateCharacter
    {
        private const int LOWESTATTVALUE = 3;
        private const int HIGHESTATTVALUE = 20;
        private const int BARBHIGHVALUE = 24;

        public String validateAttributes(String error, int value)
        {
            String status = "";
            if (value > HIGHESTATTVALUE || value < LOWESTATTVALUE)
            {    
                status = error + " is not valid" + value;
            }
            return status;
        }

        public String validateAttributesBarabarian(String error, int value)
        {
            String status = "";
            if (value > BARBHIGHVALUE || value < LOWESTATTVALUE)
            {
                status = error + " is not valid" + value;
            }
            return status;
        }
    }
}