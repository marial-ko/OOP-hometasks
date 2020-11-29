using System;
using System.Windows.Forms;
using System.Drawing;

namespace PhotoEnhancer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var chanel = 0.3 * pixel.R +
                                0.6 * pixel.G +
                                0.1 * pixel.B;

                    return new Pixel(chanel, chanel, chanel);
                }
                ));

            mainForm.AddFilter(new PixelFilter<ContrastParameters>(
                "Контраст",
                (pixel, parameters) =>
                {
                    var coefficient = (parameters as ContrastParameters).Coefficient;
                    return new Pixel(
                        GetContrasty(pixel.R, coefficient),
                        GetContrasty(pixel.G, coefficient),
                        GetContrasty(pixel.B, coefficient));

                     double GetContrasty(double channel, double coefficient1)
                    {
                        return Pixel.Trim(coefficient1 * (channel - 0.5) + 0.5);
                    }
                }
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° против ч. с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));


            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Свободное вращение", new RotateTransformer()));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 180°",
                size => size,
                (point, size) => new Point(size.Width-point.X-1, size.Height-1-point.Y)));
        
            mainForm.AddFilter(new TransformFilter<HorizontalTiltParameters>(
            "Скос по горизонтали", new HorizontalTiltTransformer()));

            Application.Run(mainForm);
        }
    }
}
