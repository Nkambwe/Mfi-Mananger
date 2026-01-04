namespace MfiManager.Middleware.Security {

    public interface IEncryptionService {
        string Encrypt(string value);
        string Decrypt(string value);
    }


}
