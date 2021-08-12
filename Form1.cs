using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starfall_Screensaver_Win98_
{
    public partial class Form1 : Form
    {
        public class Star
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }

        public string PeredanSpeed;

        private float StarsSpeed;

        private Star[] stars = new Star[15000]; //количество звёзд

        private Random random = new Random();

        private Graphics graphics; //Для отрисовки 

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);

            foreach (var star in stars)
            {
                DrawStar(star);
                MoveStar(star);
            }

            pictureBox1.Refresh();
        }

        //Метод для передвижение звёзд
        private void MoveStar(Star star)
        {
            star.z -= StarsSpeed;

            if(star.z < 1)
            {
                //Сброс каординат
                star.x = random.Next(-pictureBox1.Width, pictureBox1.Width);
                star.y = random.Next(-pictureBox1.Height, pictureBox1.Height);
                star.z = random.Next(1, pictureBox1.Width); 
            }
        }

        //Метод для отрисовки звёзд
        private void DrawStar(Star star)
        {
            float sizeStar = Map(star.z, 0, pictureBox1.Width, 8, 0);

            float x = Map(star.x / star.z, 0, 1, 0, pictureBox1.Width) + pictureBox1.Width / 2;
                                                                                                    //Расчёт позиции звезды
            float y = Map(star.y / star.z, 0, 1, 0, pictureBox1.Height) + pictureBox1.Height / 2;
            //Рисовка звезды(Цвет, координаты)
            graphics.FillEllipse(Brushes.Blue, x, y, sizeStar, sizeStar);
        }

        //Для расчёта положения и смещения звезды 
        private float Map(float n, float start1, float stop1, float start2, float stop2)
        {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }

        //Метод выполняемый при загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            StarsSpeed = int.Parse(PeredanSpeed);

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(pictureBox1.Image);

            //Перебор массива с звёздами и к каждой звезде присаеваем координату 
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star()
                {
                    x = random.Next(-pictureBox1.Width, pictureBox1.Width),
                    y = random.Next(-pictureBox1.Height, pictureBox1.Height),
                    z = random.Next(1, pictureBox1.Width)
                };
            }

            timer1.Start(); //Запуск таймера
        }
    }
}
