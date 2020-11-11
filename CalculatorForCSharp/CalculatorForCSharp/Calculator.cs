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
        public string preString;
        public string currentOperand;
        public string preOperand;
        public bool IsOperand = false;
        public bool IsEqual = false;
        public Calculator()
        {
            InitializeComponent();

            // 數字
            this.btnZero.Click += new System.EventHandler(this.btnNum_Click);
            this.btnOne.Click += new System.EventHandler(this.btnNum_Click);
            this.btnTwo.Click += new System.EventHandler(this.btnNum_Click);
            this.btnThree.Click += new System.EventHandler(this.btnNum_Click);
            this.btnFour.Click += new System.EventHandler(this.btnNum_Click);
            this.btnFive.Click += new System.EventHandler(this.btnNum_Click);
            this.btnSix.Click += new System.EventHandler(this.btnNum_Click);
            this.btnSeven.Click += new System.EventHandler(this.btnNum_Click);
            this.btnEight.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNine.Click += new System.EventHandler(this.btnNum_Click);
            this.btnDot.Click += new System.EventHandler(this.btnNum_Click);

            // 運算元
            this.btnAdd.Click += new System.EventHandler(this.btnOperand_Click);
            this.btnSubtract.Click += new System.EventHandler(this.btnOperand_Click);
            this.btnMultiply.Click += new System.EventHandler(this.btnOperand_Click);
            this.btnDivide.Click += new System.EventHandler(this.btnOperand_Click);
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
            IsOperand = false;

            if (tbxResult.Text == "0" && string.IsNullOrEmpty(currentOperand))  // 開始數字為零
            {
                return value.ToString();
            }
            else if (string.IsNullOrEmpty(currentOperand)) // 尚未選擇運算元
            {
                return tbxResult.Text + value.ToString();
            }
            else // 已經選擇運算元
            {
                preOperand = currentOperand;
                currentOperand = string.Empty;
                return value.ToString();
            }
        }

        /// <summary>
        /// 判斷 dot 只能存在一個
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string StringFun(string value)
        {
            IsOperand = false;

            if (tbxResult.Text.IndexOf(".") == -1)
                return tbxResult.Text + value.ToString();
            else
                return tbxResult.Text;
        }

        /// <summary>
        /// 0-9 & dot 數字按鈕被點擊時觸發
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == ".")
            {
                if (IsOperand)
                {
                    currentString = "0.";
                    IsOperand = false;
                    preString = string.Empty;
                    preOperand = string.Empty;
                    currentOperand = string.Empty;
                }
                else
                {
                    currentString = StringFun(".");
                }
            }
            else if (!(tbxResult.Text == "0" && btn.Text == "0"))
            {
                currentString = StringFun(Int16.Parse(btn.Text));
            }

            if (!string.IsNullOrEmpty(preString) && !string.IsNullOrEmpty(currentString))
                IsEqual = false;

            tbxResult.Text = currentString;
        }

        /// <summary>
        /// 運算元（加減乘除）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperand_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (!IsOperand)
            {
                if (!string.IsNullOrEmpty(preOperand))
                {
                    switch (preOperand)
                    {
                        case "+":
                            tbxResult.Text = (Double.Parse(preString) + Double.Parse(currentString)).ToString();
                            break;
                        case "-":
                            tbxResult.Text = (Double.Parse(preString) - Double.Parse(currentString)).ToString();
                            break;
                        case "*":
                            tbxResult.Text = (Double.Parse(preString) * Double.Parse(currentString)).ToString();
                            break;
                        case "/":
                            tbxResult.Text = (Double.Parse(preString) / Double.Parse(currentString)).ToString();
                            break;
                    }

                    preOperand = string.Empty;
                }
            }

            switch (btn.Name)
            {
                case "btnAdd":
                    currentOperand = "+";
                    break;
                case "btnSubtract":
                    currentOperand = "-";
                    break;
                case "btnMultiply":
                    currentOperand = "*";
                    break;
                case "btnDivide":
                    currentOperand = "/";
                    break;
            }

            if (tbxResult.Text.EndsWith("."))
            {
                tbxResult.Text = tbxResult.Text.TrimEnd('.');
            }

            preString = tbxResult.Text;

            IsOperand = true;
        }

        /// <summary>
        /// 等號運算作業
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEqual_Click(object sender, EventArgs e)
        {
            IsOperand = true;
            IsEqual = true;

            if (!string.IsNullOrEmpty(preOperand) && !string.IsNullOrEmpty(preString) && !string.IsNullOrEmpty(currentString))
            {
                switch (preOperand)
                {
                    case "+":
                        tbxResult.Text = (Decimal.Parse(preString) + Decimal.Parse(currentString)).ToString();
                        break;
                    case "-":
                        tbxResult.Text = (Decimal.Parse(preString) - Decimal.Parse(currentString)).ToString();
                        break;
                    case "*":
                        tbxResult.Text = (Decimal.Parse(preString) * Decimal.Parse(currentString)).ToString();
                        break;
                    case "/":
                        tbxResult.Text = (Decimal.Parse(preString) / Decimal.Parse(currentString)).ToString();
                        break;
                }

                preString = tbxResult.Text;
            }
        }

        /// <summary>
        /// 清除歸零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnC_Click(object sender, EventArgs e)
        {
            tbxResult.Text = "0";
            currentString = string.Empty;
            preString = string.Empty;
            currentOperand = string.Empty;
            preOperand = string.Empty;
            IsOperand = false;
        }

        /// <summary>
        /// 更新當前輸入數值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCE_Click(object sender, EventArgs e)
        {
            tbxResult.Text = "0";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (!IsEqual)
            {
                string value = tbxResult.Text;

                value = value.Remove(value.Length - 1, 1);

                if (Decimal.TryParse(value, out Decimal r))
                {
                    if (r < 0)
                    {
                        value = "0";
                    }
                }

                currentString = value;

                tbxResult.Text = currentString;
            }
        }
    }
}
