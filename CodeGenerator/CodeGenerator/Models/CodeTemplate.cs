using CodeGenerator.Extensions;
using CodeGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeGenerator.Models
{
    public class CodeTemplate
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public List<ReplacementViewModel> FindReplacements()
        {
            var templateReplacements = Regex.Matches(Content, @"<<<<([\d\w\s]+)>>>>.*?");
            var replacements = new List<ReplacementViewModel>();
            foreach (Match m in templateReplacements)
            {
                var group = m.Groups[1];
                replacements.Add(new ReplacementViewModel { VarName = group.Value, VarValue = "" });
            }
            return replacements;
        }

        public List<ReplacementViewModel> FindAndFilterSimilarReplacements()
        {
            var replacements = FindReplacements().RemoveDuplicates();
            var similarities = new List<(ReplacementViewModel, ReplacementViewModel)>();
            for (int i = 0; i < replacements.Count; i++)
            {
                for (int j = 0; j < replacements.Count; j++)
                {
                    if (i == j) continue;
                    var s1 = replacements[i].VarName;
                    var s2 = replacements[j].VarName;
                    if (s1.IsMatchWithUnderscore(s2))
                    {
                        similarities.Add( (replacements[i], replacements[j]) );
                    }
                }
            }
            return null;
        }


        public string GenerateContent(IEnumerable<ReplacementViewModel> replacements)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Content);
            foreach (ReplacementViewModel replacement in replacements)
            {
                var orgPattern = @"<<<<" + replacement.VarName + ">>>>";
                sb.Replace(orgPattern, replacement.VarValue);
                var res = sb.ToString();
            }
            return sb.ToString();
        }


    }
}
