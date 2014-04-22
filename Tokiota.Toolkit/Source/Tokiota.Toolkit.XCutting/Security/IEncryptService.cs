namespace Tokiota.Toolkit.XCutting.Security
{
    public interface IEncryptService
    {
        #region Public Methods and Operators

        string Decrypt(string encryptedText);

        string Encrypt(string plainText);

        #endregion
    }
}