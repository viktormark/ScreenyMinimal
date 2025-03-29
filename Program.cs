using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1;

namespace ScreenyMinimal
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                // Ваш код, який працює з файлами
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Файл не знайдено: {ex.FileName}\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}