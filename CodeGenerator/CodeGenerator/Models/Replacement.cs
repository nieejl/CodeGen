using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Models
{
    public class Replacement : IReplacement
    {
        public string VarName { get; set; }
        public string VarValue { get; set; }

        public bool ContainsNullOrEmpty()
        {
            return (VarName == null || VarName == "")
                || (VarValue == null || VarValue == "");
        }

        public virtual StringBuilder ReplaceInString(StringBuilder sb)
        {
            string patternOne = @"<<<<" + VarName + ">>>>";
            return sb.Replace(patternOne, VarValue);
        }

        public override bool Equals(object obj)
        {
            if ((obj is Replacement replacement))
                if (VarName == replacement.VarName && VarValue == replacement.VarValue)
                    return true;
            return false;
        }

        public override int GetHashCode()
        {
            return VarName.GetHashCode() ^ VarValue.GetHashCode();
        }
    }
}
