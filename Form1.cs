using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MouthXY
{

    public partial class MouseXY : Form
    {
        int mode = 1;
        bool isMouseState = false;
        int posRecordsX=0;
        int posRecordsY=0;
        public MouseXY()
        {

            InitializeComponent();

        }


        private void label1_Click(object sender, EventArgs e)
        {
            mode += 1;
            if (mode >= 4)
            {
                mode = 1;
            }
            if (mode == 1)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.TopMost = false;
                this.ShowInTaskbar = true;
            }
            if (mode == 2)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.TopMost = true;
                this.ShowInTaskbar = false;
            }
            if (mode == 3)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.TopMost = true;
                this.ShowInTaskbar = false;
            }



        }
        private void GetMousePoint1()
        {
            Point ms = Control.MousePosition;
            label1.Text = string.Format("当前鼠标位置：{0}:{1}", ms.X, ms.Y);
            MouseButtons mb = Control.MouseButtons;

            //  获取鼠标动作（按下了 那个按键)
            if (mb == System.Windows.Forms.MouseButtons.Left) this.label1.Text = "Left";
            if (mb == System.Windows.Forms.MouseButtons.Right) this.label1.Text = "Right";
            if (mb == System.Windows.Forms.MouseButtons.Middle) this.label1.Text = "Middle";

        }
        private void GetMousePoint2()
        {
            MouseButtons mb = Control.MouseButtons;
            Point ms = Control.MousePosition;
            //  获取鼠标动作（按下了 那个按键)
            if (mb == System.Windows.Forms.MouseButtons.Left&& isMouseState == false)
            {
                posRecordsX = ms.X;
                posRecordsY = ms.Y;
            }
            label1.Text = string.Format("位置差值：\n{0}:{1}", ms.X- posRecordsX,  ms.Y- posRecordsY);

            isMouseState = mb == System.Windows.Forms.MouseButtons.Left;



            }

            //更新鼠标位置等信息。
            private void timer1_Tick_1(object sender, EventArgs e)
            {
                if (mode == 3)
                {
                    GetMousePoint2();
                }
                else
                {
                    GetMousePoint1();
                }

            }

        }
    }
