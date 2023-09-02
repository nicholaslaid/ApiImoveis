namespace ApiImoveis.Global
{
    public class Security
    {
        public bool ValidateToken(string token)
        {
            bool result = true;

            if (string.IsNullOrEmpty(token))
            {
                result = false;


            }
            else if (token != Config.automaticToken)
            {
                result = false;
            }


            return result;
        }

        public string GenerateToken(string key)
        {
            string result = string.Empty;

            if (key == "admin")
            {
                Guid guid = Guid.NewGuid();
                result = guid.ToString();
                Config.automaticToken = result;
            }

            return result;
        }
    }
}
