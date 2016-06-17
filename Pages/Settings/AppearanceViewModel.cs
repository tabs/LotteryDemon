using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace 预彩精灵.Pages.Settings
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class AppearanceViewModel
        : NotifyPropertyChanged
    {
        private const string FontSmall = "small";
        private const string FontLarge = "large";
        // 9 accent colors from metro design principles
        /*private Color[] accentColors = new Color[]{
            Color.FromRgb(0x33, 0x99, 0xff),   // blue
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x33, 0x99, 0x33),   // green
            Color.FromRgb(0x8c, 0xbf, 0x26),   // lime
            Color.FromRgb(0xf0, 0x96, 0x09),   // orange
            Color.FromRgb(0xff, 0x45, 0x00),   // orange red
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xff, 0x00, 0x97),   // magenta
            Color.FromRgb(0xa2, 0x00, 0xff),   // purple            
        };*/

        // 20 accent colors from Windows Phone 8
        public Color[] accentColors = new Color[]{
            Color.FromRgb(0xa4, 0xc4, 0x00),   // lime
            Color.FromRgb(0x60, 0xa9, 0x17),   // green
            Color.FromRgb(0x00, 0x8a, 0x00),   // emerald
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x1b, 0xa1, 0xe2),   // cyan
            Color.FromRgb(0x00, 0x50, 0xef),   // cobalt
            Color.FromRgb(0x6a, 0x00, 0xff),   // indigo
            Color.FromRgb(0xaa, 0x00, 0xff),   // violet
            Color.FromRgb(0xf4, 0x72, 0xd0),   // pink
            Color.FromRgb(0xd8, 0x00, 0x73),   // magenta
            Color.FromRgb(0xa2, 0x00, 0x25),   // crimson
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xfa, 0x68, 0x00),   // orange
            Color.FromRgb(0xf0, 0xa3, 0x0a),   // amber
            Color.FromRgb(0xe3, 0xc8, 0x00),   // yellow
            Color.FromRgb(0x82, 0x5a, 0x2c),   // brown
            Color.FromRgb(0x6d, 0x87, 0x64),   // olive
            Color.FromRgb(0x64, 0x76, 0x87),   // steel
            Color.FromRgb(0x76, 0x60, 0x8a),   // mauve
            Color.FromRgb(0x87, 0x79, 0x4e),   // taupe
        };
        
        private Color selectedAccentColor;
        private LinkCollection themes = new LinkCollection();
        private Link selectedTheme;
        private string selectedFontSize;

        public AppearanceViewModel()
        {
            // add the default themes
            
            this.themes.Add(new Link { DisplayName = "dark", Source = AppearanceManager.DarkThemeSource });
            this.themes.Add(new Link { DisplayName = "light", Source = AppearanceManager.LightThemeSource });         
            this.SelectedFontSize = AppearanceManager.Current.FontSize == FontSize.Large ? FontLarge : FontSmall;
            SyncThemeAndColor();

            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
        }
        public void LoadXmlSettings()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create("Config.xml", settings);
                doc.Load(reader);
                reader.Close();
                XmlNode xn = doc.SelectSingleNode("Config");
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode xn1 in xnl)
                {
                    XmlElement xe = (XmlElement)xn1;
                    SelectedAccentColor = AccentColors[Convert.ToInt32(xe.GetAttribute("ColorIndex"))];
                    XmlNodeList xn10 = xe.ChildNodes;
                    SelectedTheme = Themes[Convert.ToInt32(xn10.Item(0).InnerText)];
                    SelectedFontSize = xn10.Item(1).InnerText;
                }
            }
             catch (FileNotFoundException ex)//XmlReader.Create异常
            {
                
                //mainDialog.ShowMessage("记录不存在！", "温馨提示：", MessageBoxButton.OK, null);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                XmlWriter writer = XmlWriter.Create("Config.xml", settings);
                writer.WriteStartElement("Config");
                writer.WriteEndElement();
                writer.Close();
                //mainDialog.ShowMessage("已经自动创建配置文件！", "温馨提示：", MessageBoxButton.OK, null);               
            }

        }
        public void AppendSettingFile(int ColorIndex,int ThemeIndex,string FontSize)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create("Config.xml", settings);
                doc.Load(reader);
                reader.Close();
                XmlNode root = doc.SelectSingleNode("Config");//找到根节点               
                root.RemoveAll();
                    XmlElement xelSACNum = doc.CreateElement("selectedAccentColor");//找到节点
                    XmlAttribute xelColorIndex = doc.CreateAttribute("ColorIndex");//创建节点的属性
                    xelColorIndex.InnerText = ColorIndex.ToString();
                    xelSACNum.SetAttributeNode(xelColorIndex);
                    XmlElement xelST = doc.CreateElement("SelectTheme");//创建子节点
                    xelST.InnerText = ThemeIndex.ToString();
                    xelSACNum.AppendChild(xelST);//追加子节点
                    XmlElement xelSF= doc.CreateElement("SelectFont");//创建子节点
                    xelSF.InnerText = FontSize;
                    xelSACNum.AppendChild(xelSF);//追加子节点
                    root.AppendChild(xelSACNum);//在根结点追加节点
                    doc.Save("Config.xml");
            }
            catch (FileNotFoundException ex)//XmlReader.Create异常
            {
                //mainDialog.ShowMessage("记录不存在！", "温馨提示：", MessageBoxButton.OK, null);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                XmlWriter writer = XmlWriter.Create("Config.xml", settings);
                writer.WriteStartElement("Config");
                writer.WriteEndElement();
                writer.Close();
                //mainDialog.ShowMessage("已经自动创建配置文件！", "温馨提示：", MessageBoxButton.OK, null);               
            }
        }

        private void SyncThemeAndColor()
        {
            // synchronizes the selected viewmodel theme with the actual theme used by the appearance manager.
            this.SelectedTheme = this.themes.FirstOrDefault(l => l.Source.Equals(AppearanceManager.Current.ThemeSource));

            // and make sure accent color is up-to-date
            this.SelectedAccentColor = AppearanceManager.Current.AccentColor;


        }

        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            int SelectColorindex = 4,SelectThemeindex = 0;
            for (int i = 0; i < 20; i++)
            {
                if (accentColors[i].Equals(AppearanceManager.Current.AccentColor))
                {
                    SelectColorindex = i;
                }
            }
            for (int i = 0; i < themes.Count; i++)
            {
                if (themes[i].Equals(this.themes.FirstOrDefault(l => l.Source.Equals(AppearanceManager.Current.ThemeSource))))
                {
                    SelectThemeindex = i;
                }
            }
            AppendSettingFile(SelectColorindex, SelectThemeindex, this.SelectedFontSize);

            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {
                SyncThemeAndColor();
            }
        }

        public LinkCollection Themes
        {
            get { return this.themes; }
        }

        public string[] FontSizes
        {
            get { return new string[] { FontSmall, FontLarge }; }
        }

        public Color[] AccentColors
        {
            get { return this.accentColors; }
        }

        public Link SelectedTheme
        {
            get { return this.selectedTheme; }
            set
            {
                if (this.selectedTheme != value)
                {
                    this.selectedTheme = value;
                    OnPropertyChanged("SelectedTheme");

                    // and update the actual theme
                    AppearanceManager.Current.ThemeSource = value.Source;
                }
            }
        }

        public string SelectedFontSize
        {
            get { return this.selectedFontSize; }
            set
            {
                if (this.selectedFontSize != value)
                {
                    this.selectedFontSize = value;
                    OnPropertyChanged("SelectedFontSize");

                    AppearanceManager.Current.FontSize = value == FontLarge ? FontSize.Large : FontSize.Small;
                }
            }
        }

        public Color SelectedAccentColor
        {
            get { return this.selectedAccentColor; }
            set
            {
                if (this.selectedAccentColor != value)
                {
                    this.selectedAccentColor = value;
                    OnPropertyChanged("SelectedAccentColor");

                    AppearanceManager.Current.AccentColor = value;
                }
            }
        }
    }
}
