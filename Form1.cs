using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable enable

namespace BuyiToolbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DirectoryInfo? theDir = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var args = Environment.GetCommandLineArgs();
                if (args.Length < 2)
                {
                    throw new Exception($"你没有输入指定的文件夹的路径。 需要作为启动项的第一个参数");
                }
                var path = args[1].Trim().Trim('/', '\\', '\'', '\"');
                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception($"无法识别的文件夹名字");
                }
                var dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    throw new Exception($"文件夹不存在 {dir.FullName}");
                }
                theDir = dir;
                BgIcon.Icon = CreateIconFromText(dir.Name.Substring(0, 1));
                this.Icon = BgIcon.Icon;
                BgIcon.Visible = true;
                BuildMenu(MainMenu.Items, theDir, 0);
            }
            catch (Exception ex)
            {
                PopError(ex);
                BgIcon.Visible = false;
                Process.GetCurrentProcess().Kill();
            }
        }

        private void BuildMenu(ToolStripItemCollection parent, DirectoryInfo dir, int level)
        {
            parent.Clear();
            dir.Refresh();
            if (!dir.Exists) { return; }
            Bitmap? explorerIcon = null;
            foreach (var f in dir.EnumerateDirectories())
            {
                if (f.Attributes.HasFlag(FileAttributes.Hidden)) { continue; }
                var v = new ToolStripMenuItem();
                v.Text = f.Name;
                if (explorerIcon == null)
                {
                    explorerIcon = GetIconBitmap("C:/Windows/explorer.exe");
                }
                v.Image = explorerIcon;
                v.Tag = f.FullName;
                v.Click += OnMenuItemClick;
                parent.Add(v);
                if (level < 3)
                {
                    BuildMenu(v.DropDownItems, f, level + 1);
                }
            }
            foreach (var f in dir.EnumerateFiles())
            {
                if (f.Attributes.HasFlag(FileAttributes.Hidden)) { continue; }
                var v = new ToolStripMenuItem();
                if (f.Name.EndsWith(".lnk", StringComparison.CurrentCultureIgnoreCase))
                {
                    v.Text = Path.GetFileNameWithoutExtension(f.Name);
                }
                else
                {
                    v.Text = f.Name;
                }
                v.Image = GetIconBitmap(f.FullName);
                v.Click += OnMenuItemClick;
                v.Tag = f.FullName;
                parent.Add(v);
            }
        }

        private void MainMenu_Opening(object sender, CancelEventArgs e)
        {
            if (theDir == null) { return; }
            try
            {
                BuildMenu(MainMenu.Items, theDir, 0);
            }
            catch (Exception ex)
            {
                PopError(ex);
            }
        }

        private void OnMenuItemClick(object sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem item) { return; }
            var tag = item.Tag;
            if (tag == null || tag is not string path) { return; }
            try
            {
                var pinfo = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                };
                using var _ = Process.Start(pinfo);
            }
            catch (Exception ex)
            {
                PopError(ex);
            }
        }

        private static void PopError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Buyi Toolbar. Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static Bitmap GetIconBitmap(string f)
        {
            using var icon = System.Drawing.Icon.ExtractAssociatedIcon(f);
            return icon.ToBitmap();
        }

        private static readonly SolidBrush backgroundBrush = new(Color.Black);
        private static readonly SolidBrush fontBrush = new(Color.White);
        private const int iconWidth = 128;
        private static readonly Font iconFont = new("Microsoft YaHei UI", Convert.ToInt32(iconWidth * 0.75), System.Drawing.FontStyle.Regular, GraphicsUnit.Pixel);

        private static Icon CreateIconFromText(string text)
        {
            using var iconBitmap = new Bitmap(iconWidth, iconWidth);
            using var g = Graphics.FromImage(iconBitmap);
            g.FillRectangle(backgroundBrush, 0, 0, iconWidth, iconWidth);
            g.DrawString(text, iconFont, fontBrush, 1, 1);
            var icon = System.Drawing.Icon.FromHandle(iconBitmap.GetHicon());
            return icon;
        }

    }
}
