using System.Net.Mail;

namespace shoponline.Pages.LoginPages
{
    public partial class Login
    {
        public string email { get; set; }
        public string password { get; set; }
        public string fehlermeldung;
        public string colorFehlermeldung = "white";
        public string fileName;
        public List<Login> users = new();
        public Login[]? loginArray;
        List<List<string>> loginData = new();

        public void validateForm()
        {
            checkEmail();
            email = "";
            password = "";
        }
        public override string ToString()
        {
            return "Email: " + email + " Password: " + password;
        }
        public bool checkEmail()
        {
            try
            {
                if (email.Length == 0)
                {
                    throw new Exception("asdasda");
                }
                MailAddress mail = new MailAddress(email);
                fehlermeldung = "";
                colorFehlermeldung = "white";
                laden(email, password);
                return true;
            }
            catch (Exception e)
            {
                if (email.Length == 0)
                {
                    fehlermeldung = e.ToString();
                }
                else
                {
                    fehlermeldung = e.ToString().Substring(23, 75);
                }
                fehlermeldung += " Try again!!";
                colorFehlermeldung = "red";
                return false;
            }
        }

        private void laden(string e, string pw)
        {
            try
            {
                Login user = new Login
                {
                    email = e,
                    password = "pw"
                };
                if (checkCorrectEmailPassword(e, loginData, pw))
                {
                    fehlermeldung = "Login sucessfull";
                    colorFehlermeldung = "green";
                    hash();
                }
                else
                {
                    if (!checkCorrectEmailPassword(e, loginData, pw))
                    {
                        fehlermeldung = "Kombination aus Password und Email ist falsch!!";
                        colorFehlermeldung = "red";
                    }
                    if (!localStorage.ContainKey(email))
                    {
                        fehlermeldung = "Email existiert nicht! Sie müssen erst einmal registrieren!";
                        colorFehlermeldung = "red";
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
        }
        private bool checkCorrectEmailPassword(string email, List<List<string>> lst, string password)
        {
            lst.Clear();
            int j = 0;
            while (localStorage.Key(j) != null)
            {
                var key = localStorage.Key(j);
                getLocalStorageElements(localStorage.Key(j), localStorage.GetItem<string>(key));
                j++;
            }

            for (int i = 0; i < lst.Count; i++)
            {
                if (email == lst[i][0] && password == lst[i][1])
                {
                    return true;
                }
            }
            return false;
        }
        public void getLocalStorageElements(string e, string pw)
        {
            List<string> item = new();
            item.Add(e);
            item.Add(pw);
            loginData.Add(item);
        }
        public void hash()
        {
            /*byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            Console.WriteLine(savedPasswordHash);*/

        }
    }
}
