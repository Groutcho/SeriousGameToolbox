namespace SeriousGameToolbox.Data.Logins
{
    public class Login
    {
        public string Id { get; private set; }

        public string Password { get; private set; }

        public Login(string id, string password)
        {
            Guards.Guard.AgainstNullArgument("id", id);
            Guards.Guard.AgainstNullArgument("password", password);

            if (id.Trim() == string.Empty)
            {
                throw new System.ArgumentException("id cannot be empty");
            }
            if (password.Trim() == string.Empty)
            {
                throw new System.ArgumentException("password cannot be empty");
            }

            this.Id = id.Trim();
            this.Password = password.Trim();
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