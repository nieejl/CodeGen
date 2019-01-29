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
            if (text == null || text == "")
                return null;
            string[] parts = text.Split(new char[] { '\n' });

            if (parts.Length < 3)
                return null;

            string id = parts[0];
            string description = parts[1];
            var contentParts = parts.Skip(2);

            var sb = new StringBuilder();
            foreach (string part in contentParts)
            {
                sb.AppendLine(part);
                sb.Append(Environment.NewLine);
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

        public List<IReplacement> FindAndFilterSimilarReplacements()
        {
            var replacements = FindReplacements().UnorderedRemoveDuplicates();
            var filteredReplacements = new List<IReplacement>();
            var added = new HashSet<int>();
            for (int i = 0; i < replacements.Count; i++)
            {
                for (int j = i+1; j < replacements.Count; j++)
                {
                    if (i == j) continue;
                    var s1 = replacements[i].VarName;
                    var s2 = replacements[j].VarName;
                    if (s1.ToLower() == s2.ToLower() && !added.Contains(i) && !added.Contains(j))
                    {
                        var pair = new CaseReplacementPair (replacements[i], replacements[j]);
                        filteredReplacements.Add(pair);
                        added.Add(i);
                        added.Add(j);
                    }
                }
                if (!added.Contains(i))
                {
                    filteredReplacements.Add(replacements[i]);
                }
            }
            return filteredReplacements;
        }


        public string GenerateContent(IEnumerable<IReplacement> replacements)
        {
            //var replacements = FindAndFilterSimilarReplacements();
            StringBuilder sb = new StringBuilder();
            sb.Append(Content);
            foreach (IReplacement replacement in replacements)
            {
                if (replacement == null || replacement.ContainsNullOrEmpty())
                    continue;
                sb = replacement.ReplaceInString(sb);
            }
            return sb.ToString();
        }


    }
}
