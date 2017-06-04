using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Timers;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace DropBoxPlus
{
    public partial class Main : Form
    {
        // Constants
        const double    DROPBOX_CAPACITY_GB = 6.25;                                        // GB
        const double    DROPBOX_CAPACITY = DROPBOX_CAPACITY_GB * 1024 * 1024 * 1024;       // Convert to bytes
        const int       DROPBOX_WARNING = 50; // %
        const int       DROPBOX_ALARM = 60; // %
        const string    DROPBOX_DIR = @"C:\Users\Joost\Dropbox";
        const string    DROPBOX_SOURCE_DIR = @"C:\Users\joost\Dropbox\Camera Uploads";
        const string    NAS_HOSTNAME = "nas";
        const string    NAS_DEST_DIR = @"P:\00000000 - Smartphone Joost";

        // Global variables
        // Common variables
        double pbUnit;
        int pbWidth, pbHeight, DropboxLevel, ToMoveCnt = 0, MovedCnt = 0, MoveProg = 0;
        Boolean DebugMode = false;
        // Graphics
        Bitmap bmpDropboxUsage, bmpFilesMoved;
        Graphics gDropboxUsage, gFilesMoved;
        // Timers
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();
        // Regex
        private static Regex r = new Regex(":");

        private void Main_Load(object sender, EventArgs e)
        {
            // Detect debug mode
            #if DEBUG
            DebugMode = true;
            #endif

            // Read configuration file
            //var appSettings = ConfigurationManager.AppSettings;
            //Console.WriteLine(appSettings["DROPBOX_CAPACITY_GB"]);

            // Format the form
            CenterToScreen();
            Height = 135;

            // 
            // Dropbox usage
            // 

            // Initialize bar
            pbWidth = pbDropboxUsage.Width;
            pbHeight = pbDropboxUsage.Height;
            pbUnit = pbWidth / 100.0;

            // Create bitmaps
            bmpDropboxUsage = new Bitmap(pbWidth, pbHeight);
            bmpFilesMoved = new Bitmap(pbWidth, pbHeight);

            // Update Dropbox Usage
            DropboxLevel = UpdateDropboxUsage();

            // 
            // NAS status
            // 
            if (CheckNAS())
            {
                lblNASStatus.Text = "connected";
                lblNASStatus.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lblNASStatus.Text = "disconnected";
                lblNASStatus.ForeColor = System.Drawing.Color.Red;
            }

            // 
            // Files moved
            //           

            // Initialize timers
            t1.Enabled = false;
            t1.Interval = 1;
            t1.Tick += new EventHandler(OnTimedEvent1);
            t2.Enabled = false;
            t2.Interval = 5000;
            t2.Tick += new EventHandler(OnTimedEvent2);

            // If Dropbox is too full action is required...
            // ... but can only happen if NAS is up!
            if (((DropboxLevel > DROPBOX_ALARM) || DebugMode) && CheckNAS())
            {
                // Display the progress bar
                this.Height += 85;
                // Compute the amount of files to move
                DirectoryInfo d = new DirectoryInfo(DROPBOX_SOURCE_DIR);
                ToMoveCnt += d.GetFiles("*.jpg", SearchOption.TopDirectoryOnly).Length;
                ToMoveCnt += d.GetFiles("*.mp4", SearchOption.TopDirectoryOnly).Length;
                ToMoveCnt += d.GetFiles("*.png", SearchOption.TopDirectoryOnly).Length;

                // Initialize progress bar
                gFilesMoved = Graphics.FromImage(bmpFilesMoved);
                gFilesMoved.Clear(Color.Black);
                gFilesMoved.FillRectangle(Brushes.White, new Rectangle(2, 2, pbWidth - 4, pbHeight - 4));
                pbFilesMoved.Image = bmpFilesMoved;

                // Update label
                lblFilesMoved.Text = "Files moved [0/" + ToMoveCnt + "]";

                // Start processing
                t1.Enabled = true;
            }
            else
            {   // Show info to user and quit
                t2.Enabled = true;                
            }
        }

        private void OnTimedEvent1(Object myObject, EventArgs myEventArgs)
        {
            t1.Enabled = false;
            MoveDropboxData();
            t1.Enabled = true;
        }

        private void butnMove_Click(object sender, EventArgs e)
        {
            // Disable exit procedure
            t2.Enabled = false;

            // Display the progress bar
            this.Height += 85;
            // Compute the amount of files to move
            DirectoryInfo d = new DirectoryInfo(DROPBOX_SOURCE_DIR);
            ToMoveCnt += d.GetFiles("*.jpg", SearchOption.TopDirectoryOnly).Length;
            ToMoveCnt += d.GetFiles("*.mp4", SearchOption.TopDirectoryOnly).Length;
            ToMoveCnt += d.GetFiles("*.png", SearchOption.TopDirectoryOnly).Length;

            // Initialize progress bar
            gFilesMoved = Graphics.FromImage(bmpFilesMoved);
            gFilesMoved.Clear(Color.Black);
            gFilesMoved.FillRectangle(Brushes.White, new Rectangle(2, 2, pbWidth - 4, pbHeight - 4));
            pbFilesMoved.Image = bmpFilesMoved;

            // Update label
            lblFilesMoved.Text = "Files moved [0/" + ToMoveCnt + "]";

            // Start processing
            t1.Enabled = true;
        }

        private void OnTimedEvent2(Object myObject, EventArgs myEventArgs)
        {
            t2.Enabled = false; 
            Application.Exit();
        }

        private long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        private int UpdateDropboxUsage()
        {
            // Initialize progress bar
            gDropboxUsage = Graphics.FromImage(bmpDropboxUsage);
            gDropboxUsage.Clear(Color.Black);
            gDropboxUsage.FillRectangle(Brushes.White, new Rectangle(2, 2, pbWidth - 4, pbHeight - 4));

            // Get Dropbox size
            DirectoryInfo DirDropbox = new DirectoryInfo(DROPBOX_DIR);
            DropboxLevel = (int)(DirSize(DirDropbox) / DROPBOX_CAPACITY * 100.0);

            // Update label
            lblDropboxUsage.Text = "Dropbox usage [" + DropboxLevel + "%]";

            // Update progressbar
            if (DropboxLevel > DROPBOX_ALARM)
                gDropboxUsage.FillRectangle(Brushes.Red, new Rectangle(2, 2, (int)(DropboxLevel * pbUnit - 4), pbHeight - 4));
            if (DropboxLevel > DROPBOX_WARNING)
                gDropboxUsage.FillRectangle(Brushes.DarkOrange, new Rectangle(2, 2, (int)(DropboxLevel * pbUnit - 4), pbHeight - 4));
            else
                gDropboxUsage.FillRectangle(Brushes.CornflowerBlue, new Rectangle(2, 2, (int)(DropboxLevel * pbUnit - 4), pbHeight - 4));

            pbDropboxUsage.Image = bmpDropboxUsage;

            return DropboxLevel;
        }

        private bool CheckNAS()
        {
            Ping pingSend = new Ping();
            try
            {
                PingReply pingRec = pingSend.Send(NAS_HOSTNAME);
                if (pingRec.Status.ToString().Equals("Success"))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void MoveDropboxData()
        {
            // Initialize progress bar
            gFilesMoved = Graphics.FromImage(bmpFilesMoved);
            gFilesMoved.Clear(Color.Black);
            gFilesMoved.FillRectangle(Brushes.White, new Rectangle(2, 2, pbWidth - 4, pbHeight - 4));

            DirectoryInfo d = new DirectoryInfo(DROPBOX_SOURCE_DIR);
            FileInfo[] fis = d.GetFiles();

            if (ToMoveCnt == MovedCnt)
            {
                // Show info to user and quit
                t2.Enabled = true;
            }

            foreach (FileInfo fi in fis)
            {
                // Only copy photo's and movies
                if ((fi.Extension == ".jpg") || (fi.Extension == ".mp4") || (fi.Extension == ".png"))
                {
                    // Update current file label
                    lblCurFile.Text = fi.Name;

                    // Extract the year the picture was taken in
                    int year;
                    year = int.Parse(fi.Name.Substring(0, 4));
                    string destFolder = NAS_DEST_DIR + "\\" + year + "\\";

                    // Move the file if it doesn't already exist
                    if (!System.IO.File.Exists(destFolder + fi.Name))
                    {
                        // Check if the year folder is already present
                        Directory.CreateDirectory(destFolder);
                        // Move the file
                        System.IO.File.Move(fi.FullName, destFolder + fi.Name);
                    }
                    else // It is already on the NAS so remove it
                        System.IO.File.Delete(fi.FullName);

                    // Update move counter
                    MovedCnt++;
                    MoveProg = (int)(MovedCnt * 100.0 / ToMoveCnt );

                    // Update progress label
                    lblFilesMoved.Text = "Files moved [" + MovedCnt + "/" + ToMoveCnt + "]";

                    // Update moved files progress bar
                    gFilesMoved.FillRectangle(Brushes.CornflowerBlue, new Rectangle(2, 2, (int)(MoveProg * pbUnit - 4), pbHeight - 4));
                    pbFilesMoved.Image = bmpFilesMoved;

                    // Update dropbox progress bar
                    UpdateDropboxUsage();

                    return;
                }
            }
        }

        public Main()
        {
            InitializeComponent();
        }

    }
}
