using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Encryption //Easy
{
    public partial class MainWindow : Window
    {
        string fStr = "abcdefghijklmnopqrstuvwxyz",
               lStr = "zyxwvutsrqponmlkjihgfedcba";

        private void EasyEncrypt()
        {
            encryptedStr = "";
            for (int i = 0; i < source.Length; i++)
            {
                bool t = false;
                for (int j = 0; j < fStr.Length; j++)
                {
                    if (source[i]==fStr[j])
                    {
                        t = true;
                        encryptedStr += lStr[j];
                        break;
                    }
                }
                if (!t) encryptedStr += source[i];
            }
            EncryptField.Text = encryptedStr;
        }

        private void EasyDecrypt()
        {
            decryptedStr = "";
            for (int i = 0; i < encryptedStr.Length; i++)
            {
                bool t = false;
                for (int j = 0; j < lStr.Length; j++)
                {
                    if (encryptedStr[i] == lStr[j])
                    {
                        t = true;
                        decryptedStr += fStr[j];
                        break;
                    }
                }
                if (!t) decryptedStr += encryptedStr[i];
            }
            DecryptField.Text = decryptedStr;
        }
    }
}
