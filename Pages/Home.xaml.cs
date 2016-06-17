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
using System.Text.RegularExpressions;
using System.Xml;
using System.Data;
using System.IO;
using System.Collections;
using System.Net;
using System.Threading;
using System.Windows.Threading;




namespace 预彩精灵.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public static ObservableCollection<Member> memberDat = new ObservableCollection<Member>();
        public static List<Member> TempMember = new List<Member>();
        public static List<Member> AnalysisTempMember = new List<Member>();
        bool FirstLoadxml = true;
        bool IsAllDataMode = true;
        public class Member
        {
            public int Snum { get; set; }
            public string Numdate { get; set; }
            public string Num { get; set; }
            public int elea { get; set; }
            public int eleb { get; set; }
            public int elec { get; set; }
            public int eled { get; set; }
        }
        public Home()
        {           
            InitializeComponent();
            if (!Directory.Exists("xml"))
            {
                Directory.CreateDirectory("xml");
            }
            GetNetDataPro.Visibility = System.Windows.Visibility.Collapsed;
            LoadUpdateCombo();
        }
        private void LoadUpdateCombo()
        {
            try
            {
                DirectoryInfo theFolder = new DirectoryInfo("xml/");
                FileInfo[] fileinfo = theFolder.GetFiles();
                List<string> fileinfoList = new List<string>();
                foreach (FileInfo fo in fileinfo)
                {
                    fileinfoList.Add(fo.Name.Replace(".xml",""));
                }
                combob.ItemsSource = fileinfoList;
                combob.SelectedIndex = 0;
                if (fileinfoList.Count != 0)
                {
                    LoadXmlFile(fileinfoList[0]);
                }else
                {
                    memberDat.Clear();
                    NumTable.DataContext = memberDat;
                }

            }
            catch (Exception ex)
            {
                mainDialog.ShowMessage(ex.Message, "温馨提示：", MessageBoxButton.OK, null);
            }
        }
        private void LoadXmlFile(string FileName)
        {
            if (!FirstLoadxml)
            {
                memberDat.Clear();
            }
            else if(FirstLoadxml)
            {
                FirstLoadxml = false;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create("xml/" + FileName+".xml", settings);
                doc.Load(reader);
                reader.Close();
                XmlNode xn = doc.SelectSingleNode("lottry");
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode xn1 in xnl)
                {
                    XmlElement xe = (XmlElement)xn1;
                    string Snum = xe.GetAttribute("Snum");
                    XmlNodeList xn10 = xe.ChildNodes;
                    string Numdate = xn10.Item(0).InnerText;
                    string Num = xn10.Item(1).InnerText;
                    char[] ss = Num.ToCharArray();
                    memberDat.Add(new Member() { Snum = Convert.ToInt32(Snum), Numdate = Numdate, Num = Num, elea = Convert.ToInt32(ss[0]) - 48, eleb = Convert.ToInt32(ss[1]) - 48, elec = Convert.ToInt32(ss[2]) - 48, eled = Convert.ToInt32(ss[3]) - 48 });
                }
                NumTable.DataContext = memberDat;
                TempMember = memberDat.ToList(); //拷贝一份数据的副本
            }
            catch (XmlException ex)//load异常
            {
                mainDialog.ShowMessage(ex.Message, "温馨提示：", MessageBoxButton.OK, null);
            }
            catch (FileNotFoundException ex)//XmlReader.Create异常
            {
                mainDialog.ShowMessage(ex.Message, "温馨提示：", MessageBoxButton.OK, null);
            }
        }
        private void Add_Number_btn_Click(object sender, RoutedEventArgs e)
        {
            string temp0 = "";
            Num_tbox.Focus();
            if (IsAllDataMode)
            {

                try
                {
                    if (Dp.Text != "")
                    {
                        string temp = Dp.Text.Replace("/", "");
                        temp0 = temp.Replace("-", "");//兼容WIN XP
                    }
                    if (Num_tbox.Text == "")
                    {
                        mainDialog.ShowMessage("请输入本期号码！", "温馨提示：", MessageBoxButton.OK, null);
                    }
                    else if (Dp.Text != "")
                    {
                        char[] ss = Num_tbox.Text.ToCharArray();
                        if (combob.Text != "")
                        {
                            memberDat.Add(new Member() { Snum = memberDat.Count(), Numdate = temp0, Num = Num_tbox.Text, elea = Convert.ToInt32(ss[0]) - 48, eleb = Convert.ToInt32(ss[1]) - 48, elec = Convert.ToInt32(ss[2]) - 48, eled = Convert.ToInt32(ss[3]) - 48 });
                            NumTable.DataContext = memberDat;
                            TempMember = memberDat.ToList(); //拷贝一份数据的副本
                            AppendLottryData();
                            NumTable.ScrollIntoView(TempMember[TempMember.Count-1]);//让DATAGRID滚动到最下面
                        }
                        else
                        {
                            mainDialog.ShowMessage("还没有创建记录！", "温馨提示：", MessageBoxButton.OK, null);
                        }
                    }
                    else
                    {
                        mainDialog.ShowMessage("请选择本期日期！", "温馨提示：", MessageBoxButton.OK, null);

                    }

                }
                catch
                {
                    mainDialog.ShowMessage("请输入正确的期号！", "温馨提示：", MessageBoxButton.OK, null);
                }
            }
            else
            {
                mainDialog.ShowMessage("请点击[全部数据]按钮切换模式", "温馨提示：", MessageBoxButton.OK, null);
            }
            Num_tbox.Text = "";
        }
        private void Num_tbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach(char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true ;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
        private void DleNum_btn_Click(object sender, RoutedEventArgs e)
        {
            if (IsAllDataMode)
            {
                try
                {
                    #region
                    //多项删除功能区
                    MessageBoxResult result;
                    result = mainDialog.ShowMessage("是否删除所选内容？", "温馨提示：", MessageBoxButton.OKCancel, null);
                    if (result == MessageBoxResult.OK)
                    {
                        var aa = NumTable.SelectedItems;
                        List<Member> tempDele = new List<Member>();
                        foreach (Member a in aa)
                        {
                            tempDele.Add(a);
                        }
                        for (int i = 0; i < tempDele.Count; i++)
                        {
                            for (int j = 0; j < memberDat.Count; j++)
                            {
                                if (memberDat.ElementAt(j).Equals(tempDele[i]))
                                {
                                    memberDat.RemoveAt(j);
                                    break;
                                }
                            }

                        }                        
                    }
                    #endregion
                    for (int i = 0; i < memberDat.Count(); i++)//替换Snum
                    {
                        Member mem = memberDat.ElementAt(i);
                        memberDat.RemoveAt(i);
                        mem.Snum = i;
                        memberDat.Insert(i, mem);
                    }
                    AppendLottryData();//序列化到本地
                    NumTable.DataContext = memberDat;
                    TempMember = memberDat.ToList(); //拷贝一份数据的副本
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    mainDialog.ShowMessage(ex.Message, "温馨提示：", MessageBoxButton.OK, null);
                }

            }
            else
            {
                mainDialog.ShowMessage("请点击[全部数据]按钮切换模式", "温馨提示：", MessageBoxButton.OK, null);
            }
            
        }
        public void AppendLottryData()
        {
            List<Member> memList = memberDat.ToList();
            if (memList.Count != 0)
            {
                Member me = memberDat.ElementAt(memList.Count-1);
                string date = "";
                //日期纪录命名规范化
                if (me.Numdate.Length == 6 || me.Numdate.Length == 7 || (me.Numdate.Length == 8 && me.Numdate[0] == '2' && me.Numdate[1] == '0'))
                {
                    date = me.Numdate;
                }
                else if (me.Numdate.Length == 8)
                {
                    date = me.Numdate.Remove(6);
                }

                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.IgnoreComments = true;
                    XmlReader reader = XmlReader.Create("xml/" + date + ".xml", settings);
                    doc.Load(reader);
                    reader.Close();
                    XmlNode root = doc.SelectSingleNode("lottry");//找到根节点               
                    root.RemoveAll();
                    foreach (Member mem in memList)
                    {
                        XmlElement xelLottryNum = doc.CreateElement("LottryNum");//找到节点
                        XmlAttribute xelSnum = doc.CreateAttribute("Snum");//创建节点的属性
                        xelSnum.InnerText = mem.Snum.ToString();
                        xelLottryNum.SetAttributeNode(xelSnum);
                        XmlElement xelNumdate = doc.CreateElement("Numdate");//创建子节点
                        xelNumdate.InnerText = mem.Numdate.ToString();
                        xelLottryNum.AppendChild(xelNumdate);//追加子节点
                        XmlElement xelNum = doc.CreateElement("Num");//创建子节点
                        xelNum.InnerText = mem.Num;
                        xelLottryNum.AppendChild(xelNum);//追加子节点
                        root.AppendChild(xelLottryNum);//在根结点追加节点
                    }
                    doc.Save("xml/" + date + ".xml");
                }
                catch (FileNotFoundException ex)//XmlReader.Create异常
                {
                    mainDialog.ShowMessage("记录不存在！", "温馨提示：", MessageBoxButton.OK, null);
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;
                    XmlWriter writer = XmlWriter.Create("xml/" + date + ".xml", settings);
                    writer.WriteStartElement("lottry");
                    writer.WriteEndElement();
                    writer.Close();
                    mainDialog.ShowMessage("已经自动创建记录文件！", "温馨提示：", MessageBoxButton.OK, null);
                    AppendLottryData();//创建记录后需要再追加一下
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

         
        }
        private void Add_file_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Dp.Text != "")
            {
                bool isExist = false;
                string temp = Dp.Text.Replace("/", "");
                DirectoryInfo theFolder = new DirectoryInfo("xml/");
                FileInfo[] fileinfo = theFolder.GetFiles();
                List<string> fileinfoList = new List<string>();
                foreach (FileInfo fo in fileinfo)
                {
                    if (fo.Name == (temp + ".xml"))
                        isExist = true;
                }
                if (!isExist)
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;
                    XmlWriter writer = XmlWriter.Create("xml/" + temp + ".xml", settings);
                    writer.WriteStartElement("lottry");
                    writer.WriteEndElement();
                    writer.Close();
                    mainDialog.ShowMessage("已经成功创建记录文件！", "温馨提示：", MessageBoxButton.OK, null);
                    LoadUpdateCombo();
                }else
                {
                    mainDialog.ShowMessage("记录已经存在！", "温馨提示：", MessageBoxButton.OK, null);
                }

            }
            else
            {
               mainDialog.ShowMessage("请选择日期！", "温馨提示：", MessageBoxButton.OK, null);
            }


        }
        private void combob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combob.SelectedItem != null)
            {
                LoadXmlFile((string)combob.SelectedItem);
            }
