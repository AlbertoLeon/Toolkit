namespace Tokiota.Toolkit.XCutting.Security
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEncryptService
    {
        #region Public Methods and Operators

        /// <summary>
        /// Decrypts the specified encrypted text.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <returns></returns>
        string Decrypt(string encryptedText);

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns></returns>
        string Encrypt(string plainText);

        #endregion
    }
}