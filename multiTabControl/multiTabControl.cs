﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace multiTabControl
{
    [ToolboxItem(true)]
    public  class multiTabControl : TabControl
    {
        public multiTabControl()
        {
            base.SetStyle(
             //ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制
             ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁
             ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁
             ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件
             ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明
             true);                                         // 设置以上值为 true
            base.UpdateStyles();

            
            base.SizeMode = TabSizeMode.Fixed;  // 大小模式为固定
            //this.ItemSize = new Size(44, 55);   // 设定每个标签的尺寸

            base.DrawMode = TabDrawMode.OwnerDrawFixed;
            base.Padding = new System.Drawing.Point(ICONSIZE, 5);
            //this.Appearance = TabAppearance.FlatButtons;
            base.ItemSize = new Size(100, 20);

            
        }
        private int TABPAGEHEIGHT = 20;
        private int ICONSIZE = 15;

        public int iconsize
        {
            get { return ICONSIZE; }
            set { ICONSIZE = value; }
        }
        private bool  isDrag=false;
        private int count = 0;


        protected override void  OnDrawItem(DrawItemEventArgs e)
        {
 	         base.OnDrawItem(e);
             try
            {
                Rectangle myTabRect = this.GetTabRect(e.Index);
                //填充矩形框
                Color bacColor = e.State == DrawItemState.Selected ? Color.White : Color.CornflowerBlue;
                using (Brush b = new SolidBrush(bacColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }


                if (e.Index == this.TabPages.Count - 1)
                {
                    Color newColor = Color.OliveDrab;
                    using (Brush b = new SolidBrush(newColor))
                    {
                        e.Graphics.FillRectangle(b, myTabRect);
                    }
                    e.Graphics.DrawString("New", this.Font, SystemBrushes.ControlText, myTabRect.X + iconsize + 2, myTabRect.Y + 5);
                    this.TabPages[e.Index].Size = new Size(50, 20);
                    return;
                }


                Rectangle iconRect = myTabRect;
                iconRect.Offset(0,2);
                iconRect.Width = iconsize;
                iconRect.Height = iconsize;
                //填充矩形框
                //Color iconColor = e.State == DrawItemState.Selected ? Color.White : Color.White;
                //using (Brush b = new SolidBrush(iconColor))
                //{
                //    e.Graphics.FillRectangle(b, iconRect);
                //}
                using (Pen p = new Pen(Color.Black))
                {
                    ////=============================================
                    //自己画X
                    ////"-"线
                    Point p1 = new Point(iconRect.X + 3, iconRect.Y + 3);
                    Point p2 = new Point(iconRect.X + iconRect.Width - 3, iconRect.Y +3);
                    e.Graphics.DrawLine(p, p1, p2);
                    
                    //"|"线
                    Point p3 = new Point(iconRect.X +3+(iconsize-6)/2, iconRect.Y + iconRect.Height);
                    Point p4 = new Point(iconRect.X +3+ (iconsize-6 ) / 2, iconRect.Y + 3);
                    e.Graphics.DrawLine(p, p3, p4);

                    ////=============================================
                    //使用图片
                    //Bitmap bt = new Bitmap(image);
                    //Point p5 = new Point(myTabRect.X, 4);
                    //e.Graphics.DrawImage(bt, p5);
                    //e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, objpen.Brush, p5);
                }


                
                //先添加TabPage属性   ,设置pagetext
                string pageText = this.TabPages[e.Index].Text;
                e.Graphics.DrawString(pageText, this.Font, SystemBrushes.ControlText, myTabRect.X +iconsize+ 2, myTabRect.Y + 5);              
                this.TabPages[e.Index].ToolTipText = pageText;
                //再画一个矩形框
                using (Pen p = new Pen(Color.White))
                {
                    myTabRect.Offset(myTabRect.Width - (ICONSIZE + 3), 2);
                    myTabRect.Width = ICONSIZE;
                    myTabRect.Height = ICONSIZE;
                   // e.Graphics.DrawRectangle(p, myTabRect);
                }
 
                //填充矩形框
                Color recColor = e.State == DrawItemState.Selected ? Color.White : Color.CornflowerBlue;
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }
 
                //画关闭符号
                using (Pen objpen = new Pen(Color.Black))
                {
                    ////=============================================
                    //自己画X
                    ////"\"线
                    Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    e.Graphics.DrawLine(objpen, p1, p2);
                    //"/"线
                    Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    e.Graphics.DrawLine(objpen, p3, p4);
 
                    ////=============================================
                    //使用图片
                    //Bitmap bt = new Bitmap(image);
                    //Point p5 = new Point(myTabRect.X, 4);
                    //e.Graphics.DrawImage(bt, p5);
                    //e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, objpen.Brush, p5);
                }
                e.Graphics.Dispose();
            }
            catch (Exception)
            { }
        }

        protected override void  OnMouseDown(MouseEventArgs e)
        {
 	         base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域   
                Rectangle myTabRect = this.GetTabRect(this.SelectedIndex);
 
                myTabRect.Offset(myTabRect.Width - (ICONSIZE + 3), 2);
                myTabRect.Width = ICONSIZE;
                myTabRect.Height = ICONSIZE;
 
                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
                if (isClose == true)
                {
                    TabPage t = this.SelectedTab;
                    this.TabPages.Remove(this.SelectedTab);
                    //需不需要垃圾箱来回收？
                    t.Dispose();
                }
                else
                { //拖动交换顺序
                isDrag = true;
                clickPoint = e.Location;
                }
            }



        }
        public  struct movePoint {
           public  int leftToClick;
           public  int topToClick;
        }
        private Point clickPoint = new Point();
        private movePoint mp = new movePoint();
        private TabControl moveTabControl=new TabControl();
        private TabPage moveTab;
        private bool isMoving = false;
        private bool canNew = true;
        protected override void OnMouseMove(MouseEventArgs e)
        {
           
            base.OnMouseMove(e);
            if (isDrag&&!isMoving)
            {
                //当鼠标移动5px方圆再确定移动
                if (e.Location.X - clickPoint.X > 10 || e.Location.Y - clickPoint.Y > 10 || e.Location.X - clickPoint.X <- 10 || e.Location.Y - clickPoint.Y <- 10)
                {
                    canNew = false;
                    isMoving = true;

                   
                    moveTab = new TabPage();
                    moveTab = base.SelectedTab;
                    mp.leftToClick = base.GetTabRect(base.SelectedIndex).Left - e.Location.X;
                    mp.topToClick = base.GetTabRect(base.SelectedIndex).Top - e.Location.Y;
                    base.SelectedIndex = base.SelectedIndex - 1;
                    base.TabPages.Remove(moveTab);

                    moveTabControl = new TabControl();
                    base.Parent.Controls.Add(moveTabControl);
                    moveTabControl.TabPages.Add(moveTab);
                    moveTabControl.Left = moveTab.Left;
                    moveTabControl.Top = moveTab.Top;
                    moveTabControl.BringToFront();
                }
            }
            if (isMoving)
            {
                moveTabControl.Left = e.Location.X + base.Left + mp.leftToClick;
                moveTabControl.Top = e.Location.Y + base.Top + mp.topToClick;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);


            if (isDrag && isMoving)
            {
                if (moveTabControl.Top < base.Top || moveTabControl.Top > base.Top + TABPAGEHEIGHT || moveTabControl.Left < base.Left || moveTabControl.Left > base.Left + base.Width)
                { //不在原有tabcontrol范围内，则新建TabControl，位置为当前位置,需要确定新建的Tabcontrol自定义可行否


                }
                else
                {
                    Rectangle r = new Rectangle();
                    int insertIndex = base.TabPages.Count - 1;
                    for (int i = 0; i < base.TabPages.Count; i++)
                    {
                        r = base.GetTabRect(i);

                        if (r.Left < moveTabControl.Left && r.Left + r.Width > moveTabControl.Left)
                        { //在某个选项卡的范围之内

                            insertIndex = i;
                            break;
                        }

                    }
                    if (insertIndex > base.TabPages.Count - 2) insertIndex -= 1;//如果是在newTab的位置，则调到前一个

                    moveTabControl.TabPages.Remove(moveTab);
                    base.Parent.Controls.Remove(moveTabControl);
                    base.TabPages.Add(moveTab);
                    TabPage temp = base.TabPages[insertIndex];
                    TabPage nextTab = new TabPage();
                    for (int i = insertIndex; i < base.TabPages.Count - 1; i++)
                    {

                        if (i == insertIndex) base.TabPages[i] = moveTab;
                        else
                        {
                            nextTab = base.TabPages[i];
                            base.TabPages[i] = temp;
                            temp = nextTab;
                        }

                    }
                    base.SelectedIndex = insertIndex;
                }
            }
            isDrag = false;
            isMoving = false;
            canNew = true;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (this.IsHandleCreated&&canNew)
            {
                if (this.SelectedIndex == this.TabPages.Count - 1)
                {
                    //MessageBox.Show(this.SelectedIndex.ToString()+"::::"+this.TabCount.ToString());
                    this.SelectedTab.Text = "newTab"+count++.ToString();
                    TabPage newTab = new TabPage();
                    newTab.Text = "New";
                    this.TabPages.Add(newTab);
                }
            }
        }
      
    }
}
