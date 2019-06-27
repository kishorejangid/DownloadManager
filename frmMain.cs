using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace DownloadManager
{
    public partial class frmMain : Form
    {
        // The thread inside which the download happens
        private Thread thrDownload;
        // The stream of data retrieved from the web server
        private Stream strResponse;
        // The stream of data that we write to the harddrive
        private Stream strLocal;
        // The request to the web server for file information
        private HttpWebRequest webRequest;
        // The response from the web server containing information about the file
        private HttpWebResponse webResponse;
        // The progress of the download in percentage
        private static int PercentProgress;
        // The delegate which we will call from the thread to update the form
        private delegate void UpdateProgessCallback(Int64 BytesRead, Int64 TotalBytes);
        // When to pause
        bool goPause = false;
        //get the file name which is being download
        private string filename;
        //Storage Location for downloads
        private string loc;

        public frmMain()
        {
            InitializeComponent();            
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                loc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Jangid Download Manager";
            }
            else
            {
                loc = txtPath.Text + "\\" + "Jangid Download Manager";
            }

            if (thrDownload != null && thrDownload.ThreadState == ThreadState.Running)
            {
                MessageBox.Show("A download is already running. Please either the stop the current download or await for its completion before starting a new one.", "Download in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Let the user know we are connecting to the server
                lblProgress.Text = "Download Starting";
                // Create a new thread that calls the Download() method
                thrDownload = new Thread(new ParameterizedThreadStart(Download));
                // Start the thread, and thus call Download(); start downloading from the beginning (0)
                thrDownload.Start(0);                
                // Enable the Pause/Resume button
                btnPauseResume.Enabled = true;
                // Set the button's caption to Pause because a download is in progress
                btnPauseResume.Text = "Pause";
            }
        }

        private void UpdateProgress(Int64 BytesRead, Int64 TotalBytes)
        {            
            if (BytesRead != TotalBytes)
            {
                // Calculate the download progress in percentages
                PercentProgress = Convert.ToInt32((BytesRead * 100) / TotalBytes);
                // Make progress on the progress bar
                prgDownload.Value = PercentProgress;
                // Display the current progress on the form
                lblProgress.Text = "Downloaded " + BytesRead + " out of " + TotalBytes + " (" + PercentProgress + "%)";                
            }
            else
            {
                btnPauseResume.Enabled = false;
                prgDownload.Value = 100;
                lblProgress.Text = "Downloaded Completed";
                //Acknowledge the user about the completion                
                var msgbxResult = MessageBox.Show("Download Completed." + "\n" + "Do you want to open the file folder.","Jangid Download Manager",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                //Open the folder where the file is stored
                if (msgbxResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(loc);
                }
            }
        }

        private void Download(object startPoint)
        {
            try
            {
                // Put the object argument into an int variable
                int startPointInt = Convert.ToInt32(startPoint);
                // Create a request to the file we are downloading
                webRequest = (HttpWebRequest)WebRequest.Create(txtUrl.Text);
                //getting file name from the URL
                filename = Path.GetFileName(txtUrl.Text);                
                // Set the starting point of the request
                webRequest.AddRange(startPointInt);

                // Set default authentication for retrieving the file
                webRequest.Credentials = CredentialCache.DefaultCredentials;
                // Retrieve the response from the server
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                // Ask the server for the file size and store it
                Int64 fileSize = webResponse.ContentLength;

                // Open the URL for download 
                strResponse = webResponse.GetResponseStream();

                //Check whether the given directory exists
                if (Directory.Exists(loc))
                {
                }
                else
                {
                    Directory.CreateDirectory(loc);
                }

                // Create a new file stream where we will be saving the data (local drive)
                if (startPointInt == 0)
                {
                    strLocal = new FileStream(@loc + "\\" + filename, FileMode.Create, FileAccess.Write, FileShare.None);
                }
                else
                {
                    strLocal = new FileStream(@loc + "\\" + filename, FileMode.Append, FileAccess.Write, FileShare.None);
                }

                // It will store the current number of bytes we retrieved from the server
                int bytesSize = 0;
                // A buffer for storing and writing the data retrieved from the server
                byte[] downBuffer = new byte[2048];

                // Loop through the buffer until the buffer is empty
                while ((bytesSize = strResponse.Read(downBuffer, 0, downBuffer.Length)) > 0)
                {
                    // Write the data from the buffer to the local hard drive
                    strLocal.Write(downBuffer, 0, bytesSize);
                    // Invoke the method that updates the form's label and progress bar
                    this.Invoke(new UpdateProgessCallback(this.UpdateProgress), new object[] { strLocal.Length, fileSize + startPointInt });

                    if (goPause == true)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // When the above code has ended, close the streams                
                strResponse.Close();
                strLocal.Close();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {            
            if (thrDownload != null)
            {
                // Abort the thread that's downloading
                thrDownload.Abort();
                // Close the web response and the streams
                webResponse.Close();
                strResponse.Close();
                strLocal.Close();
            }            
            // Set the progress bar back to 0 and the label
            prgDownload.Value = 0;
            lblProgress.Text = "Download Stopped";
            // Disable the Pause/Resume button because the download has ended
            btnPauseResume.Enabled = false;
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            // If the thread exists
            if (thrDownload != null)
            {
                if (btnPauseResume.Text == "Pause")
                {
                    // The Pause/Resume button was set to Pause, thus pause the download
                    goPause = true;

                    // Now that the download was paused, turn the button into a resume button
                    btnPauseResume.Text = "Resume";

                    // Close the web response and the streams
                    webResponse.Close();
                    strResponse.Close();
                    strLocal.Close();
                    // Abort the thread that's downloading
                    thrDownload.Abort();
                }
                else
                {
                    // The Pause/Resume button was set to Resume, thus resume the download
                    goPause = false;

                    // Now that the download was resumed, turn the button into a pause button
                    btnPauseResume.Text = "Pause";

                    long startPoint = 0;

                    if (File.Exists(@loc + "\\" + filename))
                    {
                        startPoint = new FileInfo(@loc + "\\" + filename).Length;
                        
                    }
                    else
                    {
                        MessageBox.Show("The file you choosed to resume doesn't exist.", "Could not resume", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Let the user know we are connecting to the server
                    lblProgress.Text = "Download Resuming";
                    // Create a new thread that calls the Download() method
                    thrDownload = new Thread(new ParameterizedThreadStart(Download));
                    // Start the thread, and thus call Download()
                    thrDownload.Start(startPoint);
                    // Enable the Pause/Resume button
                    btnPauseResume.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("A download does not appear to be in progress.", "Could not pause", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUrl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtUrl_DragDrop(object sender, DragEventArgs e)
        {
            txtUrl.Text = e.Data.GetData(DataFormats.Text).ToString();
        }        
    }
}