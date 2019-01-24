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

        public static CodeTemplate FromString(string text)
        {
            string[] parts = text.Split(new char[] { '\n' });
            string id = parts[0];
            string description = parts[1];

            var contentParts = parts.Skip(2);
            var sb = new StringBuilder();
            foreach (string part in contentParts)
            {
                sb.AppendLine(part);
            }
            string content = sb.ToString();

            return new CodeTemplate { Id = id, Description = description, Content = content };
        }

        public List<Replacement> FindReplacements()
        {
            var templateReplacements = Regex.Matches(Content, @"<<<<([\d\w\s]+)>>>>.*?");
            var replacements = new List<Replacement>();
            foreach (Match m in templateReplacements)
            {
                var group = m.Groups[1];
                replacements.Add(new Replacement { VarName = group.Value, VarValue = "" });
            }
            return replacements;
        }

        public List<Replacement> FindAndFilterSimilarReplacements()
        {
            var replacements = FindReplacements().UnorderedRemoveDuplicates();
            var similarities = new List<(Replacement, Replacement)>();
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


        public string GenerateContent(IEnumerable<Replacement> replacements)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Content);
            foreach (Replacement replacement in replacements)
            {
                if (replacement == null || replacement.ContainsNullOrEmpty())
                    continue;

                var orgPattern = @"<<<<" + replacement.VarName + ">>>>";
                sb.Replace(orgPattern, replacement.VarValue);
                var res = sb.ToString();
            }
            return sb.ToString();
        }


    }
}
