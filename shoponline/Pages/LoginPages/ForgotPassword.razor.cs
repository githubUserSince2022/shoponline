using System.Text.RegularExpressions;

namespace shoponline.Pages.LoginPages
{
    public partial class ForgotPassword
    {
        public static string Email { get; set; }
        public string Fehlermeldung { get; set; }
        public string colorFehlermeldung { get; set; }
        public static string newPassword { get; set; }
        private Regex hasNumber = new Regex(@"[0-9]+");
        private Regex hasUpperChar = new Regex(@"[A-Z]+");
        private Regex hasLowerChar = new Regex(@"[a-z]+");
        private Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        public void validateForm()
        {
            if (localStorage.ContainKey(Email))
            {
                Fehlermeldung = "";
                newPassword = generateNewPassword();
                colorFehlermeldung = "white";
                localStorage.SetItem(Email + "", newPassword);
            }
            else
            {
                Fehlermeldung = "Diese Email-Adresse existiert nicht! Bitte nochmal eine andere eingeben!";
                colorFehlermeldung = "red";
            }
        }
        public string generateNewPassword()
        {
            char[] Chars = new char[] {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','!','"','§','%','&','/','(',')','=','?','´','+','*','#','!'
            };
            string String = string.Empty;
            while (!checkPasswordFormat())
            {
                Random Random = new Random();
                String = "";

                for (byte a = 0; a < 12; a++)
                {
                    String += Chars[Random.Next(0, 76)];
                };
                newPassword = String;
            }

            return newPassword;
        }
        public bool checkPasswordFormat()
        {
            Console.WriteLine(newPassword);
            if (string.IsNullOrEmpty(newPassword))
            {
                return false;
            }
            if (!hasLowerChar.IsMatch(newPassword) || !hasUpperChar.IsMatch(newPassword) || !hasNumber.IsMatch(newPassword) || !hasSymbols.IsMatch(newPassword))
            {
                return false;
            }
            return true;
        }
    }
}
