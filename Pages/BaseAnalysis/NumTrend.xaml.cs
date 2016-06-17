using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
namespace 预彩精灵.Pages
{
    /// <summary>
    /// Interaction logic for NumTrend.xaml
    /// </summary>
    public partial class NumTrend : UserControl
    {
        public ObservableCollection<BaseT> BaseTrend = new ObservableCollection<BaseT>();

        public class BaseT
        {
            public int Snum { get; set; }
            public string Numdate { get; set; }
            public string Num { get; set; }
            public int eleone { get; set; }
            public int eletwo { get; set; }
            public int elethree { get; set; }
            public int elefour { get; set; }
            public int elefive { get; set; }
            public int elesix { get; set; }
            public int eleseven { get; set; }
            public int eleeight { get; set; }
        }
        public NumTrend()
        {
            InitializeComponent();          
        }

        private void NumTrendWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            CountNum();
        }

        private void NumTrendWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BaseTrend.Clear();
            ReTable.DataContext = BaseTrend;
        }

        private void CountNum()
        {
            BaseTrend.Clear();
            List<Home.Member> temp_Memdat = Home.memberDat.ToList();
            int eleone = 0, eletwo = 0, elethree = 0, elefour = 0, elefive = 0, elesix = 0, eleseven = 0, eleeight = 0, temp = 0;
            int CountNum = 0;
            if ((bool)AChBox.IsChecked)
                CountNum = 1; ;
            if ((bool)BChBox.IsChecked)
                CountNum = 2;
            if ((bool)CChBox.IsChecked)
                CountNum = 3;
            if ((bool)DChBix.IsChecked)
                CountNum = 4;          
            for (int i = 0; i < temp_Memdat.Count; i++)
            {
                for (int j = 0; j < CountNum; j++)
                {
                    if (j == 0 && (bool) AChBox.IsChecked)
                        temp = temp_Memdat[i].elea;
                    if (j == 1 && (bool) BChBox.IsChecked)
                        temp = temp_Memdat[i].eleb;
                    if (j == 2 && (bool) CChBox.IsChecked)
                        temp = temp_Memdat[i].elec;
                    if (j == 3 && (bool) DChBix.IsChecked)
                        temp = temp_Memdat[i].eled;
                    switch (temp)
                    {
                        case 1:
                            eleone++;
                            break;
                        case 2:
                            eletwo++;
                            break;
                        case 3:
                            elethree++;
                            break;
                        case 4:
                            elefour++;
                            break;
                        case 5:
                            elefive++;
                            break;
                        case 6:
                            elesix++;
                            break;
                        case 7:
                            eleseven++;
                            break;
                        case 8:
                            eleeight++;
                            break;
                        default:
                            break;
                    }
                    temp = 0;
                }
                BaseTrend.Add(new BaseT() { Snum = temp_Memdat[i].Snum, Numdate = temp_Memdat[i].Numdate, Num = temp_Memdat[i].Num, eleone = eleone, eletwo = eletwo, elethree = elethree, elefour = elefour, elefive = elefive, elesix = elesix, eleseven = eleseven, eleeight = eleeight });
            }
            ReTable.DataContext = BaseTrend;
        }




    }
}
