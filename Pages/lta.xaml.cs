using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace 预彩精灵.Pages
{
    /// <summary>
    /// Interaction logic for lta.xaml
    /// </summary>
    public partial class lta : UserControl
    {
        public ObservableCollection<ResolveHelper> ResultHelper = new ObservableCollection<ResolveHelper>();
        List<tempResolveHelp> Result = new List<tempResolveHelp>();
        private char AnalysisBasketflag;
        private char AnalysisKeyword;
        int coldBound = 0;
        string[,] CommonAnalsisAnrry = new string[8 * 56, 2];
        string[,] tempBasketFiveAnrry = new string[8 * 56, 2];
        string[,] tempBasketFourAnrry0 = new string[8 * 56, 2];
        string[,] tempBasketFourAnrry9 = new string[8 * 56, 2];
        string[,] tempBasketFourAnrry09 = new string[8 * 28, 2];
        string[,] tempBasketThreeAnrry0 = new string[8 * 7, 2];
        string[,] tempBasketThreeAnrry9 = new string[8 * 7, 2];
        string[,] tempBasketThreeAnrry09 = new string[8 * 8, 2];
        string[,] tempBasketTwoAnrry0 = new string[8 * 8, 2];
        string[,] tempBasketTwoAnrry9 = new string[8 * 8, 2];
        public class ResolveHelper
        {
            public string AlgorithmFormula { get; set; }
            public string KuangNum { get; set; }
            public string ResultNum { get; set; }
            public int ColdTime { get; set; }

         }
        public class tempResolveHelp
        {
            public string AlgorithmFormula;
            public int coldTime;
            public string KuangNum;
            public string ResultNum;
            public tempResolveHelp(int coldtime,string AlgorithmFormula,string kuangnum,string ResultNum )
            {
                this.AlgorithmFormula = AlgorithmFormula;
                this.coldTime = coldtime;
                this.KuangNum = kuangnum;
                this.ResultNum = ResultNum;
            }
        }

        public static string InnerCacu (string srcstr, int num)
        {
            char[] StrChar = srcstr.ToCharArray();
            char[] ResultChar = new char[StrChar.Length];
            string ResultString = "";
            try
            {
                for (int i = 0; i < StrChar.Length; i++)
                {
                    if (num > StrChar[i] - 48)
                    {
                        ResultChar[i] = Convert.ToChar(StrChar[i] - 38 - num);
                    }
                    else if (num < StrChar[i] - 48)
                    {
                        ResultChar[i] = Convert.ToChar(StrChar[i] - 48 - num);
                    }
                }
                for (int j = 0; j < StrChar.Length; j++)
                {
                    ResultChar[j] = Convert.ToChar(ResultChar[j] + 48);
                }
                 ResultString = new string(ResultChar);

            }
            catch (Exception ex)
            {
                mainDialog.ShowMessage(ex.Message, "温馨提示：", MessageBoxButton.OK, null);
            }
            return ResultString;
        }
       
        public lta()
        {
                InitializeComponent();
                mainDialog dia = new mainDialog();
                prb.Visibility = System.Windows.Visibility.Collapsed;
                try
                {
                    StreamReader srBasketFiveAnrry = new StreamReader("BasketNum/BasketNum_Five.txt", false);
                    StreamReader srBasketFourAnrry = new StreamReader("BasketNum/BasketNum_Four.txt", false);
                    StreamReader srBasketThreeAnrry = new StreamReader("BasketNum/BasketNum_Three.txt", false);
                    StreamReader srBasketTwoAnrry = new StreamReader("BasketNum/BasketNum_Two.txt", false);
                    int tmpCount = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketFiveAnrry = srBasketFiveAnrry.ReadLine();
                        string strBasketFourAnrry0 = srBasketFourAnrry.ReadLine();
                        string[] SplitBasketFiveAnrry = strBasketFiveAnrry.Split(',');
                        string[] SplitBasketFourAnrry0 = strBasketFourAnrry0.Split(',');
                        for (int n = 0; n < 56; n++)
                        {
                            tempBasketFourAnrry0[tmpCount, 0] = SplitBasketFourAnrry0[n];
                            tempBasketFourAnrry0[tmpCount, 1] = "0";
                            tempBasketFiveAnrry[tmpCount, 0] = SplitBasketFiveAnrry[n];
                            tempBasketFiveAnrry[tmpCount, 1] = "0";
                            tmpCount++;
                        }
                    }
                    int tmpCount0 = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketFourAnrry9 = srBasketFourAnrry.ReadLine();
                        string[] SplitBasketFourAnrry9 = strBasketFourAnrry9.Split(',');
                        for (int n = 0; n < 56; n++)
                        {
                            tempBasketFourAnrry9[tmpCount0, 0] = SplitBasketFourAnrry9[n];
                            tempBasketFourAnrry9[tmpCount0, 1] = "0";
                            tmpCount0++;
                        }
                    }
                    int tmpCount1 = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketFourAnrry09 = srBasketFourAnrry.ReadLine();
                        string[] SplitBasketFourAnrry09 = strBasketFourAnrry09.Split(',');
                        for (int n = 0; n < 28; n++)
                        {
                            tempBasketFourAnrry09[tmpCount1, 0] = SplitBasketFourAnrry09[n];
                            tempBasketFourAnrry09[tmpCount1, 1] = "0";
                            tmpCount1++;
                        }
                    }

                    int tmpCount2 = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketThreeAnrry = srBasketThreeAnrry.ReadLine();
                        string[] SplitBasketThreeAnrry = strBasketThreeAnrry.Split(',');
                        for (int n = 0; n < 7; n++)
                        {
                            tempBasketThreeAnrry0[tmpCount2, 0] = SplitBasketThreeAnrry[n];
                            tempBasketThreeAnrry0[tmpCount2, 1] = "0";
                            tmpCount2++;
                        }
                    }
                    int tmpCount3 = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketThreeAnrry = srBasketThreeAnrry.ReadLine();
                        string[] SplitBasketThreeAnrry = strBasketThreeAnrry.Split(',');
                        for (int n = 0; n < 7; n++)
                        {
                            tempBasketThreeAnrry9[tmpCount3, 0] = SplitBasketThreeAnrry[n];
                            tempBasketThreeAnrry9[tmpCount3, 1] = "0";
                            tmpCount3++;
                        }
                    }
                    int tmpCount4 = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketThreeAnrry = srBasketThreeAnrry.ReadLine();
                        string[] SplitBasketThreeAnrry = strBasketThreeAnrry.Split(',');
                        for (int n = 0; n < 8; n++)
                        {
                            tempBasketThreeAnrry09[tmpCount4, 0] = SplitBasketThreeAnrry[n];
                            tempBasketThreeAnrry09[tmpCount4, 1] = "0";
                            tmpCount4++;
                        }
                    }
                    int tmpCount5 = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketTwoAnrry = srBasketTwoAnrry.ReadLine();
                        string[] SplitBasketTwoAnrry = strBasketTwoAnrry.Split(',');
                        for (int n = 0; n < 8; n++)
                        {
                            tempBasketTwoAnrry0[tmpCount5, 0] = SplitBasketTwoAnrry[n];
                            tempBasketTwoAnrry0[tmpCount5, 1] = "0";
                            tmpCount5++;
                        }
                    }
                    int tmpCount6 = 0;
                    for (int m = 0; m < 8; m++)
                    {
                        string strBasketTwoAnrry = srBasketTwoAnrry.ReadLine();
                        string[] SplitBasketTwoAnrry = strBasketTwoAnrry.Split(',');
                        for (int n = 0; n < 8; n++)
                        {
                            tempBasketTwoAnrry9[tmpCount6, 0] = SplitBasketTwoAnrry[n];
                            tempBasketTwoAnrry9[tmpCount6, 1] = "0";
                            tmpCount6++;
                        }
                    }
                    srBasketTwoAnrry.Close();
                    srBasketThreeAnrry.Close();
                    srBasketFourAnrry.Close();
                    srBasketFiveAnrry.Close();

                }
                catch (Exception ex)
                {
                    mainDialog.ShowMessage(ex.Message, "温馨提示：", MessageBoxButton.OK, null);
                }


        }
       

        private void StartCulc_Click(object sender, RoutedEventArgs e)
        {
            prb.Visibility = System.Windows.Visibility.Visible;
            prb.IsIndeterminate = true;
            //AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);       
            prb.Visibility = System.Windows.Visibility.Collapsed;
            prb.IsIndeterminate = false;
        }

        private void StopCulc_Click(object sender, RoutedEventArgs e)
        {
            prb.Visibility = System.Windows.Visibility.Collapsed;
            prb.IsIndeterminate = false;
        }

        private void SetupBtn_Click(object sender, RoutedEventArgs e)
        {
            mainDialog dia = new mainDialog();
            Button closeBtn = dia.CloseButton;
            closeBtn.Visibility = Visibility.Collapsed;//先关闭按钮的显示
            dia.ShowDialog();
        }


        private void AnalysisUnitFunction(char Analysisflag, char AnalysisBasketflag)
        {
            ResultHelper.Clear();
            Result.Clear();
            ReslutTable.DataContext = ResultHelper;

                try
                {
                    Home.AnalysisTempMember = Home.memberDat.ToList();

                    int rowElementNum = 56;
                    switch (AnalysisBasketflag)
                    {
                        case '1'://五个数的筐
                            coldBound = mainDialog.FivecoldBound;
                            rowElementNum = 56;
                            CommonAnalsisAnrry = tempBasketFiveAnrry;
                            break;
                        case '0'://四个数的筐
                            coldBound = mainDialog.FivecoldBound;
                            rowElementNum = 56;
                            CommonAnalsisAnrry = tempBasketFourAnrry0;
                            break;
                        case '9':
                            coldBound = mainDialog.FourcoldBound;
                            rowElementNum = 56;
                            CommonAnalsisAnrry = tempBasketFourAnrry9;
                            break;
                        case '2':
                            {
                                coldBound = mainDialog.FourcoldBound;
                                rowElementNum = 28;
                                CommonAnalsisAnrry = tempBasketFourAnrry09;
                            }
                            break;
                        case '3'://三个数的筐附加一个得0
                            {
                                coldBound = mainDialog.ThreecoldBound;
                                rowElementNum = 7;
                                CommonAnalsisAnrry = tempBasketThreeAnrry0;
                            }
                            break;
                        case '4'://三个数的筐附加一个的得9
                            {
                                coldBound = mainDialog.ThreecoldBound;
                                rowElementNum = 7;
                                CommonAnalsisAnrry = tempBasketThreeAnrry9;
                            }
                            break;
                        case '5'://三个数的筐附加一个的得0,9
                            {
                                coldBound = mainDialog.ThreecoldBound;
                                rowElementNum = 8;
                                CommonAnalsisAnrry = tempBasketThreeAnrry09;
                            }
                            break;
                        case '6'://两个数的筐同时附加一个的0
                            {
                                coldBound = mainDialog.TwocoldBound;
                                rowElementNum = 8;
                                CommonAnalsisAnrry = tempBasketTwoAnrry0;
                            }
                            break;
                        case '7'://两个数的筐同时附加一个的9
                            {
                                coldBound = mainDialog.TwocoldBound;
                                rowElementNum = 8;
                                CommonAnalsisAnrry = tempBasketTwoAnrry9;
                            }
                            break;
                        default:
                            break;
                    }
                    for (int tmpi0 = 0; tmpi0 < CommonAnalsisAnrry.GetLength(0); tmpi0++)
                    {
                        CommonAnalsisAnrry[tmpi0, 1] = "0";
                    }

                    //int AnalysisNum = 9;
                    int AnalysisBoundA = mainDialog.StartIndexNum, AnalysisBoundB = mainDialog.EndIndexNum;
                    //string[,] tempZeroAnrry = new string[1,56];
                    //for (int QiShu = 0; QiShu < (AnalysisBoundB - AnalysisBoundA) - AnalysisNum; QiShu++)
                    //{
                    //    BaseBound = BaseBound - 1;
                    if (Home.AnalysisTempMember.Count < (AnalysisBoundB - AnalysisBoundA))
                    {
                        mainDialog.ShowMessage("可依据参考的期数太少，无法分析！", "温馨提示：", MessageBoxButton.OK, null);
                    }
                    else
                    {
                        for (int i = AnalysisBoundA; i <= AnalysisBoundB; i++)
                        {
                            int tmp = 0;

                            for (int k = 0; k < 4; k++)//A,B,C,D轮一遍
                            {
                                int tmp1 = 0;
                                switch (k)
                                {
                                    case 0:
                                        tmp1 = Home.AnalysisTempMember[i].elea;
                                        string AlgorithmFormula = "";
                                        string AlgorithmFormula0 = "A" + Convert.ToString(i) + "(" + Convert.ToString(tmp1) + ")";
                                        int coldTime = 0;//连续没有掉进筐中的次数
                                        for (int BaseBound = 0; BaseBound < Home.AnalysisTempMember.Count - 1; BaseBound++)
                                        {
                                            string a = Home.AnalysisTempMember[BaseBound].Num;
                                            char b = Convert.ToChar(tmp1 + 48);
                                            int index = a.IndexOf(b);
                                            int basebound = 0;
                                            basebound = BaseBound + 9;
                                            if (BaseBound > Home.AnalysisTempMember.Count - 1 - 9)
                                                basebound = Home.AnalysisTempMember.Count - 1;
                                            if (index == 0)
                                            {
                                                coldTime++;
                                                switch (Analysisflag)
                                                {
                                                    case 'A':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elea;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+A";
                                                        break;
                                                    case 'B':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eleb;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+B";
                                                        break;
                                                    case 'C':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elec;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+C";
                                                        break;
                                                    case 'D':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eled;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+D";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                if (tmp >= 10)
                                                {
                                                    tmp = tmp % 10;
                                                }
                                                for (int j = 0; j < rowElementNum; j++)
                                                {
                                                    string a0 = CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 0];
                                                    //temp = InnerCacu(a, Home.TempMember[i].elea);
                                                    char b0 = Convert.ToChar(tmp + 48);
                                                    int index0 = a0.IndexOf(b0);
                                                    if (index0 != -1)
                                                    {
                                                        int count = Convert.ToInt32(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1]);
                                                        count = count + 1;
                                                        CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1] = Convert.ToString(count);
                                                    }
                                                }
                                            }
                                        }
                                        for (int tmpi = 0; tmpi < rowElementNum; tmpi++)
                                        {
                                            if (CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 1] == "0")
                                            {
                                                Result.Add(new tempResolveHelp(coldTime, AlgorithmFormula, CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], InnerCacu(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], tmp1)));
                                            }
                                            //CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 1] = "0";
                                        }

                                        break;
                                    case 1:
                                        tmp1 = Home.AnalysisTempMember[i].eleb;
                                        AlgorithmFormula = "";
                                        AlgorithmFormula0 = "B" + Convert.ToString(i) + "(" + Convert.ToString(tmp1) + ")";
                                        coldTime = 0;//连续没有掉进筐中的次数
                                        for (int BaseBound = 0; BaseBound < Home.AnalysisTempMember.Count - 1; BaseBound++)
                                        {

                                            string a = Home.AnalysisTempMember[BaseBound].Num;
                                            //temp = InnerCacu(a, Home.TempMember[i].elea);
                                            char b = Convert.ToChar(tmp1 + 48);
                                            int index = a.IndexOf(b);
                                            int basebound = 0;
                                            basebound = BaseBound + 9;
                                            if (BaseBound > Home.AnalysisTempMember.Count - 1 - 9)
                                                basebound = Home.AnalysisTempMember.Count - 1;
                                            if (index == 1)
                                            {
                                                coldTime++;
                                                switch (Analysisflag)
                                                {
                                                    case 'A':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elea;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+A";
                                                        break;
                                                    case 'B':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eleb;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+B";
                                                        break;
                                                    case 'C':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elec;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+C";
                                                        break;
                                                    case 'D':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eled;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+D";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                if (tmp >= 10)
                                                {
                                                    tmp = tmp % 10;
                                                }
                                                for (int j = 0; j < rowElementNum; j++)
                                                {
                                                    string a0 = CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 0];
                                                    //temp = InnerCacu(a, Home.TempMember[i].elea);
                                                    char b0 = Convert.ToChar(tmp + 48);
                                                    int index0 = a0.IndexOf(b0);
                                                    if (index0 != -1)
                                                    {
                                                        int count = Convert.ToInt32(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1]);
                                                        count = count + 1;
                                                        CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1] = Convert.ToString(count);
                                                    }
                                                }
                                            }
                                        }
                                        for (int tmpi = 0; tmpi < rowElementNum; tmpi++)
                                        {
                                            if (CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 1] == "0")
                                            {
                                                Result.Add(new tempResolveHelp(coldTime, AlgorithmFormula, CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], InnerCacu(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], tmp1)));
                                            }
                                        }

                                        break;
                                    case 2:
                                        tmp1 = Home.AnalysisTempMember[i].elec;
                                        AlgorithmFormula = "";
                                        AlgorithmFormula0 = "C" + Convert.ToString(i) + "(" + Convert.ToString(tmp1) + ")";
                                        coldTime = 0;//连续没有掉进筐中的次数
                                        for (int BaseBound = 0; BaseBound < Home.AnalysisTempMember.Count - 1; BaseBound++)
                                        {

                                            string a = Home.AnalysisTempMember[BaseBound].Num;
                                            //temp = InnerCacu(a, Home.TempMember[i].elea);
                                            char b = Convert.ToChar(tmp1 + 48);
                                            int index = a.IndexOf(b);
                                            int basebound = 0;
                                            basebound = BaseBound + 9;
                                            if (BaseBound > Home.AnalysisTempMember.Count - 1 - 9)
                                                basebound = Home.AnalysisTempMember.Count - 1;
                                            if (index == 2)
                                            {
                                                coldTime++;
                                                switch (Analysisflag)
                                                {
                                                    case 'A':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elea;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+A";
                                                        break;
                                                    case 'B':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eleb;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+B";
                                                        break;
                                                    case 'C':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elec;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+C";
                                                        break;
                                                    case 'D':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eled;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+D";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                if (tmp >= 10)
                                                {
                                                    tmp = tmp % 10;
                                                }
                                                for (int j = 0; j < rowElementNum; j++)
                                                {
                                                    string a0 = CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 0];
                                                    //temp = InnerCacu(a, Home.TempMember[i].elea);
                                                    char b0 = Convert.ToChar(tmp + 48);
                                                    int index0 = a0.IndexOf(b0);
                                                    if (index0 != -1)
                                                    {
                                                        int count = Convert.ToInt32(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1]);
                                                        count = count + 1;
                                                        CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1] = Convert.ToString(count);
                                                    }
                                                }
                                            }
                                        }
                                        for (int tmpi = 0; tmpi < rowElementNum; tmpi++)
                                        {
                                            if (CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 1] == "0")
                                            {
                                                Result.Add(new tempResolveHelp(coldTime, AlgorithmFormula, CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], InnerCacu(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], tmp1)));
                                            }
                                        }
                                        break;
                                    case 3:
                                        tmp1 = Home.AnalysisTempMember[i].eled;
                                        AlgorithmFormula = "";
                                        AlgorithmFormula0 = "D" + Convert.ToString(i) + "(" + Convert.ToString(tmp1) + ")";
                                        coldTime = 0;//连续没有掉进筐中的次数
                                        for (int BaseBound = 0; BaseBound < Home.AnalysisTempMember.Count - 1; BaseBound++)
                                        {

                                            string a = Home.AnalysisTempMember[BaseBound].Num;
                                            //temp = InnerCacu(a, Home.TempMember[i].elea);
                                            char b = Convert.ToChar(tmp1 + 48);
                                            int index = a.IndexOf(b);
                                            int basebound = 0;
                                            basebound = BaseBound + 9;
                                            if (BaseBound > Home.AnalysisTempMember.Count - 1 - 9)
                                                basebound = Home.AnalysisTempMember.Count - 1;
                                            if (index == 3)
                                            {
                                                coldTime++;
                                                switch (Analysisflag)
                                                {
                                                    case 'A':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elea;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+A";
                                                        break;
                                                    case 'B':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eleb;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+B";
                                                        break;
                                                    case 'C':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].elec;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+C";
                                                        break;
                                                    case 'D':
                                                        tmp = tmp1 + Home.AnalysisTempMember[basebound].eled;
                                                        AlgorithmFormula = AlgorithmFormula0 + "+D";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                                if (tmp >= 10)
                                                {
                                                    tmp = tmp % 10;
                                                }
                                                for (int j = 0; j < rowElementNum; j++)
                                                {
                                                    string a0 = CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 0];
                                                    //temp = InnerCacu(a, Home.TempMember[i].elea);
                                                    char b0 = Convert.ToChar(tmp + 48);
                                                    int index0 = a0.IndexOf(b0);
                                                    if (index0 != -1)
                                                    {
                                                        int count = Convert.ToInt32(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1]);
                                                        count = count + 1;
                                                        CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + j, 1] = Convert.ToString(count);
                                                    }
                                                }
                                            }
                                        }
                                        for (int tmpi = 0; tmpi < rowElementNum; tmpi++)
                                        {
                                            if (CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 1] == "0")
                                            {
                                                Result.Add(new tempResolveHelp(coldTime, AlgorithmFormula, CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], InnerCacu(CommonAnalsisAnrry[(tmp1 - 1) * rowElementNum + tmpi, 0], tmp1)));
                                            }
                                        }

                                        break;
                                    default:
                                        break;
                                }

                                for (int tmpk = 0; tmpk < CommonAnalsisAnrry.GetLength(0); tmpk++)
                                {
                                    CommonAnalsisAnrry[tmpk, 1] = "0";
                                }

                            }
                        }
                        //前端显示
                        for (int tmpi = coldBound; tmpi < Result.Count; tmpi++)
                        {
                            if (Result[tmpi].coldTime >= coldBound)
                            {
                                ResultHelper.Add(new ResolveHelper() { AlgorithmFormula = Result[tmpi].AlgorithmFormula, KuangNum = Result[tmpi].KuangNum, ResultNum = Result[tmpi].ResultNum, ColdTime = Result[tmpi].coldTime });
                            }
                        }
                        //按照ColdTime大小排序
                        var tempResultRanked = from resluthelp in ResultHelper
                                               orderby resluthelp.ColdTime
                                               select resluthelp;
                        ResultHelper = new ObservableCollection<ResolveHelper>(tempResultRanked);
                        List<ResolveHelper> tmpZeroList = ResultHelper.Reverse().ToList();//数据反转，连续次数多的在最上面
                        ResultHelper.Clear();
                        for (int i = 0; i < tmpZeroList.Count; i += 1)
                        {
                            ResultHelper.Add(tmpZeroList[i]);
                        }
                        ReslutTable.DataContext = ResultHelper;

                    }

                }
                catch (Exception ex)
                {
                    mainDialog.ShowMessage(ex.Message, "温馨提示：", MessageBoxButton.OK, null);
                }
        }
        #region
        //A
        private void AfiveNumTrend_Selected(object sender, RoutedEventArgs e)
        {           
            AnalysisKeyword='A';
            AnalysisBasketflag = '1';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);            
        }

        private void AfourNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '2';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void AfourNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '9';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void AfourNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '0';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void AthreeNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '5';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void AthreeNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '4';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void AthreeNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '3';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void AtwoNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '7';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void AtwoNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'A';
            AnalysisBasketflag = '6';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }



          
        #endregion
        #region
        //B
        private void BfiveNumTrend_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '1';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BfourNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '2';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BfourNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '9';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BfourNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '0';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BthreeNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '5';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BthreeNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '4';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BthreeNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '3';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BtwoNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '7';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void BtwoNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'B';
            AnalysisBasketflag = '6';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        #endregion
        #region
        //C
        private void CfiveNumTrend_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '1';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CfourNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '2';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CfourNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '9';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CfourNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '0';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CthreeNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '5';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CthreeNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '4';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CthreeNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '3';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CtwoNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '7';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void CtwoNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'C';
            AnalysisBasketflag = '6';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }
        #endregion
        #region
        //D
        private void DfiveNumTrend_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '1';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DfourNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '2';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DfourNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '9';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DfourNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '0';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DthreeNumTrend09_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '5';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DthreeNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '4';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DthreeNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '3';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DtwoNumTrend9_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '7';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        private void DtwoNumTrend0_Selected(object sender, RoutedEventArgs e)
        {
            AnalysisKeyword = 'D';
            AnalysisBasketflag = '6';
            AnalysisUnitFunction(AnalysisKeyword, AnalysisBasketflag);
        }

        #endregion
    }

}
