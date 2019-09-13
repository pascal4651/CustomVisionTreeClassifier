
namespace CustomVisionTreeClassifier
{
    class TreeData
    {
        public string TagName { get; set; }
        public double Probability { get; set; }
        public RectangleBox BoundingBox { get; set; }

        public TreeData(string tagName, double probability, RectangleBox boundingBox)
        {
            TagName = tagName;
            Probability = probability;
            BoundingBox = boundingBox;
        }
    }
}
