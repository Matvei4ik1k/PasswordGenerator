using PasswordGenerator.AppData;
using System.Windows;

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GenerationService _generationService;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordsCountTb.Text == string.Empty ||
                PasswordLengthTb.Text == string.Empty ||
                LowerCaseCb.IsChecked == false &&
                NumbersCb.IsChecked == false &&
                SymbolsCb.IsChecked == false &&
                UpperCaseCb.IsChecked == false &&
                WordsCb.IsChecked == false)
            {
                MessageBox.Show("Выберите все поля", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _generationService = new GenerationService(NumbersCb.IsChecked.Value, SymbolsCb.IsChecked.Value, LowerCaseCb.IsChecked.Value, UpperCaseCb.IsChecked.Value, WordsCb.IsChecked.Value);

                int lenght = int.Parse(PasswordLengthTb.Text);
                int passwordsCount = int.Parse(PasswordsCountTb.Text);
                PasswordsLb.ItemsSource = _generationService.Start(lenght, passwordsCount);

                if (_generationService.count <= 2 && lenght <= 11) ReliabilityTb.Text = "Ненадёжный";
                else if (_generationService.count > 2 && _generationService.count <= 4 && lenght > 12 && lenght < 20) ReliabilityTb.Text = "Средний";
                else if (_generationService.count > 4 && lenght > 20) ReliabilityTb.Text = "Надёжный";
            }
        }

        private void PasswordsLb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (PasswordsLb.SelectedItem != null)
            {
                string selectedPassword = PasswordsLb.SelectedItem.ToString();
                Clipboard.SetText(selectedPassword);
                MessageBox.Show("Пароль скопирован в буфер обмена.", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void PasswordLengthTb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
