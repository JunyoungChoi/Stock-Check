using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace JY.Util
{
    class Utils
    {
        public static void DataGridView_MouseUp_ContextMenu(object sender, MouseEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dataGridView.HitTest(e.X, e.Y);

                if (info.Type == DataGridViewHitTestType.Cell)
                {
                    ContextMenu mnu = new ContextMenu();
                    //mnu.MenuItems.Add(new MenuItem("Copy selected", dataGridView_Copy));
                    mnu.MenuItems.Add(new MenuItem("Copy selected", (EventHandler)delegate 
                    {
                        dataGridView_Copy(sender, e);
                    }
                    ));
                    //mnu.MenuItems.Add(new MenuItem("Copy all", dataGridView_CopyAll));
                    mnu.MenuItems.Add(new MenuItem("Copy all", (EventHandler)delegate
                    {
                        dataGridView_CopyAll(sender, e);
                    }));

                    dataGridView.ContextMenu = mnu;
                    //dataGridView.CurrentCell = dataGridView.Rows[info.RowIndex].Cells[info.ColumnIndex];
                    dataGridView.ContextMenu.Show(dataGridView, e.Location);

                    dataGridView.Invalidate();
                }
            }
        }

        private static void dataGridView_CopyAll(object sender, EventArgs e)
        {
            dataGridView_SelectAllCell(sender, e);
            DataObject dataObject = (sender as DataGridView).GetClipboardContent();

            if (dataObject != null)
            {
                Clipboard.SetDataObject(dataObject);
            }
        }

        private static void dataGridView_Copy(object sender, EventArgs e)
        {
            DataObject dataObject = (sender as DataGridView).GetClipboardContent();

            if (dataObject != null)
            {
                Clipboard.SetDataObject(dataObject);
            }
        }

        private static void dataGridView_SelectAllCell(object sender, EventArgs e)
        {
            dataGridView_Select(sender as DataGridView, true);
        }

        private static void dataGridView_Select(DataGridView dataGridView, bool select)
        {
            for (int row = 0; row < dataGridView.RowCount; row++)
            {
                for (int column = 0; column < dataGridView.ColumnCount; column++)
                {
                    dataGridView.Rows[row].Cells[column].Selected = select;
                }
            }
        }

        private static void dataGridView_DeselectAllCell(object sender, EventArgs e)
        {
            dataGridView_Select(sender as DataGridView, false);
        }

        public static bool IsFileLocked(string filePath, int miliSecondsToWait = 50)
        {
            bool isLocked = true;

            if (miliSecondsToWait < 50)
            {
                miliSecondsToWait = 50;
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            while (isLocked && (stopwatch.ElapsedMilliseconds < miliSecondsToWait))
            {
                try
                {
                    using (File.Open(filePath, FileMode.Open)) { }
                    return false;
                }
                catch (IOException e)
                {
                    var errorCode = System.Runtime.InteropServices.Marshal.GetHRForException(e) & ((1 << 16) - 1);
                    isLocked = errorCode == 32 || errorCode == 33;
                }
            }

            return isLocked;
        }

        public static void TextBox_Validated_ToInt(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            int number = 0;

            if (int.TryParse(textBox.Text, out number))
            {
                textBox.Text = number.ToString();
            }
            else
            {
                textBox.Text = "0";
            }
        }

        public static void NumericUpDown_ValueChanged_AutoDecimalPlaces(object sender, EventArgs e, int decimals)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            string value = Math.Round(numericUpDown.Value, decimals, MidpointRounding.AwayFromZero).ToString();

            int decimalPlace = 0;

            if (!value.Contains('.'))
            {
                decimalPlace = 0;
            }
            else
            {
                decimalPlace = (value.Length - value.IndexOf('.') - 1);

            }

            numericUpDown.DecimalPlaces = decimalPlace;

            numericUpDown.Value = Math.Round(numericUpDown.Value, decimals, MidpointRounding.AwayFromZero);
        }

        //public static void ThreadInfo(ProcessThreadCollection ptc)
        //{

        //    int i = 1;

        //    foreach (ProcessThread pt in ptc)

        //    {

        //        Console.WriteLine("******* {0} 번째 스레드 정보 *******", i++);

        //        Console.WriteLine("ThreadId : {0}", pt.Id);            //스레드 ID

        //        Console.WriteLine("시작시간 : {0}", pt.StartTime);    //스레드 시작시간

        //        Console.WriteLine("우선순위 : {0}", pt.BasePriority);  //스레드 우선순위

        //        Console.WriteLine("상태 : {0}", pt.ThreadState);      //스레드 상태

        //        Console.WriteLine();
        //    }

        //}

        //public static void RemoveThread(ProcessThreadCollection prePtc, ProcessThreadCollection currentPtc)
        //{
        //    foreach (ProcessThread pt in currentPtc)
        //    {
        //        if (prePtc.IndexOf(pt) < 0)
        //        {
        //            pt.Dispose();
        //            Console.WriteLine("ThreadId : {0}", pt.Id);            //스레드 ID
        //        }
        //    }
        //}
        public static void TextBox_Validated_ToDouble(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            double number = 0;

            if (textBox.Text.EndsWith("."))
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }

            if (double.TryParse(textBox.Text, out number))
            {
                textBox.Text = number.ToString();
            }
            else
            {
                textBox.Text = "0";
            }
        }

        public static void TextBox_KeyPress_OnlyDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == '-' || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public static void TextBox_KeyPress_OnlyPositiveDecimal(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Delete) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public static void TextBox_Leave_TwoDecimalPoints(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            double temp = 0;

            if (!double.TryParse(textBox.Text, out temp))
            {
                textBox.Text = string.Format("0.00");
            }

            else
            {
                textBox.Text = string.Format("{0:0.00#}", Math.Round(double.Parse(textBox.Text), 2, MidpointRounding.AwayFromZero));
            }
        }

        public static void TextBox_Validated_TwoDecimalPointsIsMinus(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            double temp = 0;

            if (!double.TryParse(textBox.Text, out temp))
            {
                textBox.Text = "0.00";
            }
            else
            {
                if (temp > 0)
                {
                    textBox.Text = "0.00";
                }
            }
        }
    }
}
