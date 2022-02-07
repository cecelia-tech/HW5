using System;
namespace Task1
{
    public class ElementDirections
    {
        public int row;
        public int column;

        public ElementDirections(int column, int row)
        {
            this.row = row;
            this.column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj is ElementDirections receivedDirections)
            {
                if (receivedDirections.row == row &&
                    receivedDirections.column == column)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(column, row);
        }
    }
}
