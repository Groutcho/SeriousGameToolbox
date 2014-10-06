namespace SeriousGameToolbox.Data.Logins
{
    public class Login
    {
        public string Id { get; private set; }

        public string Password { get; private set; }

        public Login(string id, string password)
        {
            this.Id = id;
            this.Password = password;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Login))
            {
                return false;
            }

            Login other = obj as Login;

            return (other.Id == Id && other.Password == Password);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Password.GetHashCode();
        }
    }
}