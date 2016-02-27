namespace MatrixConnectedAreas
{
    public class Area
    {
        public Area(int upLeftColumn, int upLeftRow)
        {
            this.Size = 0;
            this.UpLeftColumn = upLeftColumn;
            this.UpLeftRow = upLeftRow;
        }

        public int Size { get; private set; }

        public int UpLeftColumn { get; private set; }

        public int UpLeftRow { get; private set; }


        public void IncreaseSize()
        {
            this.Size++;
        } 
    }
}