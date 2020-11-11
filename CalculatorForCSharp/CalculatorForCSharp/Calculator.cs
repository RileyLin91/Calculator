using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForCSharp
{
    public partial class Calculator : Form
    {
        public string currentString;
        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        /// <summary>
        /// 捕獲鍵盤數字及 dot 鍵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculator_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    currentString = StringFun(0);
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    currentString = StringFun(1);
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    currentString = StringFun(2);
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    currentString = StringFun(3);
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    currentString = StringFun(4);
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    currentString = StringFun(5);
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    currentString = StringFun(6);
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    currentString = StringFun(7);
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    currentString = StringFun(8);
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    currentString = StringFun(9);
                    break;
                case Keys.Decimal:
                    currentString = StringFun(".");
                    break;
                default:
                    currentString = tbxResult.Text;
                    break;
            }

            tbxResult.Text = currentString;
        }

        /// <summary>
        /// 通用值判斷
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string StringFun(int value)
        {
            if (tbxResult.Text == "0")  // 開始數字為零
            {
                return value.ToString();
            }
            else
            {
                return tbxResult.Text + value.ToString();
            }
        }

        /// <summary>
        /// 判斷 dot 只能存在一個
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string StringFun(string value)
        {
            if (tbxResult.Text.IndexOf(".") == -1)
                return tbxResult.Text + value.ToString();
            else
                return tbxResult.Text;
        }
    }
}
