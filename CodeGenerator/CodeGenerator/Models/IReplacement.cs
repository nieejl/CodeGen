using System.Text;

namespace CodeGenerator.Models
{
    public interface IReplacement
    {
        StringBuilder ReplaceInString(StringBuilder sb);
    }
}