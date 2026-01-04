namespace MfiManager.Middleware.Security {
    public class DecryptionMapper {
        public static T DecryptDto<T>(T dto, EncryptionConfig config, IEncryptionService crypto) {
            foreach (var prop in typeof(T).GetProperties()) {
                if (config.IsEncrypted(typeof(T).Name, prop.Name)) {
                    var value = prop.GetValue(dto) as string;
                    if (!string.IsNullOrEmpty(value))
                        prop.SetValue(dto, crypto.Decrypt(value));
                }
            }
            return dto;
        }
    }

}