;
        }
        private void Dele_file_btn_Click(object sender, RoutedEventArgs e)
        {
            if (combob.Text != "")
            {
                MessageBoxResult result = mainDialog.ShowMessage("是否删除此记录？（不可恢复）", "友情提示：", MessageBoxButton.OKCancel, null);
                if (result == MessageBoxResult.OK)
                {
                    if (File.Exists("xml/" + (string)combob.SelectedItem + ".xml"))
                    {
                        File.Delete("xml/" + (string)combob.SelectedItem + ".xml");
                        LoadUpdateCombo();
                    }
                }
            }
            else
            {
                mainDialog.ShowMessage("无记录！", "友情提示：", MessageBoxButton.OK, null);
            }

        }
        private void GejiYaoji(int Geji, int FenshuTh)
        {
            IsAllDataMode = false;
            Geji++;
            FenshuTh--;
            memberDat.Clear();
                for (int i = FenshuTh; i < TempMember.Count; i += Geji)
                {
                    memberDat.Add(TempMember[i]);
                }
            NumTable.DataContext = memberDat;
        }
        private void AllData_Click(object sender, RoutedEventArgs e)
        {
            IsAllDataMode = true;
            memberDat.Clear();
            if (TempMember.Count != 0)
            {
                for (int i = 0; i < TempMember.Count; i++)
                {
                    memberDat.Add(TempMember[i]);
                }
                NumTable.DataContext = memberDat;
            }
            
        }
        #region
        //TreeView SelectEnent
        private void TreeViewItem1_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(1, 1);
        }
        private void TreeViewItem1_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(1, 2);
        }
        private void TreeViewItem_2_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(2, 1);
        }

        private void TreeViewItem_2_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(2, 2);
        }

        private void TreeViewItem_2_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(2, 3);
        }

        private void TreeViewItem_3_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(3, 1);
        }

        private void TreeViewItem_3_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(3, 2);
        }

        private void TreeViewItem_3_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(3, 3);
        }

        private void TreeViewItem_3_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(3, 4);
        }

        private void TreeViewItem_4_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(4, 1);
        }

        private void TreeViewItem_4_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(4, 2);
        }

        private void TreeViewItem_4_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(4, 3);
        }

        private void TreeViewItem_4_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(4, 4);
        }

        private void TreeViewItem_4_5_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(4, 5);
        }

        private void TreeViewItem_5_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(5, 1);
        }

        private void TreeViewItem_5_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(5, 2);
        }

        private void TreeViewItem_5_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(5, 3);
        }

        private void TreeViewItem_5_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(5, 4);
        }

        private void TreeViewItem_5_5_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(5, 5);
        }

        private void TreeViewItem_5_6_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(5, 6);
        }
        private void TreeViewItem_6_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(6, 1);
        }

        private void TreeViewItem_6_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(6, 2);
        }

        private void TreeViewItem_6_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(6, 3);
        }

        private void TreeViewItem_6_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(6, 4);
        }

        private void TreeViewItem_6_5_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(6, 5);
        }

        private void TreeViewItem_6_6_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(6, 6);
        }
        private void TreeViewItem_6_7_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(6, 7);
        }
        private void TreeViewItem_7_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 1);
        }

        private void TreeViewItem_7_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 2);
        }

        private void TreeViewItem_7_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 3);
        }

        private void TreeViewItem_7_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 4);
        }

        private void TreeViewItem_7_5_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 5);
        }

        private void TreeViewItem_7_6_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 6);
        }
        private void TreeViewItem_7_7_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 7);
        }
        private void TreeViewItem_7_8_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(7, 8);
        }
        private void TreeViewItem_8_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 1);
        }

        private void TreeViewItem_8_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 2);
        }

        private void TreeViewItem_8_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 3);
        }

        private void TreeViewItem_8_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 4);
        }

        private void TreeViewItem_8_5_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 5);
        }

        private void TreeViewItem_8_6_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 6);
        }
        private void TreeViewItem_8_7_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 7);
        }
        private void TreeViewItem_8_8_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 8);
        }
        private void TreeViewItem_8_9_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(8, 9);
        }
        private void TreeViewItem_9_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 1);
        }

        private void TreeViewItem_9_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 2);
        }

        private void TreeViewItem_9_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 3);
        }

        private void TreeViewItem_9_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 4);
        }

        private void TreeViewItem_9_5_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 5);
        }

        private void TreeViewItem_9_6_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 6);
        }
        private void TreeViewItem_9_7_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 7);
        }
        private void TreeViewItem_9_8_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 8);
        }
        private void TreeViewItem_9_9_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 9);
        }
        private void TreeViewItem_9_10_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(9, 10);
        }
        private void TreeViewItem_10_1_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 1);
        }

        private void TreeViewItem_10_2_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 2);
        }

        private void TreeViewItem_10_3_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 3);
        }

        private void TreeViewItem_10_4_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 4);
        }

        private void TreeViewItem_10_5_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 5);
        }

        private void TreeViewItem_10_6_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 6);
        }
        private void TreeViewItem_10_7_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 7);
        }
        private void TreeViewItem_10_8_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 8);
        }
        private void TreeViewItem_10_9_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 9);
        }
        private void TreeViewItem_10_10_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 10);
        }
        private void TreeViewItem_10_11_Selected(object sender, RoutedEventArgs e)
        {
            GejiYaoji(10, 11);
        }
        #endregion//
        private void QiShu_tbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
        private void GetDtaFormNet_btn_Click(object sender, RoutedEventArgs e)
        {
            if(QiShu_tbox.Text!=""&&QiShu_tbox.Text!="0")
            {
                GetNetDataPro.Visibility = System.Windows.Visibility.Visible;
                GetNetDataPro.IsIndeterminate = true;
                Thread t = new Thread(new ParameterizedThreadStart(GetDataFromNet));
                t.Name = "getNetData";
                t.Start(QiShu_tbox.Text);
            }
            else
            {
                mainDialog.ShowMessage("期数不能为空！", "温馨提示：", MessageBoxButton.OK, null);
            }

        }
        public void GetDataFromNet(object GetNum)
        {
            try
            {
                 WebClient wc = new WebClient();
                 //wc.Credentials = CredentialCache.DefaultCredentials;
                // wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                 wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.154 Safari/537.36 LBBROWSER");
                string html = wc.DownloadString("http://tubiao.17mcp.com/Sby/HaomaHebingZs-" + GetNum + ".html");
                Regex Year_regex = new Regex(@"([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8])))");
                MatchCollection Years = Year_regex.Matches(html);
                string[] YearStr = new string[Years.Count];
                int i = 0;
                if (Year_regex.IsMatch(html))
                {
                    foreach (Match match in Years)
                    {
                        GroupCollection groups = match.Groups;
                        YearStr[i] = groups[0].ToString();
                        i++;
                    }
                }
                Regex QiHao_regex = new Regex("160[0-9]{5,}");
                MatchCollection QiHao = QiHao_regex.Matches(html);
                string[] QihaoStr = new string[QiHao.Count];
                int k =0;
                if (Year_regex.IsMatch(html))
                {
                    foreach (Match match in QiHao)
                    {
                        GroupCollection groups = match.Groups;
                        QihaoStr[k] = groups[0].ToString();
                        k++;
                    }
                }
                Regex KaiJiangNum_regex = new Regex("<td width=\"25\">[0-9]{1,1}</td><td width=\"25\">[0-9]{1,1}</td><td width=\"25\">[0-9]{1,1}</td><td width=\"25\">[0-9]{1,1}</td>");
                MatchCollection KaiJiangNum = KaiJiangNum_regex.Matches(html);
                string[] KaiJiangNumStr = new string[KaiJiangNum.Count];
                int j = 0;
                if (KaiJiangNum_regex.IsMatch(html))
                {
                    foreach (Match match in KaiJiangNum)
                    {
                        GroupCollection groups = match.Groups;
                        KaiJiangNumStr[j] = groups[0].ToString();
                        KaiJiangNumStr[j] = KaiJiangNumStr[j].Replace("<td width=\"25\">", "");
                        KaiJiangNumStr[j] = KaiJiangNumStr[j].Replace("</td>", "");
                        j++;
                    }
                }
       
                this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    memberDat.Clear();
                });
                for (int m = 0 ; m < KaiJiangNum.Count; m++)
                {
                    char[] ss = KaiJiangNumStr[m].ToCharArray();
                    //string tmpYear = YearStr[m].Replace("-", "");
                    this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                    {
                        memberDat.Add(new Member() { Snum = m, Numdate = QihaoStr[m], Num = KaiJiangNumStr[m], elea = Convert.ToInt32(ss[0]) - 48, eleb = Convert.ToInt32(ss[1]) - 48, elec = Convert.ToInt32(ss[2]) - 48, eled = Convert.ToInt32(ss[3]) - 48 });
                    });                   
                }
                this.Dispatcher.Invoke(new Action(()=>
                {
                    AppendLottryData();
                    FirstLoadxml = false;//不需要二次载入XML文件
                    NumTable.DataContext = memberDat;
                    TempMember = memberDat.ToList(); //拷贝一份数据的副本
                    NumTable.ScrollIntoView(TempMember[TempMember.Count - 1]);//让DATAGRID滚动到最下面
                    LoadUpdateCombo();//下拉框纪录更新
                    GetNetDataPro.Visibility = System.Windows.Visibility.Collapsed;//关闭进度条
                    GetNetDataPro.IsIndeterminate = false;
                }));
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(new Action(() => {
                    mainDialog.ShowMessage("未能获取到网络数据，请检查您的网络状况！", "温馨提示：", MessageBoxButton.OK, null);
                    GetNetDataPro.Visibility = System.Windows.Visibility.Collapsed;//关闭进度条
                    GetNetDataPro.IsIndeterminate = false;
                }));
            }
        }
    }
}
