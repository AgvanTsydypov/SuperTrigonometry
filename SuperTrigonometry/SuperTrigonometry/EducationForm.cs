using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using MyLib;
using System.Diagnostics;

namespace SuperTrigonometry
{
    public partial class EducationForm : Form
    {
        public EducationForm()
        {
            InitializeComponent();
        }
        private void EducationForm_Load(object sender, EventArgs e)
        {
            string[] CountOfTasks = new string[5];
            for (int i = 0; i < CountOfTasks.Length; i++)
            {
                CountOfTasks[i] = (i + 1).ToString();
            }
            CBCount.Items.AddRange(CountOfTasks);
            AnswersCheckBox.Checked = true;
            PausePB.Hide();
        }
        private void TheoryBtn_Click(object sender, EventArgs e)
        {
            TheoryForm ComboMombo = new TheoryForm();
            Hide();
            ComboMombo.ShowDialog();
            Show();
        }
        private void InMenuBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CBCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBCount.Text == "" || CBCount.Text == null)
                    CountLbl.Text = $"Count of Tasks (none)";
                else
                    CountLbl.Text = $"Count of Tasks ({CBCount.Text})";
                if (int.Parse(CBCount.Text) > 10)
                    CBCount.Text = "10";
            }
            catch (Exception)
            {
                CBCount.Text = "1";
            }
        }
        private void CBCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        int tick = 0;
        int h = 0;
        int m = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tick == 60)
            {
                m++;
                tick = 0;
            }
            if (m == 60)
            {
                h++;
                m = 0;
            }
            TimeLbl.Text = $"Timer({h}h:{m}m:{tick}s)";
            tick++;
        }
        static Random rnd = new Random();
        static string path = "Answers.txt";
        private void Error(object sender, System.IO.FileNotFoundException e)
        {
            MessageBox.Show("неправильное заполнение");
        }
        private void GenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                tick = 0;
                h = 0;
                m = 0;

                Timer.Enabled = true;

                int CountOT = 1;

                if (!int.TryParse(CBCount.Text, out CountOT)) CountOT = 1;


                EndGameRB.Clear();

                Key key = new Key();
                ConvertRule Rule = new ConvertRule(SimpleTrig);

                int intKeyGen = -1;

                if (int.TryParse(KeyGenTB.Text, out intKeyGen) && intKeyGen != -1)
                {
                    File.WriteAllText(path, "");
                    int KGLength = intKeyGen.ToString().Length;
                    int[] mas = new int[KGLength];
                    for (int i = 0; i < KGLength; i++)
                    {
                        mas[i] = (intKeyGen % 10 % 6);
                        intKeyGen = intKeyGen / 10;
                    }
                    for (int i = 0; i < KGLength; i++)
                    {
                        switch (mas[i])
                        {
                            case 0:
                                Rule = SimpleTrig;
                                key.KeyGen(i, Rule);
                                break;
                            case 1:
                                Rule = MiddleTrig1;
                                key.KeyGen(i, Rule);
                                break;
                            case 2:
                                Rule = MiddleTrig2;
                                key.KeyGen(i, Rule);
                                break;
                            case 3:
                                Rule = MiddleTrig3;
                                key.KeyGen(i, Rule);
                                break;
                            case 4:
                                Rule = MiddleTrig4;
                                key.KeyGen(i, Rule);
                                break;
                            case 5:
                                Rule = MiddleTrig5;
                                key.KeyGen(i, Rule);
                                break;
                        }
                    }
                    ToHtml();
                    if (WebCheckBox.Checked == true)
                        Process.Start("ST.html");
                }
                else
                {
                    File.WriteAllText(path, "");
                    for (int i = 0; i < CountOT; i++)
                    {
                        int another = rnd.Next(1, 7);
                        if (another == 1)
                        {
                            SimpleTrig(i);
                        }
                        if (another == 2)
                        {
                            MiddleTrig1(i);
                        }
                        if (another == 3)
                        {
                            MiddleTrig2(i);
                        }
                        if (another == 4)
                        {
                            MiddleTrig3(i);
                        }
                        if (another == 5)
                        {
                            MiddleTrig4(i);
                        }
                        if (another == 6)
                        {
                            MiddleTrig5(i);
                        }
                    }
                    ToHtml();
                    if (WebCheckBox.Checked == true)
                        Process.Start("ST.html");
                }
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Something wrong with files!\n" + ioex.ToString());
            }
            catch (UnauthorizedAccessException unex)
            {
                MessageBox.Show(unex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public string TrigSinBack(string task1, string task2)
        {
            string trigsinback = $"(sin (x))^2 ";
            string tk1 = task1.Remove(0, 12);
            string tk2 = task2.Remove(0, 12);
            Fraction[] frac = InFrac(tk1, tk2);
            double x1, x2, y1, y2;
            x1 = frac[0].Numerator;
            x2 = frac[0].Denominator;
            y1 = frac[1].Numerator;
            y2 = frac[1].Denominator;
            if (-x1/x2 - y1/y2 != 0)
                trigsinback += $"+ ({TrigDoubleIntSqrt(-x1 / x2 - y1 / y2)})*(sin (x))";
            if (-x1 * y1 / y2 / x2 != 0)
                trigsinback += $"= ({TrigDoubleIntSqrt(-x1 * y1 / y2 / x2)})*(cos (x)) ";
            else
                trigsinback += "= 0";
            return trigsinback;
        }
        public string TrigCosCube(string task1, string task2)
        {
            string trigcoscube = "";
            string tk1 = task1.Remove(0, 12);
            string tk2 = task2.Remove(0, 12);
            Fraction[] frac = InFrac(tk1, tk2);
            double y1, y2;
            y1 = frac[1].Numerator;
            y2 = frac[1].Denominator;
            if (y2 != 0)
                trigcoscube += $"{TrigDoubleIntSqrt(y2)}*(cos (x))^3 ";
            if (y1 != 0)
                trigcoscube += $"+ {TrigDoubleIntSqrt(y1)}*(sin (x))^2 ";
            if (y2 != 0)
                trigcoscube += $"= {TrigDoubleIntSqrt(y2)}*(cos (x)) ";
            else
                trigcoscube += "= 0";
            return trigcoscube;
        }
        public string TrigTg(string task1, string task2)
        {
            string trigtg = "";
            string tk1 = task1.Remove(0, 12);
            string tk2 = task2.Remove(0, 12);
            Fraction[] frac = InFrac(tk1, tk2);
            double x1, x2, y1, y2;
            x1 = frac[0].Numerator;
            x2 = frac[0].Denominator;
            y1 = frac[1].Numerator;
            y2 = frac[1].Denominator;

            if (x2 * y2 != 0)
                trigtg += $"{TrigDoubleIntSqrt(x2 * y2)}*(sin (x)) ";
            if (-x1 * y2 != 0)
                trigtg += $"+ {TrigDoubleIntSqrt(-x1 * y2)} ";
            if (x1 * y1 != 0)
                trigtg += $"+ {TrigDoubleIntSqrt(x1 * y1)}/(cos (x)) ";
            if (x2 * y1 != 0)
                trigtg += $"= {TrigDoubleIntSqrt(x2 * y1)}*(tg (x))";
            else
                trigtg += "= 0";
            return trigtg;
        }
        public string TrigCosSin(string task1, string task2, string type)
        {
            string trigcossin = "";
            string tk1 = task1.Remove(0, 12);
            string tk2 = task2.Remove(0, 12);
            double doubleTk1;
            if (!double.TryParse(tk1, out doubleTk1))
                doubleTk1 = TrigSqrtInDouble(tk1);
            double doubleTk2;
            if (!double.TryParse(tk2, out doubleTk2))
                doubleTk2 = TrigSqrtInDouble(tk2);
            if (-doubleTk1 != 0)
                trigcossin += $"(sin (2x)) + ({TrigDoubleIntSqrt(-doubleTk1 * 2)})*(sin (x)) ";
            else
                trigcossin += $"(sin (2x)) ";
            if (-doubleTk2 * 2 != 0)
                trigcossin += $"+ ({TrigDoubleIntSqrt(-doubleTk2 * 2)})*(cos (x)) ";
            else
                trigcossin += $"";
            trigcossin += $"= {TrigDoubleIntSqrt(-doubleTk2 * 2 * doubleTk1)}";

            return trigcossin;
        }
        public string TrigCosCos(string task1,string task2, string type)
        {
            string tk1 = task1.Remove(0, 12);
            string tk2 = task2.Remove(0, 12);
            double a;
            do
            {
                a = rnd.Next(-2, 3);
            }
            while (a == 0);
            double doubleTk1;
            if (!double.TryParse(tk1, out doubleTk1))
                doubleTk1 = TrigSqrtInDouble(tk1);
            double doubleTk2;
            if (!double.TryParse(tk2, out doubleTk2))
                doubleTk2 = TrigSqrtInDouble(tk2);
            double p = (-a) * (doubleTk1 + doubleTk2);
            double q = a * doubleTk1 * doubleTk2;
            double pwa = doubleTk1 + doubleTk2;
            double qwa = doubleTk1 * doubleTk2;
            string trigCosCos = "";

            //MessageBox.Show($"{doubleTk1} + {doubleTk2} = {TrigDoubleIntSqrt(pwa)}");
            //MessageBox.Show($"{doubleTk1} * {doubleTk2} = {TrigDoubleIntSqrt(qwa)}");

            if (a % 2 != 0)
            {
                if (a == 1 || a == -1)
                {
                    if (a == 1)
                        trigCosCos += $"({type} (x))^2 ";
                    else
                        trigCosCos += $"-({type} (x))^2 ";
                }
                else
                {
                    trigCosCos += $"({a})*({type} (x))^2 ";
                }

                if (pwa != 0)
                    trigCosCos += $"+ ({-a})*({TrigDoubleIntSqrt(pwa)})*({type} (x))";
                else
                    trigCosCos += "";

                if (qwa == 0)
                {
                    trigCosCos += $" = 0";
                    return trigCosCos;
                }
                if (a == 1 || a == -1)
                {
                    if (a == 1)
                        trigCosCos += $"+ ({TrigDoubleIntSqrt(qwa)}) = 0";
                    else
                        trigCosCos += $"+ ({TrigDoubleIntSqrt(-qwa)}) = 0";
                }
                else
                    trigCosCos += $"+ ({a})*({TrigDoubleIntSqrt(qwa)}) = 0";

                return trigCosCos;
            }
            else
            {
                if (a < 0)
                {
                    trigCosCos += $" - (cos (2x))";         
                    if (pwa != 0)
                        trigCosCos += $"+ ({-a})*({TrigDoubleIntSqrt(pwa)})*({type} (x))";
                    else
                        trigCosCos += "";
                    if (qwa == 0)
                    {
                        trigCosCos += $" = 1";
                        return trigCosCos;
                    }
                    else
                        trigCosCos += $"+ (({a})*({TrigDoubleIntSqrt(qwa)})) = 1";
                }
                else
                {
                    trigCosCos += $"(cos (2x))";
                    if (pwa != 0)
                        trigCosCos += $"+ ({-a})*({TrigDoubleIntSqrt(pwa)})*({type} (x))";
                    else
                        trigCosCos += "";
                    if (qwa == 0)
                    {
                        trigCosCos += $" = -1";
                        return trigCosCos;
                    }
                    else
                        trigCosCos += $"+ (({a})*({TrigDoubleIntSqrt(qwa)})) = -1";
                }
                return trigCosCos;
            }
        }
        public double TrigSqrtInDouble(string sqrt)
        {
            double ans = 0;
            if (sqrt == "-2^(1/2)/2")
                ans = -0.71;
            if (sqrt == "2^(1/2)/2")
                ans = 0.71;
            if (sqrt == "3^(1/2)/2")
                ans = 0.87;
            if (sqrt == "-3^(1/2)/2")
                ans = -0.87;
            if (sqrt == "-2^(1/2)")
                ans = -1.42;
            if (sqrt == "2^(1/2)")
                ans = 1.42;
            if (sqrt == "3^(1/2)")
                ans = 1.74;
            if (sqrt == "-3^(1/2)")
                ans = -1.74;
            return ans;
        }
        public string TrigDoubleIntSqrt(double ans)
        {
            Fraction f1;
            if (ans == 0 || ans == 1 || ans == -1 || ans == 0.5 || ans == -0.5 || ans == 1.5 || ans == -1.5)
            {
                f1 = new Fraction(ans);
                return $"({f1.Numerator}/{f1.Denominator})";
            }
            else
            {
                double step;
                if (ans % 0.1775 == 0)
                {
                    if (ans < 1.42)
                    {
                        step = ans / 0.1775;
                        return $"2^(1/2)/{8/step}";
                    }
                    if (ans == 1.42)
                        return $"2^(1/2)";
                    if (ans > 1.42)
                    {
                        step = ans / 0.1775;
                        return $"2^(1/2)*{step/8}";
                    }
                }
                if (ans % 0.2175 == 0)
                {
                    if (ans < 1.74)
                    {
                        step = ans / 0.2175;
                        return $"3^(1/2)/{8 / step}";
                    }
                    if (ans == 1.74)
                        return $"3^(1/2)";
                    if (ans > 1.74)
                    {
                        step = ans / 0.2175;
                        return $"3^(1/2)*{step / 8}";
                    }
                }
                if ((ans - 0.87) % 0.5 == 0)
                {
                    step = (ans - 0.87) / 0.5 ;
                    return $"(3^(1/2) + {step})/2";
                }
                if ((ans + 0.87) % 0.5 == 0)
                {
                    step = (ans + 0.87) / 0.5;
                    return $"{step} - (3^(1/2))/2";
                }
                if ((ans - 0.71) % 0.5 == 0)
                {
                    step = (ans - 0.71) / 0.5;
                    return $"(2^(1/2) + {step})/2";
                }
                if ((ans + 0.71) % 0.5 == 0)
                {
                    step = (ans + 0.71) / 0.5;
                    return $"{step} - (2^(1/2))/2";
                }
                if (ans % (0.87*0.71) == 0)
                {
                    if (ans > 0)
                        return "(-6^(1/2))/4";
                    return "(6^(1/2))/4";
                }
                if (ans % (0.87 - 0.71) == 0)
                {
                    if (ans > 0)
                        return "(3^(1/2) - 2^(1/2))/2";
                    return "(2^(1/2) - 3^(1/2))/2";
                }
                if (ans % (0.87 + 0.71) == 0)
                {
                    if (ans > 0)
                        return "(3^(1/2) + 2^(1/2))/2";
                    return "-(3^(1/2) + 2^(1/2))/2";
                }
                if (ans % (0.87 * 0.87) == 0)
                {
                    if (ans > 0)
                        return "3/4";
                    return "-3/4";
                }
                if (ans % (0.71 * 0.71) == 0)
                {
                    if (ans > 0)
                        return "1/2";
                    return "-1/2";
                }
                if (ans / 1.37 == 1 || ans /1.37 == -1)
                {
                    if (ans > 0)
                        return "(3^(1/2) + 1)/2";
                    else
                        return "(-3^(1/2) - 1)/2";
                }
            }
            return ans.ToString();
        }
        public string TrigForm()
        {
            int rand = rnd.Next(1, 3);
            string trigForm="";
            if (rand == 1)
                trigForm = "(cos (x))";
            if (rand == 2)
                trigForm = "(sin (x))";
            return trigForm;
        }
        public string TrigArgument()
        {
            int rand = rnd.Next(2, 6);
            string trigArguments = "";
           // if (rand == 1)
            //    trigArguments += $"0";
            if (rand == 2)
                trigArguments += $"{PlusMinus()}0,5";
            if (rand == 3)
                trigArguments += $"{PlusMinus()}2^(1/2)/2";
            if (rand == 4)
                trigArguments += $"{PlusMinus()}3^(1/2)/2";
            if (rand == 5)
                trigArguments += $"{PlusMinus()}1";
            return trigArguments;
        }
        public string TrigAns(string st)
        {
            string ans = "";
            if (st == "(cos (x)) = 0")
                ans = "x = pi/2 + pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = 0,5")
                ans = "x = pi/3 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -pi/3 + 2*pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = -0,5")
                ans = "x = 2*pi/3 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -2*pi/3 + 2*pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = 2^(1/2)/2")
                ans = "x = pi/4 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -pi/4 + 2*pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = -2^(1/2)/2")
                ans = "x = 3*pi/4 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -3*pi/4 + 2*pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = 3^(1/2)/2")
                ans = "x = pi/6 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -pi/6 + 2*pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = -3^(1/2)/2")
                ans = "x = 5*pi/6 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -5*pi/6 + 2*pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = 1")
                ans = "x = 2*pi*n, n belongs to the set of integers";
            if (st == "(cos (x)) = -1")
                ans = "x = pi + 2*pi*n, n belongs to the set of integers";

            if (st == "(sin (x)) = 0")
                ans = "x = pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = 0,5")
                ans = "x = pi/6 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = 5*pi/6 + 2*pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = -0,5")
                ans = "x = -pi/6 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -5*pi/6 + 2*pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = 2^(1/2)/2")
                ans = "x = pi/4 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = 3*pi/4 + 2*pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = -2^(1/2)/2")
                ans = "x = -pi/4 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -3*pi/4 + 2*pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = 3^(1/2)/2")
                ans = "x = pi/3 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = 2*pi/3 + 2*pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = -3^(1/2)/2")
                ans = "x = -pi/3 + 2*pi*n, n belongs to the set of integers\n" +
                    "x = -2*pi/3 + 2*pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = 1")
                ans = "x = pi/2 + 2*pi*n, n belongs to the set of integers";
            if (st == "(sin (x)) = -1")
                ans = "x = -pi/2 + 2*pi*n, n belongs to the set of integers";

            return ans;
        }
        public string PlusMinus()
        {
            int rand = rnd.Next(1, 3);
            string PM = "";
            if (rand == 1)
                PM = "-";
            else
                PM = "";
            return PM;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void TimerBtn_Click(object sender, EventArgs e)
        {
            Timer.Enabled = !Timer.Enabled;
            if (Timer.Enabled == false)
                PausePB.Show();
            else
                PausePB.Hide();
        }
        private void PrintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                filetext = File.ReadAllText(path);
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintPageHandler;
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                    printDialog.Document.Print();
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Something wrong with files!\n" + ioex.ToString());
            }
            catch (UnauthorizedAccessException unex)
            {
                MessageBox.Show(unex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        static string filetext = "";
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString(filetext, new Font("Arial", 14), Brushes.Black, 0, 0);
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Something wrong with files!\n" + ioex.ToString());
            }
            catch (UnauthorizedAccessException unex)
            {
                MessageBox.Show(unex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void SimpleTrig(int i)
        {
            string text = "";
            string task = "";
            string task1 = "";
            task1 = $"{TrigForm()} = {TrigArgument()}";
            task = AddCastFormulas(task1);
            if (AnswersCheckBox.Checked == true)
                text += $"{i + 1}) {task}\n{TrigAns(task1)}\n\n";
            else
                text += $"{i + 1}) {task}\n\n";
            EndGameRB.AppendText($"{i + 1}) " + task + "\n");
            File.AppendAllText(path, text);
        }
        public void MiddleTrig1(int i)
        {
            string text = "";
            string task = "";
            string task1 = "";
            string task2 = "";
            task1 = $"(cos (x)) = {TrigArgument()}";
            task2 = $"(cos (x)) = {TrigArgument()}";
            task = TrigCosCos(task1, task2, "cos");
            task = AddCastFormulas(task);
            if (AnswersCheckBox.Checked == true)
                text += $"{i + 1}) {task}\n{TrigAns(task1)}\n{TrigAns(task2)}\n{task1}\n{task2}\n\n";
            else
                text += $"{i + 1}) {task}\n\n";
            EndGameRB.AppendText($"{i + 1})" + task + "\n");
            File.AppendAllText(path, text);
        }
        public void MiddleTrig2(int i)
        {
            string text = "";
            string task = "";
            string task1 = "";
            string task2 = "";
            task1 = $"(cos (x)) = {TrigArgument()}";
            task2 = $"(sin (x)) = {TrigArgument()}";
            task = TrigCosSin(task1, task2, "cos");
            task = AddCastFormulas(task);
            if (AnswersCheckBox.Checked == true)
                text += $"{i + 1}) {task}\n{TrigAns(task1)}\n{TrigAns(task2)}\n{task1}\n{task2}\n\n";
            else
                text += $"{i + 1}) {task}\n\n";
            EndGameRB.AppendText($"{i + 1}) " + task + "\n");
            File.AppendAllText(path, text);
        }
        public void MiddleTrig3(int i)
        {
            try
            {
                string text = "";
                string task = "";
                string task1 = "";
                string task2 = "";
                task1 = $"(sin (x)) = {TrigArgument()}";
                task2 = $"(cos (x)) = {TrigArgument()}";
                task = TrigTg(task1, task2);
                task = AddCastFormulas(task);
                if (AnswersCheckBox.Checked == true)
                    text += $"{i + 1}) {task}\n{TrigAns(task1)}\n{TrigAns(task2)}\n{task1}\n{task2}\n\n";
                else
                    text += $"{i + 1}) {task}\n\n";
                EndGameRB.AppendText($"{i + 1}) " + task + "\n");
                File.AppendAllText(path, text);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Были удалены исходные файлы, переустановите программу!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
        public void MiddleTrig4(int i)
        {
            try
            {
                string text = "";
                string task = "";
                string task1 = "";
                string task2 = "";
                task1 = $"(sin (x)) = 0";
                task2 = $"(cos (x)) = {TrigArgument()}";
                task = TrigCosCube(task1, task2);
                task = AddCastFormulas(task);
                if (AnswersCheckBox.Checked == true)
                    text += $"{i + 1}) {task}\n{TrigAns(task1)}\n{TrigAns(task2)}\n{task1}\n{task2}\n\n";
                else
                    text += $"{i + 1}) {task}\n\n";
                EndGameRB.AppendText($"{i + 1}) " + task + "\n");
                File.AppendAllText(path, text);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Были удалены исходные файлы, переустановите программу!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
        public void MiddleTrig5(int i)
        {
            try
            {
                string text = "";
                string task = "";
                string task1 = "";
                string task2 = "";
                task1 = $"(sin (x)) = {TrigArgument()}";
                task2 = $"(sin (x)) = {TrigArgument()}";
                task = TrigSinBack(task1, task2);
                task = AddCastFormulas(task);
                if (AnswersCheckBox.Checked == true)
                    text += $"{i + 1}) {task}\n{TrigAns(task1)}\n{TrigAns(task2)}\n{task1}\n{task2}\n\n";
                else
                    text += $"{i + 1}) {task}\n\n";
                EndGameRB.AppendText($"{i + 1}) " + task + "\n");
                File.AppendAllText(path, text);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Были удалены исходные файлы, переустановите программу!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
        public string AddCastFormulas(string task)
        {
            string taskV2 = "";
            do
            {
                string V2 = "";
                V2 = task.Substring(0, task.IndexOf("x))") + 3);
                if (V2.IndexOf("tg") > 0 || V2.IndexOf("2x") > 0)
                {
                    taskV2 += V2;
                }
                else
                {
                    V2 = AddCastForm(V2);
                    taskV2 += V2;
                }
                task = task.Remove(0, task.IndexOf("x))") + 3);
            }
            while (task.IndexOf("(x))") > 0);
            taskV2 += task;
            return taskV2;
        }
        public string AddCastForm(string arg)
        {
            int chance = rnd.Next(1, 4);
            if (chance == 1 || chance == 2)
            {
                string ans = "";
                if (arg.IndexOf("cos") > 0)
                {
                    int rand = rnd.Next(1, 3);
                    if (rand == 1)
                    {
                        ans = arg.Replace("cos", "sin");
                        ans = ans.Replace("(x)", "(x + pi/2)");
                    }
                    if (rand == 2)
                    {
                        ans = arg.Replace("cos", "cos");
                        ans = ans.Replace("(x)", "(x + 2*pi)");
                    }
                }
                if (arg.IndexOf("-cos") > 0)
                {
                    int rand = rnd.Next(1, 3);
                    if (rand == 1)
                    {
                        ans = arg.Replace("-cos", "cos");
                        ans = ans.Replace("(x)", "(x + pi)");
                    }
                    if (rand == 2)
                    {
                        ans = arg.Replace("-cos", "sin");
                        ans = ans.Replace("(x)", "(x + 3*pi/2)");
                    }
                }
                if (arg.IndexOf("sin") > 0)
                {
                    int rand = rnd.Next(1, 3);
                    if (rand == 1)
                    {
                        ans = arg.Replace("sin", "cos");
                        ans = ans.Replace("(x)", "(x + 3*pi/2)");
                    }
                    if (rand == 2)
                    {
                        ans = arg.Replace("sin", "sin");
                        ans = ans.Replace("(x)", "(x + 2*pi)");
                    }
                }
                if (arg.IndexOf("-sin") > 0)
                {
                    int rand = rnd.Next(1, 3);
                    if (rand == 1)
                    {
                        ans = arg.Replace("-sin", "cos");
                        ans = ans.Replace("(x)", "(x + pi/2)");
                    }
                    if (rand == 2)
                    {
                        ans = arg.Replace("-sin", "sin");
                        ans = ans.Replace("(x)", "(x + pi)");
                    }
                }
                return ans;
            }
            else
                return arg;
        }
        public void ToHtml()
        {
            string text =
                "<!Doctype html>" +
                    "<head>" +
                         "<style>"+
                         "span{"+
                         "font-style:italic;"+
                         "}"+
                             "span::after{"+
                            "content:' ';"+
                            "display:inline-block;"+
                            "position: relative;"+
                            "top: -14px;"+
                            "left: -12px;"+
                            "width: 14px;"+
                            "height: 1px;"+
                            "background-color:grey;"+
                         "}"+
                         "</style>"+
                        "<title>SuperTrigonometry</title>" +
                    "</head>" +
                    "<body>";
                //  "</body>" +
             // "</html>";
            string[] strTask = File.ReadAllLines(path);
            text += HeadingLvl("Your tasks and answers",1);
            for (int i = 0; i < strTask.Length; i++)
            {
                text += NewLine(strTask[i]);
            }
            text += 
                "</body>" +
                "</html>";
            text = text.Replace("pi", "&pi;");
            text = text.Replace("2^(1/2)", "<span>&#8730 2</span>");
            text = text.Replace("3^(1/2)", "<span>&#8730 3</span>");
            text = text.Replace("6^(1/2)", "<span>&#8730 6</span>");
            text = text.Replace("1/1)", "1)");
            File.WriteAllText("ST.html", text);
        }
        public string Paragraph(string str)
        {
            return $"<p>{str}</p>";
        }
        public string NewLine(string str)
        {
            return $"<br>{str}</br>";
        }
        public string HeadingLvl(string str,int i)
        {
            if (i != 6)
                i = Math.Abs(i) % 6;
            return $"<h{i}>{str}</h{i}>";
        }
        private void KeyGenTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (KeyGenTB.Text.Length > 10)
                KeyGenTB.Text = "9999999999";
        }
        public Fraction[] InFrac(string tk1, string tk2)
        {
            Fraction f1;
            Fraction f2;
            double doubleTk1;
            if (!double.TryParse(tk1, out doubleTk1))
                doubleTk1 = TrigSqrtInDouble(tk1);
            double doubleTk2;
            if (!double.TryParse(tk2, out doubleTk2))
                doubleTk2 = TrigSqrtInDouble(tk2);
            string[] fracMas = new string[4];
            if (doubleTk1 == 0 || doubleTk1 == 1 || doubleTk1 == -1 || doubleTk1 == 0.5 || doubleTk1 == -0.5)
            {
                f1 = new Fraction(doubleTk1);
            }
            else
            {
                fracMas[0] = tk1.Substring(0, tk1.IndexOf(")/") + 1);
                fracMas[1] = tk1[tk1.Length - 1].ToString();
                f1 = new Fraction(TrigSqrtInDouble(fracMas[0]), int.Parse(fracMas[1]));
            }
            if (doubleTk2 == 0 || doubleTk2 == 1 || doubleTk2 == -1 || doubleTk2 == 0.5 || doubleTk2 == -0.5)
            {
                f2 = new Fraction(doubleTk2);
            }
            else
            {
                fracMas[2] = tk2.Substring(0, tk2.IndexOf(")/") + 1);
                fracMas[3] = tk2[tk2.Length - 1].ToString();
                f2 = new Fraction(TrigSqrtInDouble(fracMas[2]), int.Parse(fracMas[3]));
            }
            Fraction[] frac = new Fraction[2];
            frac[0] = f1;
            frac[1] = f2;
            return frac;
        }
    }
}