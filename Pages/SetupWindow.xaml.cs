using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;

namespace 预彩精灵.Pages
{
    /// <summary>
    /// Interaction logic for AddNum.xaml
    /// </summary>
    public partial class mainDialog : ModernDialog
    {
        public static int AnalysisQiShu = 0;
        public static int FivecoldBound = 0;
        public static int FourcoldBound = 0;
        public static int ThreecoldBound = 0;
        public static int TwocoldBound = 0;
        public static int StartIndexNum = 0;
        public static int EndIndexNum = 0;
        public mainDialog()
        {
            InitializeComponent();
            LoadXmlSettings();
            //define the dialog buttons
            //this.Buttons = new Button[] { this.OkButton, this.CancelButton };
        }

        private void CancelSetupBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveSetupBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FiveNumStatus.Text == "")
            {
                FivecoldBound = 5;
            }
            else
            {
                FivecoldBound = Convert.ToInt32(FiveNumStatus.Text);
            }
            if (an_QiNum.Text == "")
            {
                AnalysisQiShu = 5; 
            }else
                    {
                        AnalysisQiShu = Convert.ToInt32(an_QiNum.Text);
                    }
            if (fourNumStatus.Text == "")
            {
                  FourcoldBound=5;
            }else{
                    FourcoldBound = Convert.ToInt32(fourNumStatus.Text);
                }
            if (ThreeNumStatus.Text == "")
            {
                ThreecoldBound=5;
            }else
                    {                     
                        ThreecoldBound = Convert.ToInt32(ThreeNumStatus.Text);
                    }
              if ( TwoNumStatus.Text == "")
              {
                  TwocoldBound=5;
              }else
                    {
                        TwocoldBound = Convert.ToInt32(TwoNumStatus.Text);
                    }
              if (StartIndex.Text == "")
              {
                  StartIndexNum=5;
              }else
                    {
                        StartIndexNum = Convert.ToInt32(StartIndex.Text);
                    }
               if (EndIndex.Text == "")
               {
                   EndIndexNum =5;
               }else
                    {
                        EndIndexNum = Convert.ToInt32(EndIndex.Text);
                    }
               AppendSettingFile(FivecoldBound, AnalysisQiShu, FourcoldBound, ThreecoldBound, TwocoldBound, StartIndexNum, EndIndexNum);
            mainDialog.ShowMessage("保存成功！","温馨提示：",MessageBoxButton.OK,null);
            this.Close();
        }

        public void LoadXmlSettings()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create("AnalysisConfig.xml", settings);
                doc.Load(reader);
                reader.Close();
                XmlNode xn = doc.SelectSingleNode("AnalysisConfig");
                XmlNodeList xnl = xn.ChildNodes;
                int tmp = 0;
                foreach (XmlNode xn1 in xnl)
                {
                    XmlElement xe = (XmlElement)xn1;
                    XmlNodeList xn10 = xe.ChildNodes;
                    if (tmp == 0) 
                    {
                        FiveNumStatus.Text = xn10.Item(0).InnerText;
                        FivecoldBound = Convert.ToInt32(xn10.Item(0).InnerText);
                    }
                    else if (tmp == 1)
                    {
                        an_QiNum.Text = xn10.Item(0).InnerText;
                        AnalysisQiShu = Convert.ToInt32(xn10.Item(0).InnerText);
                    }
                    else if (tmp == 2)
                    {
                        fourNumStatus.Text = xn10.Item(0).InnerText;
                        FourcoldBound = Convert.ToInt32(xn10.Item(0).InnerText);
                    }
                    else if (tmp == 3)
                    {
                        ThreeNumStatus.Text = xn10.Item(0).InnerText;
                        ThreecoldBound = Convert.ToInt32(xn10.Item(0).InnerText);
                    }
                    else if (tmp == 4)
                    {
                        TwoNumStatus.Text = xn10.Item(0).InnerText;
                        TwocoldBound = Convert.ToInt32(xn10.Item(0).InnerText);
                    }
                    else if (tmp == 5)
                    {
                        StartIndex.Text = xn10.Item(0).InnerText;
                        StartIndexNum = Convert.ToInt32(xn10.Item(0).InnerText);
                    }
                    else if (tmp == 6)
                    {
                        EndIndex.Text = xn10.Item(0).InnerText;
                        EndIndexNum = Convert.ToInt32(xn10.Item(0).InnerText);
                    }

                    tmp++;
                }
            }
            catch (FileNotFoundException ex)//XmlReader.Create异常
            {

                //mainDialog.ShowMessage("记录不存在！", "温馨提示：", MessageBoxButton.OK, null);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                XmlWriter writer = XmlWriter.Create("AnalysisConfig.xml", settings);
                writer.WriteStartElement("AnalysisConfig");
                writer.WriteEndElement();
                writer.Close();
                //mainDialog.ShowMessage("已经自动创建配置文件！", "温馨提示：", MessageBoxButton.OK, null);               
            }

        }
        public void AppendSettingFile(int FivecoldBound, int AnalysisQiShu, int FourcoldBound, int ThreecoldBound, int TwocoldBound, int StartIndexNum, int EndIndexNum)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create("AnalysisConfig.xml", settings);
                doc.Load(reader);
                reader.Close();
                XmlNode root = doc.SelectSingleNode("AnalysisConfig");//找到根节点               
                root.RemoveAll();
                XmlElement xelFivecoldBound = doc.CreateElement("FivecoldBound");//创建节点
                xelFivecoldBound.InnerText = Convert.ToString(FivecoldBound);
                root.AppendChild(xelFivecoldBound);//在根结点追加节点
                XmlElement xelAnalysisQiShu = doc.CreateElement("AnalysisQiShu");//创建节点
                xelAnalysisQiShu.InnerText = Convert.ToString(AnalysisQiShu);
                root.AppendChild(xelAnalysisQiShu);//在根结点追加节点
                XmlElement xelFourcoldBound = doc.CreateElement("FourcoldBound");//创建节点
                xelFourcoldBound.InnerText = Convert.ToString(FourcoldBound);
                root.AppendChild(xelFourcoldBound);//在根结点追加节点
                XmlElement xelThreecoldBound = doc.CreateElement("ThreecoldBound");//创建节点
                xelThreecoldBound.InnerText = Convert.ToString(ThreecoldBound);
                root.AppendChild(xelThreecoldBound);//在根结点追加节点
                XmlElement xelTwocoldBound = doc.CreateElement("TwocoldBound");//创建节点
                xelTwocoldBound.InnerText = Convert.ToString(TwocoldBound);
                root.AppendChild(xelTwocoldBound);//在根结点追加节点
                XmlElement xelStartIndexNum = doc.CreateElement("StartIndexNum");//创建节点
                xelStartIndexNum.InnerText = Convert.ToString(StartIndexNum);
                root.AppendChild(xelStartIndexNum);//在根结点追加节点
                XmlElement xelEndIndexNum = doc.CreateElement("EndIndexNum");//创建节点
                xelEndIndexNum.InnerText = Convert.ToString(EndIndexNum);
                root.AppendChild(xelEndIndexNum);//在根结点追加节点
                doc.Save("AnalysisConfig.xml");
            }
            catch (FileNotFoundException ex)//XmlReader.Create异常
            {
                //mainDialog.ShowMessage("记录不存在！", "温馨提示：", MessageBoxButton.OK, null);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                XmlWriter writer = XmlWriter.Create("AnalysisConfig.xml", settings);
                writer.WriteStartElement("AnalysisConfig");
                writer.WriteEndElement();
                writer.Close();
                //mainDialog.ShowMessage("已经自动创建配置文件！", "温馨提示：", MessageBoxButton.OK, null);               
            }
        }


        #region
        //TEXTBOX的输入规则限制
        private void an_QiNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void an_GeNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TwoNumStatus_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void ThreeNumStatus_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void fourNumStatus_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void FiveNumStatus_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void StartIndex_PreviewTextInput(object sender, TextCompositionEventArgs e)

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

        private void EndIndex_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void ForecastNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        #endregion










    }
}
