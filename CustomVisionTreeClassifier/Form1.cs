using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace CustomVisionTreeClassifier
{
    public enum PredictionMode { Detection, Classification};

    public partial class Form1 : Form
    {
        // Create the Api, passing in the training key
        private TrainingApi trainingApi;

        // image classifier = 0; object detection = 1
        private PredictionMode currentPredictionMode;

        private string trainingKey = "0b7821f1a4aa4c36a8ba69466510d49c";
        private string predictionKey = "b7ed33d3839242bda40b995b6a47ba78";
        private PredictionEndpoint endpoint;
        private Project project;
        private List<TreeData> treeListDetection, treeListClassification;
        private int percentLevel;
        private int selectedItemIndex;
        private int mousePositionX, mousePositionY;
        private bool isPredicting;

        private bool isMouseDown = false;
        private Point startMouseLocation = Point.Empty;
        private Point currentMouseLocation = Point.Empty;
        private bool isMouseClicked = false;
        private Rectangle drawingRectangle;
        private List<TreeData> treeListToUpload;
        private string imageTagToUpload = "";

        private Size currentImageSize;
        private int absImgX, absImgY;

        public Form1()
        {
            InitializeComponent();

            trainingApi = new TrainingApi() { ApiKey = trainingKey };
            currentPredictionMode = PredictionMode.Detection;
            project = trainingApi.GetProject(new Guid("e1ec7b7e-ac74-4959-9c8b-4d48d25a7668"));
         
            // Create a prediction endpoint, passing in obtained prediction key
            endpoint = new PredictionEndpoint() { ApiKey = predictionKey };

            labelInfo.Text = textBoxUrl.Text = "";
            percentLevel = trackBar1.Value;
            selectedItemIndex = -1;
            isPredicting = true;
            textBoxTag.Enabled = buttonAddTag.Enabled = buttonSend.Enabled = buttonClear.Enabled = false;
            labelStatus.Text = "PREDICTING";
            treeListToUpload = new List<TreeData>();
            treeListDetection = new List<TreeData>();
            treeListClassification = new List<TreeData>();
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            labelInfo.Text = textBoxUrl.Text = "";
            selectedItemIndex = -1;

            if (Clipboard.ContainsImage())
            {
                pictureBox1.BackgroundImage = new Bitmap(Clipboard.GetImage());
            }
            if (pictureBox1.BackgroundImage != null)
            {
                SetCurrentImageSize();
                treeListToUpload.Clear();
                imageTagToUpload = "";
                treeListDetection.Clear();
                treeListClassification.Clear();
                listView1.Items.Clear();
                pictureBox1.Invalidate();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            labelInfo.Text = textBoxUrl.Text = "";
            selectedItemIndex = -1;

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    
                    pictureBox1.BackgroundImage = new Bitmap(dlg.FileName);
                    textBoxUrl.Text = dlg.FileName;
                }
            }
            if (pictureBox1.BackgroundImage != null)
            {
                treeListDetection.Clear();
                treeListClassification.Clear();
                treeListToUpload.Clear();
                imageTagToUpload = "";
                listView1.Items.Clear();
                SetCurrentImageSize();
                pictureBox1.Invalidate();
            }
        }

        private void buttonUrl_Click(object sender, EventArgs e)
        {
            labelInfo.Text = textBoxUrl.Text = "";
            selectedItemIndex = -1;

            if (Clipboard.ContainsText())
            {
                try
                {
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(Clipboard.GetText());
                    MemoryStream ms = new MemoryStream(bytes);
                    pictureBox1.BackgroundImage = System.Drawing.Image.FromStream(ms);
                    textBoxUrl.Text = Clipboard.GetText();
                }
                catch (Exception ex)
                {
                    labelInfo.Text = ex.ToString();
                }
                if (pictureBox1.BackgroundImage != null)
                {
                    SetCurrentImageSize();
                    treeListDetection.Clear();
                    treeListClassification.Clear();
                    treeListToUpload.Clear();
                    imageTagToUpload = "";
                    listView1.Items.Clear();
                    pictureBox1.Invalidate();
                }
            }
        }

        private void PredictImageDetection()
        {
            treeListDetection.Clear();
            //var attachmentStream = await httpClient.GetStreamAsync(imageUrl);

            MemoryStream testImage = GetStream(pictureBox1.BackgroundImage);
            //MemoryStream testImage = new MemoryStream(File.ReadAllBytes("test.jpg"));

            try
            {
                var result = endpoint.PredictImage(project.Id, testImage);
                // Loop over each prediction and write out the results
                foreach (var c in result.Predictions)
                {
                    treeListDetection.Add(new TreeData(c.TagName, c.Probability, new RectangleBox(c.BoundingBox.Left, c.BoundingBox.Top, c.BoundingBox.Width, c.BoundingBox.Height)));
                }
            }
            catch (Microsoft.Rest.HttpOperationException exception)
            {
                labelInfo.Text = exception.ToString();
            }
            if (treeListDetection.Count > 1)
            {
                treeListDetection.Sort((a, b) => b.Probability.CompareTo(a.Probability));
            }
            if (treeListDetection.Count > 0)
            {
                pictureBox1.Invalidate();
            }
        }

        private void PredictImageClassification()
        {
            treeListClassification.Clear();
            //var attachmentStream = await httpClient.GetStreamAsync(imageUrl);

            MemoryStream testImage = GetStream(pictureBox1.BackgroundImage);
            //MemoryStream testImage = new MemoryStream(File.ReadAllBytes("test.jpg"));

            try
            {
                var result = endpoint.PredictImage(project.Id, testImage);
                // Loop over each prediction and write out the results
                foreach (var c in result.Predictions)
                {
                    treeListClassification.Add(new TreeData(c.TagName, c.Probability, null));
                }
            }
            catch (Microsoft.Rest.HttpOperationException exception)
            {
                labelInfo.Text = exception.ToString();
            }
            if (treeListClassification.Count > 1)
            {
                treeListClassification.Sort((a, b) => b.Probability.CompareTo(a.Probability));
            }
            if (treeListClassification.Count > 0)
            {
                pictureBox1.Invalidate();
            }
        }

        private void PrintPredictionsDetection(Graphics g)
        {
            listView1.Items.Clear();

            if (pictureBox1.BackgroundImage != null && treeListDetection.Count > 0)
            {
                int i = 0;
                foreach (var c in treeListDetection)
                {
                    if (c.Probability * 100 >= percentLevel)
                    {
                        if (isMouseClicked)
                        {
                            if (!c.BoundingBox.Contains(pictureBox1.BackgroundImage, mousePositionX, mousePositionY))
                            {
                                i++;
                                continue;
                            }
                        }
                        AddItemToListView(i + 1, c.TagName, c.Probability);
                        Color color = selectedItemIndex >= 0 && i == selectedItemIndex ? Color.Red : Color.Yellow;
                        DrawRectangle(g, i + 1, c.TagName, new Rectangle(absImgX + (int)Math.Round(currentImageSize.Width * c.BoundingBox.Left), absImgY + (int)Math.Round(currentImageSize.Height * c.BoundingBox.Top),
                              (int)Math.Round(currentImageSize.Width * c.BoundingBox.Width), (int)Math.Round(currentImageSize.Height * c.BoundingBox.Height)), color);
                    }
                    i++;
                }
            }
        }

        private void PrintPredictionsClassification()
        {
            listView1.Items.Clear();

            if (pictureBox1.BackgroundImage != null && treeListClassification.Count > 0)
            {
                int i = 0;
                foreach (var c in treeListClassification)
                {
                    if (c.Probability * 100 >= percentLevel)
                    {
                        AddItemToListView(i + 1, c.TagName, c.Probability);
                    }
                    i++;
                }
            }
        }

        private void AddItemToListView(int index, string name, double probability)
        {
            ListViewItem lvi = new ListViewItem(index.ToString());
            lvi.SubItems.Add(name);
            lvi.SubItems.Add($"{probability:P1}");
            listView1.Items.Add(lvi);
        }

        public MemoryStream GetStream(System.Drawing.Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            return ms;
        }

        private void DrawRectangle(Graphics graphics, int index, string name, Rectangle rectangle, Color color)
        {
            if (color == Color.Red)
            {
                graphics.DrawRectangle(new Pen(color, 3), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                graphics.DrawLine(new Pen(color, 18), rectangle.X, rectangle.Y, rectangle.X + 50, rectangle.Y);
                graphics.DrawString($"{index.ToString()}: {name}", new Font("Arial", 10), Brushes.White, rectangle.X, rectangle.Y - 10);
            }
            else
            {
                graphics.DrawRectangle(new Pen(color, 1.2f), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                graphics.DrawString(index.ToString(), new Font("Arial", 13), Brushes.Yellow, rectangle.X, rectangle.Y);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selectedItemIndex = Int32.Parse(listView1.SelectedItems[0].Text) - 1;
                //selectedItemIndex = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                //PrintPredictions();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"{ trackBar1.Value } %";  
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            percentLevel = trackBar1.Value;
            if (pictureBox1.BackgroundImage != null)
            {
                pictureBox1.Invalidate();
            }
        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (currentPredictionMode == PredictionMode.Detection)
            {
                int tempIndex = Int32.Parse(e.Item.Text) - 1;
                if (selectedItemIndex != tempIndex)
                {
                    selectedItemIndex = tempIndex;
                    pictureBox1.Invalidate();
                }
                e.Item.BackColor = Color.Yellow;
            }
        }

        private void SetCurrentImageSize()
        {
            System.Drawing.Image img = pictureBox1.BackgroundImage;

            var wfactor = (double)img.Width / pictureBox1.ClientSize.Width;
            var hfactor = (double)img.Height / pictureBox1.ClientSize.Height;

            var resizeFactor = Math.Max(wfactor, hfactor);
            currentImageSize = new Size((int)(img.Width / resizeFactor), (int)(img.Height / resizeFactor));

            absImgX = pictureBox1.Width / 2 - currentImageSize.Width / 2;
            absImgY = pictureBox1.Height / 2 - currentImageSize.Height / 2;
            /*
            labelInfo.Text = "Image real width:" + img.Width.ToString() + "\r\nImage real height:" + img.Height.ToString() +
                "\r\nPicturebox width:" + pictureBox1.Width.ToString() + "\r\nPicturebox height:" + pictureBox1.Height.ToString() +
                "Image current width:" + currentImageSize.Width.ToString() + "\r\nImage current height:" + currentImageSize.Height.ToString();
                */
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.BackgroundImage == null) return;

            if (currentPredictionMode == PredictionMode.Detection)
            {
                mousePositionX = (e.X - absImgX) * pictureBox1.BackgroundImage.Width / currentImageSize.Width;
                mousePositionY = (e.Y - absImgY) * pictureBox1.BackgroundImage.Height / currentImageSize.Height;
                textBox2.Text = $"X:{mousePositionX}, Y:{mousePositionY}";

                if (!isPredicting && isMouseDown)
                {
                    currentMouseLocation = e.Location;
                    if (currentMouseLocation.X < absImgX)
                    {
                        currentMouseLocation.X = absImgX;
                    }
                    else if (currentMouseLocation.X > absImgX + currentImageSize.Width)
                    {
                        currentMouseLocation.X = absImgX + currentImageSize.Width;
                    }
                    if (currentMouseLocation.Y < absImgY)
                    {
                        currentMouseLocation.Y = absImgY;
                    }
                    else if (currentMouseLocation.Y > absImgY + currentImageSize.Height)
                    {
                        currentMouseLocation.Y = absImgY + currentImageSize.Height;
                    }
                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isPredicting && currentPredictionMode == PredictionMode.Detection)
            {
                isMouseClicked = true;
                selectedItemIndex = -1;
                pictureBox1.Invalidate();
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage == null) return;
         
            isPredicting = true;
            labelStatus.Text = "PREDICTING";
            if (currentPredictionMode == PredictionMode.Detection && treeListDetection.Count == 0)
            {
                PredictImageDetection();
            }
            else if(currentPredictionMode == PredictionMode.Classification && treeListClassification.Count == 0)
            {
                PredictImageClassification();
            }
            /*
              if (pictureBox1.BackgroundImage != null)
              {
                  treeList = new List<TreeData>()
              {
                  new TreeData("Ask", 0.114f, new RectangleBox(0.0942972749, 0.340928078, 0.493951976, 0.2346549)),
                  new TreeData("Dgr", 0.442f, new RectangleBox(0.0571763366, 0.480578244, 0.495746553, 0.32927686)),
                  new TreeData("Eg", 0.63f, new RectangleBox(0.184433058, 0.3544446, 0.393379152, 0.211728662)),
                  new TreeData("Eg", 0.425f, new RectangleBox(0.122412413, 0.227503985, 0.6607642, 0.244869143)),
                  new TreeData("Eg", 0.277f, new RectangleBox(0.0571763366, 0.480578244, 0.495746553, 0.32927686)),
                  new TreeData("Lærk", 0.545f, new RectangleBox(0.6758347, 0.312082529, 0.296225727, 0.1687854)),
                  new TreeData("Lærk", 0.408f, new RectangleBox(0.8654015, 0.354896665, 0.13458848, 0.1499998)),
                  new TreeData("Lærk", 0.126f, new RectangleBox(0.0165427327, 0.497749716, 0.5283975, 0.3170782)),
              };
                  treeList.Sort((a, b) => b.Probability.CompareTo(a.Probability));
                  pictureBox1.Invalidate();
              }*/
        }

        private void buttonPSMode_Click(object sender, EventArgs e)
        {
            isPredicting = !isPredicting;
            labelStatus.Text = isPredicting ? "PREDICTING" : "SELECTING";
            if (isPredicting)
            {
                buttonProcess.Enabled = true;
                textBoxTag.Enabled = buttonAddTag.Enabled = buttonSend.Enabled = buttonClear.Enabled = false;
            }
            else
            {
                buttonProcess.Enabled = false;
                textBoxTag.Enabled = buttonAddTag.Enabled = buttonSend.Enabled = true;
                buttonClear.Enabled = currentPredictionMode == PredictionMode.Detection ? true : false;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentPredictionMode == PredictionMode.Detection)
            {
                isMouseDown = true;
                startMouseLocation = e.Location;
                if (startMouseLocation.X < absImgX)
                {
                    startMouseLocation.X = absImgX;
                }
                else if (startMouseLocation.X > absImgX + currentImageSize.Width)
                {
                    startMouseLocation.X = absImgX + currentImageSize.Width;
                }
                if (startMouseLocation.Y < absImgY)
                {
                    startMouseLocation.Y = absImgY;
                }
                else if (startMouseLocation.Y > absImgY + currentImageSize.Height)
                {
                    startMouseLocation.Y = absImgY + currentImageSize.Height;
                }
                currentMouseLocation = startMouseLocation;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentPredictionMode == PredictionMode.Detection)
            {
                isMouseDown = false;
                pictureBox1.Invalidate();
                textBoxTag.Focus();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (isPredicting)
            {
                if (currentPredictionMode == PredictionMode.Detection)
                {
                    PrintPredictionsDetection(g);
                }
                else if (currentPredictionMode == PredictionMode.Classification)
                {
                    PrintPredictionsClassification();
                }
            }
            else if (currentPredictionMode == PredictionMode.Detection)
            {
                PrintSelectedRectangles(g);
                if (isMouseDown)
                {
                    drawingRectangle = new Rectangle(
                        Math.Min(startMouseLocation.X, currentMouseLocation.X),
                        Math.Min(startMouseLocation.Y, currentMouseLocation.Y),
                        Math.Abs(startMouseLocation.X - currentMouseLocation.X),
                        Math.Abs(startMouseLocation.Y - currentMouseLocation.Y));
                    g.DrawRectangle(new Pen(Color.Red, 2), drawingRectangle);
                }
                else if (drawingRectangle != Rectangle.Empty)
                {
                    g.DrawRectangle(new Pen(Color.Red, 2), drawingRectangle);
                }
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (isPredicting && currentPredictionMode == PredictionMode.Detection)
            {
                pictureBox1.Cursor = Cursors.Hand;
            }
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage == null)
            {
                MessageBox.Show("Missing image");
                return;
            }
            else if (textBoxTag.Text == "")
            {
                MessageBox.Show("Missing tag");
                return;
            }
            if (currentPredictionMode == PredictionMode.Detection)
            {
                if (drawingRectangle.Width > 20 && drawingRectangle.Height > 20)
                {
                    treeListToUpload.Add(new TreeData(textBoxTag.Text, 0, new RectangleBox(
                        (double)(drawingRectangle.Left - absImgX) / (double)currentImageSize.Width,
                        (double)(drawingRectangle.Top - absImgY) / (double)currentImageSize.Height,
                        (double)drawingRectangle.Width / (double)currentImageSize.Width,
                        (double)drawingRectangle.Height / (double)currentImageSize.Height)));
                    drawingRectangle = Rectangle.Empty;
                    pictureBox1.Invalidate();
                }
                else
                {
                    MessageBox.Show("Missing selected object (> 20px)");
                }
            }
            else if (currentPredictionMode == PredictionMode.Classification)
            {
                imageTagToUpload = textBoxTag.Text;
                MessageBox.Show("The tag is added");
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage == null)
            {
                MessageBox.Show("Missing image or selected regions");
                return;
            }
        
            if (currentPredictionMode == PredictionMode.Detection)
            {
                if (treeListToUpload.Count == 0)
                {
                    MessageBox.Show("Missing selected regions");
                    return;
                }
                try
                {
                    var imageFileEntries = new List<ImageFileCreateEntry>();

                    List<Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models.Region> regions = new List<Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models.Region>();
                    foreach (var item in treeListToUpload)
                    {
                        var tagList = trainingApi.GetTags(project.Id);
                        Tag tag = tagList.FirstOrDefault(x => x.Name.ToLower().Equals(item.TagName.ToLower()));

                        if (tag == null)
                        {
                            tag = trainingApi.CreateTag(project.Id, System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.TagName.ToLower()));
                        }

                        var region = new double[] { item.BoundingBox.Left, item.BoundingBox.Top, item.BoundingBox.Width, item.BoundingBox.Height };
                        regions.Add(new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models.Region(tag.Id, region[0], region[1], region[2], region[3]));
                    }

                    imageFileEntries.Add(new ImageFileCreateEntry(null, GetStream(pictureBox1.BackgroundImage).ToArray(), null, regions));

                    trainingApi.CreateImagesFromFiles(project.Id, new ImageFileCreateBatch(imageFileEntries));
                    treeListToUpload.Clear();
                    pictureBox1.Invalidate();
                    MessageBox.Show("The image is uploaded successfully");
                }
                catch (Exception ex)
                {
                    labelInfo.Text = ex.ToString();
                }
            }
            else if (currentPredictionMode == PredictionMode.Classification)
            {
                if (imageTagToUpload == "")
                {
                    MessageBox.Show("Missing tag");
                    return;
                }
                try
                {
                    var tagList = trainingApi.GetTags(project.Id);
                    Tag tag = tagList.FirstOrDefault(x => x.Name.ToLower().Equals(imageTagToUpload.ToLower()));
                    if (tag == null)
                    {
                        tag = trainingApi.CreateTag(project.Id, imageTagToUpload.ToLower());
                    }
                    trainingApi.CreateImagesFromData(project.Id, GetStream(pictureBox1.BackgroundImage), new List<string>() { tag.Id.ToString() });
                    MessageBox.Show("The image is uploaded successfully");
                }
                catch (Exception ex)
                {
                    labelInfo.Text = ex.ToString();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (currentPredictionMode == PredictionMode.Detection)
            {
                drawingRectangle = Rectangle.Empty;
                treeListToUpload.Clear();
                pictureBox1.Invalidate();
            }
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if(trainingApi.GetIterations(project.Id).Count < 10)
            {
                labelStatus.Text = "TRAINING";
                var iteration = trainingApi.TrainProject(project.Id);

                // The returned iteration will be in progress, and can be queried periodically to see when it has completed
                while (iteration.Status != "Completed")
                {
                    Thread.Sleep(1000);
                    // Re-query the iteration to get its updated status
                    iteration = trainingApi.GetIteration(project.Id, iteration.Id);
                }

                // The iteration is now trained. Make it the default project endpoint
                iteration.IsDefault = true;
                trainingApi.UpdateIteration(project.Id, iteration.Id, iteration);
                labelStatus.Text = "Done!";
            }
            else
            {
                MessageBox.Show("The number of iterations is 10");
            } 
        }

        private void radioButtonDetection_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDetection.Checked)
            {
                currentPredictionMode = PredictionMode.Detection;
                project = trainingApi.GetProject(new Guid("e1ec7b7e-ac74-4959-9c8b-4d48d25a7668"));
                buttonClear.Enabled = isPredicting ? false : true;
            }
            pictureBox1.Invalidate();
        }

        private void radioButtonClassification_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonClassification.Checked)
            {
                currentPredictionMode = PredictionMode.Classification;
                project = trainingApi.GetProject(new Guid("7037781f-ff91-4fbf-943e-087d835438e7"));
                buttonClear.Enabled = false;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isMouseClicked = false;
            pictureBox1.Invalidate();
            pictureBox1.Cursor = Cursors.Default;
        }

        private void PrintSelectedRectangles(Graphics g)
        {
            listView1.Items.Clear();

            if (pictureBox1.BackgroundImage != null && treeListToUpload.Count > 0)
            {
                int i = 0;
                foreach (var c in treeListToUpload)
                {
                    AddItemToListView(i + 1, c.TagName, c.Probability);
                    DrawRectangle(g, i + 1, c.TagName, new Rectangle(absImgX + (int)Math.Round(currentImageSize.Width * c.BoundingBox.Left), absImgY + (int)Math.Round(currentImageSize.Height * c.BoundingBox.Top),
                          (int)Math.Round(currentImageSize.Width * c.BoundingBox.Width), (int)Math.Round(currentImageSize.Height * c.BoundingBox.Height)), Color.Yellow);
                    i++;
                }
            }
        }
    }
}
