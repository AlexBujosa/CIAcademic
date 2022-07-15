namespace CIAcademicApp.BusinessLayer
{
    public class Validation
    {
        public bool ValidatePassword(string password)
        {
            if(password.Length < 8)
            {
                return false;
            }
            int cupper = 0, clower = 0, cnumber = 0;
            for(int i = 0; i<password.Length; i++)
            {
                if (char.IsLetter(password[i]) && char.IsLower(password[i]))
                    clower++;
                else if(char.IsLetter(password[i]) && char.IsUpper(password[i]))
                    cupper++;
                else if (char.IsDigit(password[i]))
                    cnumber++;
            }
            if(!(cupper > 1 && clower > 1 && cnumber > 1))
            {
                return false;
            }
            return true;
        }
        public bool ValidateEmailFirstPart(string fEmail)
        {
            if(!(fEmail.Length > 3))
            {
                return false;
            }
            int cletter = 0;
            for (int i = 0; i < fEmail.Length; i++)
            {
                if (char.IsLetter(fEmail[i]))
                    cletter++;
            }
            if (!(cletter > 3))
            {
                return false;
            }
            return true;
        }
        public bool ValidateId(int id)
        {
            if(id.ToString().Length != 7)
            {
                return false;
            }
            return true;
        }
        public bool ValidateEmail(string email)
        {
            string[] splitEmail;
            splitEmail = email.Split('@'); 
            if(splitEmail.Length != 2)
            {
                return false;
            }else  if((splitEmail[1] != "gmail.com" && splitEmail[1] != "hotmail.com" && splitEmail[1] != "outlook.com") || !ValidateEmailFirstPart(splitEmail[0]))
            {
                return false;
            }
            return true;
        }
        public bool ValidateNameOrLastName(string str)
        {
            string[] strings = str.Split(' ');
            if(strings.Length > 2)
            {
                return false;
            }
            if(strings.Length == 2)
            {
                if (!(strings[0].Length > 2 && char.IsUpper(strings[0][0])) || !(strings[1].Length > 2 && char.IsUpper(strings[1][0])))
                    return false;
            }
            for(int i = 0; i < strings.Length; i++)
            {
                for(int j =1; j < strings[i].Length; j++)
                {
                    if (char.IsUpper(strings[i][j]))
                        return false;
                }
                
            }
                
            if (!(str.Length >2 && char.IsUpper(str[0])))
                return false;
            return true;
        }
    }
}
