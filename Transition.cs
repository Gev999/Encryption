using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Encryption //Transition
{
    public partial class MainWindow : Window
    {
        int key;
        private void TransitionEncrypt()
        {
            if (Key.Text == "")
            {
                MessageBox.Show("Please enter key");
                return;
            }
            encryptedStr = "";
            key = int.Parse(Key.Text);
            for (int i = 0; i < key; i++)
            {
                for (int j = i; j < source.Length; j += key)
                {
                    encryptedStr += source[j];
                }
            }
            EncryptField.Text = encryptedStr;
        }

        private void TransitionDecrypt()
        {
            if (Key.Text == "")
            {
                MessageBox.Show("Please enter key");
                return;
            }
            decryptedStr = "";
            key = int.Parse(Key.Text);
            int limit = encryptedStr.Length % key;
            int step = limit == 0 ?
                encryptedStr.Length / key :
                encryptedStr.Length / key + 1;
            for (int i = 0; i < step; i++)
            {
                int count = 0;
                for (int j = i; j < encryptedStr.Length; j += step)
                {
                    if (i == step - 1 && count == limit && limit != 0) break;
                    count++;
                    decryptedStr += encryptedStr[j];
                    if (count > limit && limit != 0) j--;
                }
            }
            DecryptField.Text = decryptedStr;
        }
    }
}
