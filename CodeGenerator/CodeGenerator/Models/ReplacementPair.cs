using CodeGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Models
{
    public class ReplacementPair : IReplacement
    {
        
        private Replacement LowerCaseReplacement { get; set; }
        private Replacement UpperCaseReplacement { get; set; }

        public string VarName {
            get { return LowerCaseReplacement.VarName; }
            set {
                LowerCaseReplacement.VarName = value.DeCapitalize();
                UpperCaseReplacement.VarName = value.Capitalize();
            }
        }
        public string VarValue {
            get { return LowerCaseReplacement.VarValue; }
            set {
                LowerCaseReplacement.VarValue = value.DeCapitalize();
                UpperCaseReplacement.VarValue = value.Capitalize();
            }
        }



        public ReplacementPair(Replacement r1, Replacement r2)
        {
            if (r1.VarName.IsCapitalized())
            {
                LowerCaseReplacement = r1;
                UpperCaseReplacement = r2;
            }
            else if (r2.VarName.IsCapitalized())
            {
                LowerCaseReplacement = r2;
                UpperCaseReplacement = r1;
            }
            else
                throw new ArgumentException("ReplacementPair - replacement should have been filtered out.");
        }

        public StringBuilder ReplaceInString(StringBuilder sb)
        {
            LowerCaseReplacement.VarValue = LowerCaseReplacement.VarValue.DeCapitalize();
            UpperCaseReplacement.VarValue = UpperCaseReplacement.VarValue.Capitalize();
            sb = LowerCaseReplacement.ReplaceInString(sb);
            return UpperCaseReplacement.ReplaceInString(sb);
        }
        public bool ContainsNullOrEmpty()
        {
            return LowerCaseReplacement == null || UpperCaseReplacement == null || 
                LowerCaseReplacement.ContainsNullOrEmpty() || UpperCaseReplacement.ContainsNullOrEmpty();
        }
    }
}
