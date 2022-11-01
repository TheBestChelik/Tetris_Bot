using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisBot
{
    static class OldProgramm
    {



        static int[] Best_Res_Info;

        static string[][][][] Super_Res_Ret;
        static int[][] Res_Inf_Ret;

        static string[] zer_drown;
        static string[] fir_drown;
        static string[] sec_drown;
        static string[] min_drown;

        static int[] ch_zer;
        static int[] ch_fir;
        static int[] ch_sec;

        static int figure = 6;
        static int Next = 3;
        static int PosStart;
        static string[][] f = new string[20][]
        {
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
            new string[] {".",".", ".", ".", ".", ".", ".", ".", "1", "1" },
            new string[] {".",".", ".", ".", ".", "1", "1", "1", "1", "1" },
            new string[] {".",".", ".", ".", ".", "1", "1", "1", "1", "1" }
        };

        public static string Main(int StartXBoard, int StartYBoard, int WidthBoard, int HeiGthBoard, int StartXNew, int StartYNew,int WidthNew, int HeightNew)
        {
            //Scan(StartXBoart: int.Parse(args[0]), StartYBoard: int.Parse(args[1]), WidthBoard: int.Parse(args[2]), HeigthBoard: int.Parse(args[3]));
            //.Show(StartXBoard.ToString() + "   " + StartYBoard.ToString());
            
                //Click();

                long Start = DateTime.Now.Ticks;
                string res = Scan(StartXBoard, StartYBoard, WidthBoard, HeiGthBoard, StartXNew,StartYNew, WidthNew, HeightNew);
                if (res != String.Empty)
                    return res;
                //print(f);
                ///////////////
                generate(figure, new string[1][][] { f });
                string[][][][] GenInp = Super_Res_Ret;
                int[][] ResInfo = Res_Inf_Ret;
                List<string[][]> ToScore = new List<string[][]>();
                for (int one = 0; one < GenInp[0].Length; one++)
                {
                    for (int two = 0; two < GenInp[0][one].Length; two++)
                    {
                        for (int three = 0; three < GenInp[0][one][two].Length; three++)
                        {
                            if (GenInp[0][one][two][three] == "8")
                            {
                                GenInp[0][one][two][three] = "1";
                            }
                        }
                    }
                }
                generate(Next, GenInp[0]);
                GenInp = Super_Res_Ret;
                for (int nn = 0; nn < GenInp.Length; nn++)
                {
                    for (int i = 0; i < GenInp[nn].Length; i++)
                    {
                        if (GenInp[nn][i].Length > 1)
                        {
                            //Console.WriteLine("nn = " + nn.ToString() + " i = " + i.ToString());
                            //print(Super_Res_Ret[nn][i]);
                            ToScore.Add(GenInp[nn][i]);
                            //print(GenInp[nn][i]);
                        }
                        else
                        {

                            // Console.WriteLine("А список то пустой "+i.ToString());
                        }

                    }
                }
                List<int[]> ResInfToScore = new List<int[]>();
                for (int sc = 0; sc <

                    GenInp.Length; sc++)
                {
                    foreach (string[][] rere in GenInp[sc])
                    {
                        if (rere.Length > 1)
                        {
                            ResInfToScore.Add(ResInfo[sc]);
                        }
                    }
                }


                Score(ToScore.ToArray(), ResInfToScore.ToArray());
                int posEnd = Best_Res_Info[0];
                int rot = Best_Res_Info[1];
                //////////

                //Console.WriteLine("Start pos = " + PosStart.ToString());
                if (rot != 0)
                {
                    //down(2);
                    if (figure == 2)
                    {
                        if (PosStart == 0)
                        {
                            right(1);
                            PosStart += 1;
                        }
                    }
                    up(rot);
                    if (figure == 0)
                    {
                        if (rot == 3)
                        {
                            PosStart += 1;
                        }
                    }
                    if (figure == 1)
                    {
                        if (rot == 2)
                        {
                            PosStart += 1;
                        }
                    }
                    if (figure == 2)
                    {
                        PosStart -= 1;
                    }
                    if (figure == 3)
                    {
                        //if (rot == 3)
                        //{
                        //    PosStart++;
                        //}
                    }
                    if (figure == 4)
                    {
                        //if (rot == 3)
                        // {
                        //     PosStart++;
                        // }
                    }
                    if (figure == 6)
                    {
                        PosStart += 2;
                    }
                }
                //left(9);
                //right(posEnd);
                //Console.WriteLine("New Start pos = " + PosStart.ToString());
                //Console.WriteLine("posEnd = " + posEnd.ToString());
                int move = posEnd - PosStart;
                //Console.WriteLine("Move " + move.ToString() + " and rotate " + rot.ToString());
                if (move > 0)
                {
                    right(move);
                }
                else
                {
                    left(-move);
                }
                down(3);
            //Thread.Sleep(100);
            //Console.WriteLine(((DateTime.Now.Ticks - Start) / TimeSpan.TicksPerMillisecond).ToString());
            string ConsoleString = string.Format(Properties.Settings.Default.ConsoleString,Environment.NewLine,print(f),figure.ToString(), Next.ToString(),move.ToString(),rot.ToString());
                return ConsoleString;
                
            
            //Main(args);

        }
        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        static void Click()
        {
            //Thread.Sleep(5000);
            SetCursorPos(500, 500);
            //Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

        }
        static void up(int n)
        {
            for (int i = 0; i < n; i++)
            {
                SendKeys.SendWait("{UP}");
                Thread.Sleep(Properties.Settings.Default.PauseBtwPressingKeys);
            }
        }
        static void down(int n)
        {
            for (int i = 0; i < n; i++)
            {
                SendKeys.SendWait("{DOWN}");
                Thread.Sleep(Properties.Settings.Default.PauseBtwPressingKeys);
            }
        }
        static void right(int n)
        {
            for (int i = 0; i < n; i++)
            {
                SendKeys.SendWait("{RIGHT}");
                Thread.Sleep(Properties.Settings.Default.PauseBtwPressingKeys);
            }
        }
        static void left(int n)
        {
            for (int i = 0; i < n; i++)
            {
                SendKeys.SendWait("{LEFT}");
                Thread.Sleep(Properties.Settings.Default.PauseBtwPressingKeys);
            }
        }
        static void IsNew(int StartXBoart, int StartYBoard, int WidthBoard, int cellSize, int StartXNew, int StartYNew, int WidthNew, int HeigthNew)
        {
            //MessageBox.Show(StartXBoart.ToString() + "   " + (StartYBoard + (int)(cellSize * 2.5)).ToString());
            while (true)
            {

                long teter = DateTime.Now.Ticks;
                Bitmap b = new Bitmap(WidthBoard, 1);
                Graphics gr = Graphics.FromImage(b as Image);
                gr.CopyFromScreen(StartXBoart, StartYBoard + (int)(cellSize * 2.5), 0, 0, b.Size);//275
                //b.Save("line.png");
                figure = -7;
                Next = -7;
                int y = 0;
                for (int x = (int)(cellSize / 2); x < WidthBoard; x += cellSize)
                {

                    if (b.GetPixel(x, y) == Color.FromArgb(255, 0, 255, 255) || b.GetPixel(x, y) == Color.FromArgb(255, 255, 255, 0) || b.GetPixel(x, y) == Color.FromArgb(255, 128, 0, 128) || b.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 255) || b.GetPixel(x, y) == Color.FromArgb(255, 0, 128, 0) || b.GetPixel(x, y) == Color.FromArgb(255, 255, 0, 0) || b.GetPixel(x, y) == Color.FromArgb(255, 255, 165, 0))
                    {
                       // Console.WriteLine("Foujnd");
                        if (b.GetPixel(x, y) == Color.FromArgb(255, 0, 255, 255)) { figure = 6; }
                        if (b.GetPixel(x, y) == Color.FromArgb(255, 255, 255, 0)) { figure = 5; }
                        if (b.GetPixel(x, y) == Color.FromArgb(255, 128, 0, 128)) { figure = 0; }
                        if (b.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 255)) { figure = 1; }
                        if (b.GetPixel(x, y) == Color.FromArgb(255, 0, 128, 0)) { figure = 4; }
                        if (b.GetPixel(x, y) == Color.FromArgb(255, 255, 165, 0)) { figure = 2; }
                        if (b.GetPixel(x, y) == Color.FromArgb(255, 255, 0, 0)) { figure = 3; }


                        Bitmap Fornext = new Bitmap(WidthNew,HeigthNew);
                        Graphics gra = Graphics.FromImage(Fornext as Image);
                        gra.CopyFromScreen(StartXNew, StartYNew, 0, 0, Fornext.Size);
                        if (Fornext.GetPixel((int)(WidthNew*0.45), (int)(HeigthNew * 0.45)) == Color.FromArgb(255, 0, 255, 255)) { Next = 6; }
                        if (Fornext.GetPixel((int)(WidthNew * 0.45), (int)(HeigthNew * 0.45)) == Color.FromArgb(255, 255, 255, 0)) { Next = 5; }
                        if (Fornext.GetPixel((int)(WidthNew * 0.45), (int)(HeigthNew * 0.45)) == Color.FromArgb(255, 128, 0, 128)) { Next = 0; }
                        if (Fornext.GetPixel((int)(WidthNew * 0.45), (int)(HeigthNew * 0.45)) == Color.FromArgb(255, 0, 0, 255)) { Next = 1; }
                        if (Fornext.GetPixel((int)(WidthNew * 0.45), (int)(HeigthNew * 0.45)) == Color.FromArgb(255, 0, 128, 0)) { Next = 4; }
                        if (Fornext.GetPixel((int)(WidthNew * 0.45), (int)(HeigthNew * 0.45)) == Color.FromArgb(255, 255, 165, 0)) { Next = 2; }
                        if (Fornext.GetPixel((int)(WidthNew * 0.45), (int)(HeigthNew * 0.45)) == Color.FromArgb(255, 255, 0, 0)) { Next = 3; }
                        PosStart = (x - cellSize/2) / cellSize;
                        if (figure == 0) { PosStart--; }
                        if (figure == 3) { PosStart--; }
                        
                        break;
                    }
                }
                if (figure != -7)
                {
                    break;
                }

            }
        }

        static string Scan(int StartXBoart, int StartYBoard, int WidthBoard, int HeigthBoard, int StartXNew, int StartYNew, int WidthNew, int HeigthNew)
        {
            int cellSize = (int)(HeigthBoard / 20);
            IsNew(StartXBoart, StartYBoard, WidthBoard, cellSize,StartXNew,StartYNew, WidthNew, HeigthNew);
            if (Next == -7)
            {
                return Properties.Settings.Default.ErrorNext;
            }
            Bitmap screen = new Bitmap(WidthBoard, HeigthBoard);
            Graphics graphics = Graphics.FromImage(screen as Image);
            graphics.CopyFromScreen(StartXBoart, StartYBoard, 0, 0, screen.Size);
            


            for (int line = 0; line < 20; line++)
            {
                int y = (line * cellSize) + (int)(cellSize / 2);
                for (int row = 0; row < 10; row++)
                {
                    int x = (row * cellSize) + (int)(cellSize / 2);
                    if (screen.GetPixel(x, y) == Color.FromArgb(255, 0, 255, 255) || screen.GetPixel(x, y) == Color.FromArgb(255, 255, 255, 0) || screen.GetPixel(x, y) == Color.FromArgb(255, 128, 0, 128) || screen.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 255) || screen.GetPixel(x, y) == Color.FromArgb(255, 0, 128, 0) || screen.GetPixel(x, y) == Color.FromArgb(255, 255, 0, 0) || screen.GetPixel(x, y) == Color.FromArgb(255, 255, 165, 0))
                    {
                        if (line > 5)
                        {
                            f[line][row] = "1";
                        }
                    }
                    else
                    {
                        f[line][row] = ".";
                    }

                }

            }
            return String.Empty;
        }



        static void Score(string[][][] fields, int[][] resinfo)
        {
            int s = 0;
            List<int> results = new List<int>();
            foreach (string[][] sit in fields)
            {

                int Score = 0;
                int highest = -7;
                int high = -7;
                int hhh = -7;
                for (int row = 0; row < 20; row++)
                {
                    int c = 0;
                    for (int x = 0; x < 10; x++)
                    {
                        if (sit[row][x] == "8")
                        {
                            high = 19 - row;
                        }
                        if (sit[row][x] == "1" || sit[row][x] == "8")
                        {
                            if (highest == -7)
                            {
                                highest = row;
                                hhh = 19 - row;
                            }
                            c++;
                        }
                        if (c == 10)
                        {
                            Score += 90;//line done 50
                            hhh--;
                        }
                        if (sit[row][x] == "." && c != 0)
                        {
                            if (x == 9)
                            {
                                if (sit[row][x - 1] != ".")
                                {
                                    Score -= 35;//jumb in line 30//26
                                }
                            }
                            else
                            {
                                if (sit[row][x - 1] != "." || sit[row][x + 1] != ".")
                                {
                                    Score -= 35;//jumb in line 30//26
                                }
                            }
                        }

                    }
                }
                Score -= hhh * 30;//high 10 //19
                string[][] sitFlipped = new string[10][];
                for (int stt = 0; stt < 10; stt++)
                {
                    var col = sit.Select(x => x[stt]);
                    sitFlipped[stt] = col.ToArray();
                }
              
                for (int st = 0; st < 10; st++)
                {

                    int neib = 0;
                    bool Found = false;
                    int c = 0;
                    for (int ccc = 0; ccc < 20; ccc++)
                    {
                        if (sitFlipped[st][ccc] == "1" || sitFlipped[st][ccc] == "8")
                        {
                            Found = true;
                        }
                        if (sitFlipped[st][ccc] == "." && Found == true)
                        {
                            Score -= 40;//Empty 27
                            if (ccc != 19 && ccc != 0)
                            {
                                if (sitFlipped[st][ccc + 1] != "." || sitFlipped[st][ccc - 1] != ".")
                                {
                                    Score -= 49;//Jumb in stolbik 28 /// 49
                                }
                            }
                        }
                        if (sitFlipped[st][ccc] == "." && Found == false)
                        {
                            if (st == 0)
                            {
                                if (sitFlipped[st][ccc] != ".")
                                {
                                    neib++;
                                }
                            }
                            else
                            {
                                if (st == 9)
                                {
                                    if (sitFlipped[st][ccc] != ".")
                                    {
                                        neib++;
                                    }
                                }
                                else
                                {
                                    if (sitFlipped[st][ccc] != ".")
                                    {
                                        neib++;
                                    }
                                    if (sitFlipped[st][ccc] != ".")
                                    {
                                        neib++;
                                    }
                                }
                            }
                        }
                    }
                    if (st == 0 || st == 9)
                    {
                        if (neib > 0)//2
                        {
                            Score -= (71 / 2) * neib;//deep hole 16   ////71
                        }
                    }
                    else
                    {
                        if (neib > 0)//5
                        {
                            Score -= (71 / 5) * neib;// deep 16
                        }
                    }
                }
                results.Add(Score);
            }
            int Best = results[0];
            int num = 0;
            for (int n = 0; n < results.Count; n++)
            {
                if (results[n] > Best)
                {
                    Best = results[n];
                    num = n;
                }
            }
            print(fields[num]);
            Console.WriteLine(Best.ToString());
            Console.WriteLine(resinfo[num][0].ToString() + "   " + resinfo[num][1].ToString());
            Best_Res_Info = resinfo[num];
        }


        static void generate(int figure, string[][][] field)
        {

            List<string[][][]> Super_Results = new List<string[][][]>();

            List<string[][]> result = new List<string[][]>();
            List<int[]> resInfo = new List<int[]>();
            foreach (string[][] fil in field)
            {
                List<string[][]> _Results = new List<string[][]>();
                int[] Landhaft = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int u = 0;
                while (u < 10)
                {
                    int b = 0;
                    while (b < 20)
                    {
                        if (fil[b][u] == "1")
                        {
                            Landhaft[u] = 20 - b;
                            break;
                        }
                        b++;
                    }

                    u++;
                }
                foreach (int t in Landhaft)
                {
                    //Console.Write(t);
                }


                int exp = 0;
                int r = 0;//Rotation
                while (r < 4)//For rotation
                {
                    int x = 0;//Position
                    if (figure == 0)
                    {
                        if (r == 0 || r == 2)
                        {
                            x = 8;
                        }
                        if (r == 1 || r == 3)
                        {
                            x = 9;
                        }
                    }
                    if (figure == 1 || figure == 2)
                    {
                        if (r == 0 || r == 2)
                        {
                            x = 9;
                        }
                        if (r == 1 || r == 3)
                        {
                            x = 8;
                        }

                    }
                    if (figure == 3 || figure == 4)
                    {
                        if (r == 0)
                        {
                            x = 8;
                        }
                        if (r == 1)
                        {
                            x = 9;
                        }
                    }
                    if (figure == 5)
                    {
                        x = 9;
                    }
                    if (figure == 6)
                    {
                        if (r == 0)
                        {
                            x = 7;
                        }
                        if (r == 1)
                        {
                            x = 10;
                        }
                    }

                    int i = 0;//Curent position
                    while (i < x)
                    {
                        string[][] Non_bag = new string[20][]
                        {
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." },
                        new string[] {".",".", ".", ".", ".", ".", ".", ".", ".", "." }
                        };


                        for (int t = 0; t < 20; t++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                Non_bag[t][j] = fil[t][j];

                            }

                        }
                        result.Add(new string[0][]);
                        result[exp] = Non_bag;
                        const_check(figure, i, r);
                        int[] check_zero = ch_zer;
                        int[] check_first = ch_fir;
                        int[] check_second = ch_sec;
                        List<int> h_second = new List<int>();
                        List<int> h_first = new List<int>();
                        List<int> h_zero = new List<int>();
                        foreach (int s in check_second)
                        {
                            h_second.Add(Landhaft[s]);
                        }
                        foreach (int s in check_first)
                        {
                            h_first.Add(Landhaft[s]);
                        }
                        foreach (int s in check_zero)
                        {
                            h_zero.Add(Landhaft[s]);
                        }
                        var h_second_sort = h_second.OrderByDescending(uu => uu);
                        var h_first_sort = h_first.OrderByDescending(uu => uu);
                        var h_zero_sort = h_zero.OrderByDescending(uu => uu);
                        h_second = new List<int>();
                        h_first = new List<int>();
                        h_zero = new List<int>();
                        foreach (int q in h_second_sort)
                        {
                            h_second.Add(q);
                        }
                        foreach (int q in h_first_sort)
                        {
                            h_first.Add(q);
                        }
                        foreach (int q in h_zero_sort)
                        {

                            h_zero.Add(q);
                        }
                        List<int> H_draw = new List<int>();
                        if (h_second.Count > 0)
                        {
                            H_draw.Add(19 - h_second[0]);
                        }
                        foreach (int hh in h_first)
                        {
                        }
                        if (h_first.Count > 0)
                        {
                            H_draw.Add(19 + 1 - h_first[0]);
                        }
                        if (h_zero.Count > 0)
                        {
                            H_draw.Add(19 + 2 - h_zero[0]);
                        }
                        var H_draw_sort = H_draw.OrderBy(uu => uu);
                        H_draw = new List<int>();
                        foreach (int g in H_draw_sort)
                        {
                            H_draw.Add(g);
                        }
                        string[] minus = new string[10];
                        string[] zero = new string[10];
                        string[] second = new string[10];
                        string[] first = new string[10];
                        if (H_draw[0] > 3)
                        {
                            minus = result[exp][H_draw[0] - 3];
                        }
                        else
                        {
                            minus = new string[] { "7", "7", "7", "7", "7", "7", "7", "7", "7", "7" };
                        }
                        if (H_draw[0] > 2)
                        {
                            zero = result[exp][H_draw[0] - 2];
                        }
                        else
                        {
                            zero = new string[] { "7", "7", "7", "7", "7", "7", "7", "7", "7", "7" };
                        }
                        if (H_draw[0] > 1)
                        {
                            first = result[exp][H_draw[0] - 1];
                        }
                        else
                        {
                            first = new string[] { "7", "7", "7", "7", "7", "7", "7", "7", "7", "7" };
                        }
                        if (H_draw[0] != 20)
                        {
                            second = result[exp][H_draw[0]];
                        }
                        else
                        {
                            second = new string[] { "7", "7", "7", "7", "7", "7", "7", "7", "7", "7" };
                        }
                        string[] new_minus = new string[] { };
                        string[] new_zero = new string[] { };
                        string[] new_first = new string[] { };
                        string[] new_second = new string[] { };
                        draw(minus, zero, first, second, i, r, figure);
                        new_minus = min_drown;
                        new_zero = zer_drown;
                        new_first = fir_drown;
                        new_second = sec_drown;

                        if (H_draw[0] > 3)
                        {
                            result[exp][H_draw[0] - 3] = new_minus;
                        }
                        if (H_draw[0] > 2)
                        {
                            result[exp][H_draw[0] - 2] = new_zero;
                        }
                        if (H_draw[0] > 1)
                        {
                            result[exp][H_draw[0] - 1] = new_first;
                        }
                        if (H_draw[0] != 20)
                        {
                            result[exp][H_draw[0]] = new_second;
                        }
           
                        resInfo.Add(new int[] { i, r });
                        exp++;
                        i++;

                    }
                    if (((figure == 3 || figure == 4 || figure == 6) && (r == 1)) || (figure == 5 && r == 0))
                    {
                        break;
                    }

                    r++;
                }
                int yyy = 0;

                while (yyy < result.Count)
                {
                    _Results.Add(result[yyy]);
                    yyy++;
                }
                Super_Results.Add(_Results.ToArray());
            }
            Res_Inf_Ret = resInfo.ToArray();
            Super_Res_Ret = Super_Results.ToArray();
        }


        static void draw(string[] minus, string[] zero, string[] first, string[] second, int i, int r, int f)
        {

            switch (f)
            {
                case 1:
                    switch (r)
                    {
                        case 2:
                            zero[i] = "8";
                            zero[i + 1] = "8";
                            first[i] = "8";
                            second[i] = "8";
                            break;
                        case 3:
                            first[i] = "8";
                            first[i + 1] = "8";
                            first[i + 2] = "8";
                            second[i + 2] = "8";
                            break;
                        case 0:
                            zero[i + 1] = "8";
                            first[i + 1] = "8";
                            second[i] = "8";
                            second[i + 1] = "8";
                            break;
                        case 1:
                            first[i] = "8";
                            second[i] = "8";
                            second[i + 1] = "8";
                            second[i + 2] = "8";
                            break;
                    }
                    break;
                case 0:
                    switch (r)
                    {
                        case 2:
                            first[i + 1] = "8";
                            second[i] = "8";
                            second[i + 1] = "8";
                            second[i + 2] = "8";
                            break;
                        case 3:
                            zero[i] = "8";
                            first[i] = "8";
                            first[i + 1] = "8";
                            second[i] = "8";
                            break;
                        case 0:
                            first[i] = "8";
                            first[i + 1] = "8";
                            first[i + 2] = "8";
                            second[i + 1] = "8";
                            break;
                        case 1:
                            zero[i + 1] = "8";
                            first[i] = "8";
                            first[i + 1] = "8";
                            second[i + 1] = "8";
                            break;
                    }
                    break;
                case 2:
                    switch (r)
                    {
                        case 2:
                            zero[i] = "8";
                            zero[i + 1] = "8";
                            first[i + 1] = "8";
                            second[i + 1] = "8";
                            break;
                        case 3:
                            first[i + 2] = "8";
                            second[i] = "8";
                            second[i + 1] = "8";
                            second[i + 2] = "8";
                            break;
                        case 0:
                            zero[i] = "8";
                            first[i] = "8";
                            second[i] = "8";
                            second[i + 1] = "8";
                            break;
                        case 1:
                            first[i] = "8";
                            first[i + 1] = "8";
                            first[i + 2] = "8";
                            second[i] = "8";
                            break;

                    }
                    break;
                case 4:
                    switch (r)
                    {
                        case 1:
                            zero[i] = "8";
                            first[i] = "8";
                            first[i + 1] = "8";
                            second[i + 1] = "8";
                            break;
                        case 0:
                            first[i + 1] = "8";
                            first[i + 2] = "8";
                            second[i] = "8";
                            second[i + 1] = "8";
                            break;
                    }
                    break;
                case 3:
                    switch (r)
                    {
                        case 1:
                            zero[i + 1] = "8";
                            first[i] = "8";
                            first[i + 1] = "8";
                            second[i] = "8";
                            break;
                        case 0:
                            first[i] = "8";
                            first[i + 1] = "8";
                            second[i + 1] = "8";
                            second[i + 2] = "8";
                            break;
                    }
                    break;
                case 5:
                    first[i] = "8";
                    first[i + 1] = "8";
                    second[i] = "8";
                    second[i + 1] = "8";
                    break;
                case 6:
                    switch (r)
                    {
                        case 0:
                            first[i] = "8";
                            first[i + 1] = "8";
                            first[i + 2] = "8";
                            first[i + 3] = "8";
                            break;
                        case 1:
                            minus[i] = "8";
                            zero[i] = "8";
                            first[i] = "8";
                            second[i] = "8";
                            break;
                    }
                    break;

            }
            min_drown = minus;
            zer_drown = zero;
            fir_drown = first;
            sec_drown = second;
        }



        static void const_check(int f, int i, int r)
        {
            int[] check_zero = new int[] { };
            int[] check_first = new int[] { };
            int[] check_second = new int[] { };
            if (f == 0)
            {
                if (r == 0)
                {
                    check_first = new int[] { i, i + 2 };
                    check_second = new int[] { i + 1 };
                }
                if (r == 1)
                {
                    check_first = new int[] { i };
                    check_second = new int[] { i + 1 };
                }
                if (r == 2)
                {
                    check_first = new int[] { };
                    check_second = new int[] { i, i + 1, i + 2 };
                }
                if (r == 3)
                {
                    check_first = new int[] { i + 1 };
                    check_second = new int[] { i };
                }
            }
            if (f == 1)
            {
                if (r == 2)
                {
                    check_zero = new int[] { i + 1 };
                    check_second = new int[] { i };
                }
                if (r == 3)
                {
                    check_first = new int[] { i, i + 1 };
                    check_second = new int[] { i + 2 };
                }
                if (r == 0)
                {
                    check_second = new int[] { i, i + 1 };
                }
                if (r == 1)
                {
                    check_second = new int[] { i, i + 1, i + 2 };
                }
            }
            if (f == 2)
            {
                if (r == 2)
                {
                    check_zero = new int[] { i };
                    check_second = new int[] { i + 1 };
                }
                if (r == 3)
                {

                    check_second = new int[] { i, i + 1, i + 2 };
                }
                if (r == 0)
                {

                    check_second = new int[] { i, i + 1 };
                }
                if (r == 1)
                {
                    check_first = new int[] { i + 1, i + 2 };
                    check_second = new int[] { i };
                }
            }
            if (f == 3)
            {
                if (r == 1)
                {
                    check_first = new int[] { i + 1 };
                    check_second = new int[] { i };
                }
                if (r == 0)
                {
                    check_first = new int[] { i };
                    check_second = new int[] { i + 1, i + 2 };
                }

            }
            if (f == 4)
            {
                if (r == 1)
                {
                    check_first = new int[] { i };
                    check_second = new int[] { i + 1 };
                }
                if (r == 0)
                {
                    check_first = new int[] { i + 2 };
                    check_second = new int[] { i, i + 1 };
                }

            }
            if (f == 5)
            {
                check_second = new int[] { i, i + 1 };
            }
            if (f == 6)
            {
                if (r == 0)
                {
                    check_first = new int[] { i, i + 1, i + 2, i + 3 };
                }
                if (r == 1)
                {
                    check_second = new int[] { i };
                }
            }


            ch_zer = check_zero;
            ch_fir = check_first;
            ch_sec = check_second;

        }





        static string print(string[][] Stakan)
        {
            string strBoard = "________"+Environment.NewLine;
            for (int i = 3; i < Stakan.Length; i++)
            {
                strBoard += "|";
                for (int g = 0; g < Stakan[i].Length; g++)
                {
                    if (Stakan[i][g].ToString() == "1")
                        strBoard += "#";
                    else
                        strBoard += " ";
                   
                }
                strBoard += "|"+ Environment.NewLine;

            }
            strBoard += "‾‾‾‾‾‾‾‾‾‾";
            return strBoard;
        }
    }
}
