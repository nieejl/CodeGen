using System.Text;

namespace CodeGenerator.Models
{
    public interface IReplacement
    {
        string VarName { get; set; }
        string VarValue { get; set; }
        StringBuilder ReplaceInString(StringBuilder sb);
        bool ContainsNullOrEmpty();
    }
}