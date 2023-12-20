﻿using Grpc.Core;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace Server.Services
{
    public class LoginService : LoginHandler.LoginHandlerBase
    {
        public const int keySize = 64;
        public const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public override Task<Access> Login(Credentials request, ServerCallContext context) {

            string password;
            string salt;

            using (SQLiteConnection conn = new("Data Source= mazeData.db; Version = 3; New = True; Compress = True; ")) {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand()) {
                    cmd.CommandText = $"SELECT Password, Salt FROM Login WHERE Username = '{request.Username}'";
                    using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            password = reader.GetString(0);
                            salt = reader.GetString(1);
                        }
                        else {
                            return Task.FromResult(new Access { LoggedIn = false });
                        }
                    }
                }
            }

            return Task.FromResult(new Access { LoggedIn = VerifyPassword(request.Password, password, Convert.FromHexString(salt)) });
        }

        // SOURCE: https://code-maze.com/csharp-hashing-salting-passwords-best-practices/
        bool VerifyPassword(string password, string hash, byte[] salt) {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
