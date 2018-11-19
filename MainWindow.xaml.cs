using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Encryption
{
    public partial class MainWindow : Window
    {
        string source, encryptedStr = "", decryptedStr = "", encryptVersion;
     
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Compare(object sender, RoutedEventArgs e)
        {
            if (decryptedStr == SourceField.Text) MessageBox.Show("Right");
            else MessageBox.Show("Wrong");
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            string name = button.Name;
            switch (name)
            {
                case "Field1": SourceField.Clear(); break;
                case "Field2": EncryptField.Text = ""; break;
                case "Field3": DecryptField.Text = ""; break;
            }
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            if (SourceField.Text == "")
            {
                MessageBox.Show("Please fill in the Source field");
                return;
            }
            source = SourceField.Text;
            switch (encryptVersion)
            {
                case "Transition": TransitionEncrypt(); break;
                case "Easy":EasyEncrypt(); break;
                case "RLE": RLECompress(); break;
                case null: MessageBox.Show("First choose version of encrypt"); break;
                default: MessageBox.Show("Not Ready yet");  break;
            }
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            if (encryptedStr == "")
            {
                MessageBox.Show("The operation is not available : encrypted text is exist");
                return;
            }
            switch (encryptVersion)
            {
                case "Transition": TransitionDecrypt(); break;
                case "Easy": EasyDecrypt(); break;
                case "RLE": RlEDecompress(); break;
                default: MessageBox.Show("Not Ready yet"); break;
            }
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            encryptVersion = button.Content.ToString();
            EncryptField.Text = "";
            DecryptField.Text = "";
            switch (encryptVersion)
            {
                case "Transition": AddKeyField(); break;
                case "RLE": ChangeButtons(); break;
                default: OtherFunc();  break;
            }
        }

        //Change WPF window
        private void OtherFunc()
        {
            KeyField.Visibility = Visibility.Hidden;
            button2.Content = "Encrypt";
            button3.Content = "Decrypt";
        }
        private void ChangeButtons()
        {
            KeyField.Visibility = Visibility.Hidden;
            button2.Content = "Compress";
            button3.Content = "Decompress"; 
        }
        private void AddKeyField()
        {
            KeyField.Visibility = Visibility.Visible;
            button2.Content = "Encrypt";
            button3.Content = "Decrypt";
        }
    }
}
