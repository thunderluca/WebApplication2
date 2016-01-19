using System.Text.RegularExpressions;

namespace WebApplication2.WorkerServices
{
    public class GlobalWorkerServices
    {
        public static string GetContentTypeAsString(int value)
        {
            switch (value)
            {
                case 0:
                    {
                        return "News";
                    }
                case 1:
                    {
                        return "Article";
                    }
                case 2:
                    {
                        return "Tip";
                    }
                default:
                    {
                        return "Unknown";
                    }
            }
        }

        public static string UpperFirstCharOfString(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
                return string.Empty;

            if (inputString.Length == 1)
                return inputString.ToUpper();

            return inputString.Substring(0, 1).ToUpper() + inputString.Substring(1);
        }

        public static string UnescapeTitle(string inputTagTitle)
        {
            return Regex.Replace(inputTagTitle, @"^(?!(.*([\.]| ).*))", "-");
        }
    }
}
