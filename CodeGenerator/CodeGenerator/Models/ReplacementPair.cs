using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Models
{
    public class ReplacementPair : IReplacement
    {
        Replacement rep1 { get; set; }
        Replacement rep2 { get; set; }

        public StringBuilder ReplaceInString(StringBuilder sb)
        {
            sb = rep1.ReplaceInString(sb);
            return rep2.ReplaceInString(sb);
        }
    }
}
