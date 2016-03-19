using System;
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
            //this.Appearance = TabAppearance.Buttons;
            base.ItemSize = new Size(100, 20);

            
        }
        private int ICONSIZE = 15;

        public int iconsize
        {
            get { return ICONSIZE; }
            set { ICONSIZE = value; }
        }
        private bool  isDrag=false;
        private Point tabMoveStart = new Point();

        //protected override void CreateHandle()
        //{
        //    base.OnCreateControl();
        //    TabPageCollection tc = base.TabPages;
        //    //this.TabPages.Clear();
        //    tc.Clear();
        //    TabPage tp = new TabPage("wosho ");
        //    tc.Add(tp);
        //}



     
        protected override void  OnDrawItem(DrawItemEventArgs e)
        {
 	         base.OnDrawItem(e);
             try
            {
                Rectangle myTabRect = this.GetTabRect(e.Index);



                if (e.Index == this.TabPages.Count - 1)
                {
                    e.Graphics.DrawString("New", this.Font, SystemBrushes.ControlText, myTabRect.X + iconsize + 2, myTabRect.Y + 5);
                    this.TabPages[e.Index].Size = new Size(50, 20);
                    return;
                }


                Rectangle iconRect = myTabRect;
                iconRect.Offset(0,2);
                iconRect.Width = iconsize;
                iconRect.Height = iconsize;
                //填充矩形框
                Color iconColor = e.State == DrawItemState.Selected ? Color.White : Color.White;
                using (Brush b = new SolidBrush(iconColor))
                {
                    e.Graphics.FillRectangle(b, iconRect);
                }
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
                    e.Graphics.DrawRectangle(p, myTabRect);
                }
 
                //填充矩形框
                Color recColor = e.State == DrawItemState.Selected ? Color.White : Color.White;
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
                    this.TabPages.Remove(this.SelectedTab);
                    //需不需要垃圾箱来回收？
                }
            }


            if (e.Button == MouseButtons.Left)
            {//拖动交换顺序
                isDrag = true;
                tabMoveStart = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDrag)
            {
                base.SelectedTab.Left += e.Location.X - tabMoveStart.X;
                base.SelectedTab.Top += e.Location.Y - tabMoveStart.Y;
            
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDrag = false;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (this.IsHandleCreated)
            {
                if (this.SelectedIndex == this.TabPages.Count - 1)
                {
                    this.SelectedTab.Text = "new tabPage";
                    TabPage newTab = new TabPage();
                    newTab.Text = "  New ";
                    this.TabPages.Add(newTab);
                }
            }
        }
      
    }
}
