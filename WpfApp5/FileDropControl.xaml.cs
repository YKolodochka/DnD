using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class FileDropControl : UserControl
    {
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileDropControl));

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public FileDropControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void FileDropControl_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }

            e.Handled = true;
        }
        private void FileDropControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }

            e.Handled = true;
        }

        private void FileDropControl_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    // Первый выбранный файл
                    string filePath = files[0];

                    // Устанавливаем свойство FileName
                    FileName = System.IO.Path.GetFileName(filePath);

                    // Выполняйте необходимые действия с файлом по требованию
                    // Например, обработка файла, загрузка и т.д.
                }
            }
        }
    }
}
