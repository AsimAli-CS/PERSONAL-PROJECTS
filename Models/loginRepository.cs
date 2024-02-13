namespace ProjectStudentSystem.Models
{
    public class loginRepository
    {
        public string CheckLogIn(User s)
        {

            UserContext sx = new UserContext();

            var user1 = sx.Users.ToList();
            foreach (var s1 in user1)
            {
                if (s1.Username.TrimEnd() == s.Username.TrimEnd() && s1.Password.TrimEnd() == s.Password.TrimEnd())
                {
                    string username = s1.Username;
                    return username;
                }

            }
            return null;
        }


    }
}
