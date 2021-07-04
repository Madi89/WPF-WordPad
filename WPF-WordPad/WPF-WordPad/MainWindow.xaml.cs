using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;


namespace WPF_WordPad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Do you want to open a new document?", "New", MessageBoxButton.YesNo, MessageBoxImage.Question);
            txtEditor.Clear();
        }

        private void CommandOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Load a new Document?", "Load", MessageBoxButton.YesNo, MessageBoxImage.Question);
            OpenFileDialog openFile = new();
            openFile.Filter = "TextFiles (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFile.FileName);
        }

        private void CommandSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Do you want to save your document?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question);
            SaveFileDialog saveFile = new();
            if (saveFile.ShowDialog() == true)
                File.WriteAllText(saveFile.FileName, txtEditor.Text);
        }

        private void CommandPrint_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Do you want to open a new document?", "New Document", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void CommandExit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            MessageBox.Show("Do you want to exit the program?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            Application.Current.Shutdown();
            
        }

        private void CommandUndo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Undo();
        }

        private void CommandRedo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Redo();
        }

        private void CommandCut_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Cut();
        }

        private void CommandCopy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Copy();
        }

        private void CommandPaste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Paste();
        }
    }
}
