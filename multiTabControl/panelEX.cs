using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ControlEX
{
    public  class panelEX : Panel
    {
        public panelEX()
        {
           
        }


        public static float MOUSE_WHEEL_UP = 1.02f;
        public static float MOUSE_WHEEL_DOWN = 0.98f;
        private bool isDown = false;
       
        private Point downPoint = new Point();
        private int leftMove;
        private int topMove;
        private List<Point> controlStartPoint = new List<Point>();
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (base.Focus())
            {                
                float Mo = 0;

                if (e.Delta > 0)
                {
                    Mo = MOUSE_WHEEL_UP;


                }
                else if (e.Delta < 0)
                {
                    Mo = MOUSE_WHEEL_DOWN;
                }
                #region 移动控件
                foreach (Control ct in base.Controls)
                {//看成是点的移动
                    ////控制最小量
                    //if (ct.Width < MIN_GRP_WIDTH | ct.Height < MIN_GRP_HEIGHT)
                    //{
                    //    if (Mo < 1)
                    //        return;
                    //}

                    ct.Width += (int)((Mo - 1) * (float)ct.Width);
                    ct.Height += (int)((Mo - 1) * (float)ct.Height);
                    ct.Left += (int)((float)(ct.Left - e.X) * (Mo - 1));
                    ct.Top += (int)((float)(ct.Top - e.Y) * (Mo - 1));

                  

                }

                #endregion
              
            }


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            isDown = true;
            downPoint = e.Location;
            controlStartPoint.Clear();
            for (int i = 0; i < base.Controls.Count; i++)
			{
			    controlStartPoint.Add(base.Controls[i].Location);
			}
                
           
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDown)
            {
                leftMove = e.X - downPoint.X;
                topMove = e.Y - downPoint.Y;
                for (int i = 0; i < base.Controls.Count; i++)
			    {
                    base.Controls[i].Left = controlStartPoint[i].X + leftMove;
                    base.Controls[i].Top = controlStartPoint[i].Y + topMove;
			    }
                   
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDown = false;
            
        }
    }
}
