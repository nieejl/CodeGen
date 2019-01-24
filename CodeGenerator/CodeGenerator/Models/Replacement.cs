using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Models
{
    public class Replacement
    {
        public string VarName { get; set; }
        public string VarValue { get; set; }

        public bool ContainsNullOrEmpty()
        {
            return (VarName == null || VarName == "")
                || (VarValue == null || VarValue == "");
        }
    }
}
